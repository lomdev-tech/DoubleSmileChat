using System;
using System.Linq.Expressions;
using System.Reflection;


namespace DoubleSmileChat.Expressions
{
    public static class ExpressionsHelps
    {
        /// <summary>
        /// 编译表达式并获取属性值
        /// </summary>
        /// <typeparam name="T">占位类型，使用时指定</typeparam>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }
        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda,T value)
        {
            var expression = (lambda as LambdaExpression).Body as MemberExpression;
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();
            propertyInfo.SetValue(target,value);
        }
    }
}
