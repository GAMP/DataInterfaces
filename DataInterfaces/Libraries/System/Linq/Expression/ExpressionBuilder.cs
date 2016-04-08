using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace System.Linq.Expressions
{
    #region ExpressionBuilder
    public static class ExpressionBuilder
    {
        #region STATIC FIELDS
        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains");
        private static MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
        private static MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });
        private static MethodInfo hasFlagMethod = typeof(Enum).GetMethod("HasFlag", new Type[] { typeof(Enum) });
        #endregion

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

        private static Expression GetExpression<T>(ParameterExpression param, Filter filter)
        {
            object filterValue = filter.Value;
            string filterName = filter.PropertyName;
            Op operation = filter.Operation;

            MemberExpression member = Expression.Property(param, filter.PropertyName);
            ConstantExpression constant = null;

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

            switch (operation)
            {
                case Op.Equals:
                    return Expression.Equal(member, constant);

                case Op.GreaterThan:
                    return Expression.GreaterThan(member, constant);

                case Op.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(member, constant);

                case Op.LessThan:
                    return Expression.LessThan(member, constant);

                case Op.LessThanOrEqual:
                    return Expression.LessThanOrEqual(member, constant);

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

        private static BinaryExpression GetExpression<T>(ParameterExpression param, Filter filter1, Filter filter2)
        {
            Expression bin1 = GetExpression<T>(param, filter1);
            Expression bin2 = GetExpression<T>(param, filter2);
            return Expression.AndAlso(bin1, bin2);
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
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }

        private static bool IsNullableType(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }

    } 
    #endregion

    #region Filter
    [DataContract()]
    [Serializable()]
    public class Filter
    {
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

            return new List<Filter>() { new Filter() { PropertyName = propertyName, Value = propertyValue, Operation = operation } };
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
}
