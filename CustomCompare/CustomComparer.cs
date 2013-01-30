using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SpecAid.CustomCompare
{
    public class CustomComparer<T> : IEqualityComparer<T>
    {
        public static CustomComparer<T> CreateNew()
        {
            return new CustomComparer<T>();
        }

        private CustomComparer()
        {

        }

        private List<Expression<Func<T, object>>> _propExpression = new List<Expression<Func<T, object>>>();
        private List<Func<T, object>> _propGetters = new List<Func<T, object>>();

        public CustomComparer<T> Add(Expression<Func<T, object>> getPropertyExpression)
        {
            _propExpression.Add(getPropertyExpression);
            _propGetters.Add(getPropertyExpression.Compile());

            return this;
        }

        public bool Equals(T x, T y)
        {
            foreach (var propGetter in _propGetters)
            {
                var px = propGetter(x);
                var py = propGetter(y);
                if (px == null && py == null)
                    continue;
                if (px == null || py == null)
                    return false;
                if (!propGetter(x).Equals(py))
                    return false;
            }
            return true;
        }

        public int GetHashCode(T obj)
        {
            var result = 37;
            foreach (var propGetter in _propGetters)
            {
                var val = propGetter(obj);
                result = (result * 397) ^ (val == null ? 1009 : val.GetHashCode());
            }

            return result;
        }

        /// <summary>
        /// returns a string representation of an object but only displays the properties used in the custom comparer
        /// </summary>
        public string GetString(T obj)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < _propExpression.Count; i++)
            {
                if (i != 0)
                    builder.Append(", ");
                var propName = Member.Name<T>(_propExpression[i]);
                var value = _propGetters[i](obj).ToString();
                builder.Append(propName + "=" + value);
            }
            return builder.ToString();
        }

        /// <summary>
        /// returns a string representation of an object but only displays the properties used in the custom comparer
        /// </summary>
        public string GetFieldEqualValueStringWithSymbolicLink(T obj)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < _propExpression.Count; i++)
            {
                if (i != 0)
                    builder.Append(", ");
                
                var propName = Member.Name<T>(_propExpression[i]);
                var value = _propGetters[i](obj);

                string valueWithSymbolic;

                if (value == null)
                    valueWithSymbolic = "null";
                else
                    valueWithSymbolic = GetValueWithSymbolicLink(value.ToString(), propName);

                builder.Append(propName + "=" + valueWithSymbolic);
            }
            return builder.ToString();
        }

        /// <summary>
        ///   Used in the fancy printers to export actual Property Names
        /// </summary>
        /// 
        public List<string> GetHeaderValuesInPropertyOrder()
        {
            var results = new List<string>();

            for (int i = 0; i < _propExpression.Count; i++)
            {
                results.Add(Member.Name<T>(_propExpression[i]));
            }

            return results;
        }

        /// <summary>
        ///   Used in the fancy printers to export a List of Values.
        ///   Should be used in conjunction with GetHeaderValuesInPropertyOrder()
        /// </summary>

        public List<string> GetColumnValuesInPropertyOrder(T obj)
        {
            var results = new List<string>();

            for (int i = 0; i < _propExpression.Count; i++)
            {
                var value = _propGetters[i](obj);

                if (value == null)
                {
                    results.Add("[null]");
                    continue;
                }

                var propName = Member.Name<T>(_propExpression[i]);
                results.Add(GetValueWithSymbolicLink(value.ToString(),propName));
            }

            return results;
        }

        /// <summary>
        /// Shared by GetColumnValuesInPropertyOrder and GetFieldEqualValueStringWithSymbolicLink
        /// </summary>
        public string GetValueWithSymbolicLink(string value, string propName)
        {
            var symbolicLink = GetSymbolicLinkFromValue(value, propName);

            if (!string.IsNullOrEmpty(symbolicLink))
                return value + " (" + symbolicLink + ")";
            else
                return value;
        }

        public string GetSymbolicLinkFromValue(object value, string propertyName)
        {
            if (ScenarioContext.Current == null)
                return String.Empty;

            // We need to fuzzy match so grab them all.
            var keys = ScenarioContext.Current.Keys;

            Regex symbolicLinkRegex = new Regex("<<" + propertyName + @"\d*>>", RegexOptions.IgnoreCase);
            var keyNamesForProperty = keys.Where(s => symbolicLinkRegex.IsMatch(s)).ToList();

            StringBuilder builder = new StringBuilder();
            foreach (var keyName in keyNamesForProperty)
            {
                var nameToValueItem = ScenarioContext.Current[keyName];
                if (nameToValueItem == null)
                    continue;

                if ((nameToValueItem.Equals(value)) || (nameToValueItem.ToString() == value.ToString()))
                {
                    if (builder.Length > 0)
                        builder.Append(" or ");
                    builder.Append(keyName);
                }
            }
            return builder.ToString();
        }


        private static class Member
        {
            private static string GetMemberName(Expression expression)
            {
                switch (expression.NodeType)
                {
                    case ExpressionType.MemberAccess:
                        var memberExpression = (MemberExpression)expression;
                        var supername = GetMemberName(memberExpression.Expression);

                        if (String.IsNullOrEmpty(supername))
                            return memberExpression.Member.Name;

                        return String.Concat(supername, '.', memberExpression.Member.Name);

                    case ExpressionType.Call:
                        var callExpression = (MethodCallExpression)expression;
                        return callExpression.Method.Name;

                    case ExpressionType.Constant:
                        var constantExpression = (ConstantExpression)expression;
                        return String.Empty;

                    case ExpressionType.Convert:
                        var unaryExpression = (UnaryExpression)expression;
                        return GetMemberName(unaryExpression.Operand);

                    case ExpressionType.Parameter:
                        return String.Empty;

                    default:
                        throw new ArgumentException("The expression is not a member access or method call expression");
                }
            }

            public static string Name<TN>(Expression<Func<TN, object>> expression)
            {
                return GetMemberName(expression.Body);
            }

            public static string Name<TN>(Expression<Action<TN>> expression)
            {
                return GetMemberName(expression.Body);
            }
        }


    }
}