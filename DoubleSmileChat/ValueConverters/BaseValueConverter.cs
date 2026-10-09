using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace DoubleSmileChat
{
    /// <summary>
    /// 一个基础值转换器类，允许在 XAML 中直接使用
    /// </summary>
    /// <typeparam name="T">该值转换器的类型</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region 私有成员

        /// <summary>
        /// 该值转换器的单例静态实例
        /// </summary>
        private static T mConverter = null;

        #endregion

        #region 标记扩展方法

        /// <summary>
        /// 提供值转换器的静态实例
        /// </summary>
        /// <param name="serviceProvider">服务提供者</param>
        /// <returns>返回值转换器实例</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
        }

        #endregion

        #region 值转换器方法

        /// <summary>
        /// 将一种类型的值转换为另一种类型的值
        /// </summary>
        /// <param name="value">绑定源的值</param>
        /// <param name="targetType">目标属性的类型</param>
        /// <param name="parameter">转换参数</param>
        /// <param name="culture">区域文化信息</param>
        /// <returns>转换后的值</returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// 将转换后的值转换回原始数据类型
        /// </summary>
        /// <param name="value">目标属性的值</param>
        /// <param name="targetType">源数据类型</param>
        /// <param name="parameter">转换参数</param>
        /// <param name="culture">区域文化信息</param>
        /// <returns>转换回的原始值</returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}