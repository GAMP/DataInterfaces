using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Reflection;
using System.ComponentModel;
using SharedLib;

namespace CoreLib
{
    #region ObjectCopier
    /// <summary>
    /// Reference Article http://www.codeproject.com/KB/tips/SerializedObjectCloner.aspx
    /// 
    /// Provides a method for performing a deep copy of an object.
    /// Binary Serialization is used to perform the copy.
    /// </summary>
    public static class ObjectCopier
    {
        /// <summary>
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(T source)
        {
            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    } 
    #endregion    

    #region Reflection
    /// <summary>
    /// Reflection helper class.
    /// </summary>
    public static class Reflection
    {
        #region Functions
        /// <summary>
        /// Checks if specified membertype exists in the object.
        /// </summary>
        /// <param name="Element">Object to search for memebers.</param>
        /// <param name="PropertyName">Member name.</param>
        /// <param name="MemberType">Member type we are looking for.</param>
        /// <param name="IgnoreCase">String compare case option.</param>
        /// <returns>True or false.</returns>
        /// <remarks></remarks>
        public static bool PropertyExists(object Element, string PropertyName, MemberTypes MemberType = MemberTypes.Property, bool IgnoreCase = true)
        {
            try
            {
                System.Type ObjType = Element.GetType();
                System.Reflection.MemberInfo[] MemberItems = null;
                switch (MemberType)
                {
                    case MemberTypes.Property:
                        MemberItems = ObjType.GetProperties();
                        break;
                    case MemberTypes.Method:
                        MemberItems = ObjType.GetMethods();
                        break;
                    case MemberTypes.Event:
                        MemberItems = ObjType.GetEvents();
                        break;
                    case MemberTypes.Constructor:
                        MemberItems = ObjType.GetConstructors();
                        break;
                    case MemberTypes.Field:
                        MemberItems = ObjType.GetFields();
                        break;
                    case MemberTypes.NestedType:
                        MemberItems = ObjType.GetNestedTypes();
                        break;
                }
                foreach (PropertyInfo property in MemberItems)
                {
                    if (property.MemberType == MemberType && string.Compare(property.Name, PropertyName, IgnoreCase) == 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {

            }
            return false;
        }
        #endregion
    }  
    #endregion       
}
