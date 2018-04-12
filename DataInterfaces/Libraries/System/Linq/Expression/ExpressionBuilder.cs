using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace System.Linq.Expressions
{
    #region ExpressionBuilder
    public static class ExpressionBuilder
    {
        #region STATIC FIELDS
        private static MethodInfo compareMethod = typeof(string).GetMethod("Compare", new[] { typeof(string), typeof(string), typeof(StringComparison) });
        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains");
        private static MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
        private static MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });
        private static MethodInfo hasFlagMethod = typeof(Enum).GetMethod("HasFlag", new Type[] { typeof(Enum) });
        #endregion

        #region STATIC FUNCTIONS

        public static Expression<Func<T, bool>> GetExpression<T>(IEnumerable<Filter> filter)
        {
            if (filter == null || filter.Count() == 0)
                return ExpressionBuilder.True<T>();

            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression exp = null;

            var filters = filter.ToList();

            if (filters.Count == 1)
                exp = GetExpression<T>(param, filters[0]);
            else if (filters.Count == 2)
                exp = GetExpression<T>(param, filters[0], filters[1]);
            else
            {
                while (filters.Count > 0)
                {
                    var f1 = filters[0];
                    var f2 = filters[1];

                    if (exp == null)
                        exp = GetExpression<T>(param, filters[0], filters[1]);
                    else
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0], filters[1]));

                    filters.Remove(f1);
                    filters.Remove(f2);

                    if (filters.Count == 1)
                    {
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0]));
                        filters.RemoveAt(0);
                    }
                }
            }

            return Expression.Lambda<Func<T, bool>>(exp, param);
        }

        private static BinaryExpression GetExpression<T>(ParameterExpression param, Filter filter1, Filter filter2)
        {
            Expression bin1 = GetExpression<T>(param, filter1);
            Expression bin2 = GetExpression<T>(param, filter2);
            return Expression.AndAlso(bin1, bin2);
        }

        private static Expression GetExpression<T>(ParameterExpression param, Filter filter)
        {
            object filterValue = filter.Value;
            string filterName = filter.PropertyName;
            Op operation = filter.Operation;

            MemberExpression member = Expression.Property(param, filter.PropertyName);
            ConstantExpression constant = null;

            #region NULLABLE HANDLING
            if (filterValue != null && IsNullableType(member.Type))
            {
                var targetType = Nullable.GetUnderlyingType(member.Type);
                var propertyValue = Convert.ChangeType(filterValue, targetType);
                constant = Expression.Constant(propertyValue, member.Type);
            }
            else
            {
                constant = Expression.Constant(filterValue);
            }
            #endregion

            switch (operation)
            {
                case Op.GreaterThan:
                    return Expression.GreaterThan(member, constant);

                case Op.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(member, constant);

                case Op.LessThan:
                    return Expression.LessThan(member, constant);

                case Op.LessThanOrEqual:
                    return Expression.LessThanOrEqual(member, constant);

                case Op.Equals:

                    //string equals ignore case comparison
                    if (member.Type.TypeHandle.Equals(typeof(string).TypeHandle))
                    {
                        var compareExpression = Expression.Call(null, compareMethod, member, constant, Expression.Constant(StringComparison.InvariantCultureIgnoreCase));
                        return Expression.Equal(compareExpression, Expression.Constant(0));
                    }

                    return Expression.Equal(member, constant);

                case Op.Contains:
                    return Expression.Call(member, containsMethod, constant);

                case Op.StartsWith:
                    return Expression.Call(member, startsWithMethod, constant);

                case Op.EndsWith:
                    return Expression.Call(member, endsWithMethod, constant);

                case Op.NotEqual:
                    return Expression.NotEqual(member, constant);

                case Op.HasFlag:
                    constant = Expression.Constant(filter.Value, typeof(Enum));
                    return Expression.Call(member, hasFlagMethod, constant);
            }

            return null;
        }

        /// <summary>
        /// Gets the expression that is always true.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <returns>True expression.</returns>
        public static Expression<Func<T, bool>> True<T>() { return x => true; }

        /// <summary>
        /// Gets the expression that is always false.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <returns>False expression.</returns>
        public static Expression<Func<T, bool>> False<T>() { return x => false; }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
                                                            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }

        /// <summary>
        /// Gets if specified type is nullable.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <returns>True or false.</returns>
        public static bool IsNullableType(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        } 

        #endregion
    }
    #endregion

    #region Filter
    [DataContract()]
    [Serializable()]
    public class Filter
    {
        #region CONSTRUCTOR
        public Filter()
        { }

        public Filter(string propertyName, object value, Op operation)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            this.PropertyName = propertyName;
            this.Value = value;
            this.Operation = operation;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Filter property name.
        /// </summary>
        [DataMember()]
        public string PropertyName { get; set; }

        /// <summary>
        /// Operation type.
        /// </summary>
        [DataMember()]
        public Op Operation { get; set; }

        /// <summary>
        /// Filter value.
        /// </summary>
        [DataMember()]
        public object Value { get; set; }

        #endregion

        #region STATIC FUNCTIONS

        /// <summary>
        /// Creates a single filter list.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <param name="propertyValue">Property value.</param>
        /// <param name="operation">Operation.</param>
        /// <returns></returns>
        public static IEnumerable<Filter> CreateSingle(string propertyName, object propertyValue, Op operation)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            return new FilterSet() { new Filter() { PropertyName = propertyName, Value = propertyValue, Operation = operation } };
        }

        /// <summary>
        /// Gets dafault filter value.
        /// </summary>
        public static IEnumerable<Filter> Default
        {
            get { return default(IEnumerable<Filter>); }
        }

        #endregion
    }
    #endregion

    #region Op
    [Serializable()]
    public enum Op
    {
        Equals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual,
        Contains,
        StartsWith,
        EndsWith,
        NotEqual,
        HasFlag
    }
    #endregion

    #region FilterSet
    /// <summary>
    /// Filter set.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class FilterSet : List<Filter>, IFilterSet
    {
        #region CONSTRUCTOR

        public FilterSet() : base()
        { }

        public FilterSet(IEnumerable<Filter> source) : base(source)
        { }

        #endregion

        #region FIELDS
        [OptionalField(VersionAdded = 2)]
        private HashSet<string> includes;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Amount of records to take.
        /// </summary>
        [DataMember()]
        public int? Take
        {
            get; set;
        }

        /// <summary>
        /// Amount of records to skip.
        /// </summary>
        [DataMember()]
        public int? Skip
        {
            get; set;
        }

        public HashSet<string> Includes
        {
            get
            {
                if (this.includes == null)
                    this.includes = new HashSet<string>();
                return this.includes;
            }
            set { this.includes = value; }
        }

        ICollection<string> IFilterSet.Includes
        {
            get { return this.Includes; }
        }

        #endregion
    }
    #endregion

    #region ResultSet
    [Serializable()]
    [DataContract()]
    public class ResultSet<T> : List<T>
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new result set.
        /// </summary>
        /// <param name="source">Source collection.</param>
        public ResultSet(IEnumerable<T> source) : base(source)
        { }

        /// <summary>
        /// Creates new result set.
        /// </summary>
        /// <param name="source">Source collection.</param>
        /// <param name="totalCount">Total unfiltered count in source collection.</param>
        public ResultSet(IEnumerable<T> source, int? totalCount) : this(source)
        {
            this.TotalCount = totalCount;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets total count in source collection.
        /// </summary>
        [DataMember()]
        public int? TotalCount
        {
            get;
            private set;
        }

        #endregion
    }
    #endregion

    #region Extensions
    public static class Extensions
    {
        public static FilterSet ToFilterSet(this IEnumerable<Filter> source)
        {
            return source.ToFilterSet(null, null);
        }

        public static FilterSet ToFilterSet(this IEnumerable<Filter> source, int? take, int? skip)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new FilterSet(source) { Take = take, Skip = skip };
        }

        public static ResultSet<T> ToResultSet<T>(this IEnumerable<T> source, IEnumerable<Filter> filters)
        {
            return source.ToResultSet(filters, null);
        }

        public static ResultSet<T> ToResultSet<T>(this IEnumerable<T> source, IEnumerable<Filter> filters, int? count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (filters is IFilterSet iFilterSet)
            {
                if (iFilterSet.Skip.HasValue)
                    source = source.Skip(iFilterSet.Skip.Value);

                if (iFilterSet.Take.HasValue)
                    source = source.Take(iFilterSet.Take.Value);
            }

            return new ResultSet<T>(source, count);
        }
    }
    #endregion
}
