using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

            var propertyInfo = expression.Member as System.Reflection.PropertyInfo;
            var target = lambda.Compile().Target;
            propertyInfo.SetValue(target,value);
        }
    }
}
