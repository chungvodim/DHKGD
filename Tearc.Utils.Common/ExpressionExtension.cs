using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tearc.Utils.Common
{
    public static class ExpressionExtension
    {
        
        public static IQueryable<T> WhereMany<T>(this IQueryable<T> source, params Expression<Func<T, bool>>[] predicates)
        {
            if (predicates != null && predicates.Any())
            {
                foreach (var predicate in predicates)
                {
                    source = source.Where(predicate);
                }
            }
            return source;
        }

        public static IQueryable<T> WhereMany<T>(this IQueryable<T> source, IEnumerable<Expression<Func<T, bool>>> predicates)
        {
            return source.WhereMany(predicates.ToArray());
        }

        public static IList<T> CastToList<T>(this IEnumerable source)
        {
            return new List<T>(source.Cast<T>());
        }

        public static Expression<Func<T, bool>> Combine<T>(this IEnumerable<Expression<Func<T, bool>>> expressions)
        {

            if (expressions == null)
            {
                return t => true;
                //throw new ArgumentNullException("expressions");
            }
            if (expressions.Count() == 0)
            {
                return t => true;
            }
            Type delegateType = typeof(Func<,>)
                                    .GetGenericTypeDefinition()
                                    .MakeGenericType(new[] {
                                typeof(T),
                                typeof(bool)
                                    }
                                );
            var combined = expressions
                               .Cast<Expression>()
                               .Aggregate((e1, e2) => Expression.AndAlso(e1, e2));
            return (Expression<Func<T, bool>>)Expression.Lambda(delegateType, combined);
        }

        public static string MemberName<T, V>(this Expression<Func<T, V>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new InvalidOperationException("Expression must be a member expression");

            return memberExpression.Member.Name;
        }

        public static T GetAttribute<T>(this ICustomAttributeProvider provider)
            where T : Attribute
        {
            var attributes = provider.GetCustomAttributes(typeof(T), true);
            return attributes.Length > 0 ? attributes[0] as T : null;
        }

        public static bool IsRequired<T, V>(this Expression<Func<T, V>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new InvalidOperationException("Expression must be a member expression");

            return memberExpression.Member.GetAttribute<RequiredAttribute>() != null;
        }
    }
}
