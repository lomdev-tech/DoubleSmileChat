using System.Windows;
using System.Windows.Controls;

namespace DoubleSmileChat.ValueConverters
{
    /// <summary>
    /// 监听 PasswordBox 的密码变化。
    /// PasswordBox.Password 不是依赖属性，样式触发器无法直接绑定，
    /// 因此通过附加属性 PasswordLength 把"密码长度"暴露给 XAML 使用。
    /// 用法（XAML 中）：
    ///   <PasswordBox vc:PasswordBoxMonitor.MonitorPassword="True" .../>
    /// </summary>
    public static class PasswordBoxMonitor
    {
        #region MonitorPassword 附加属性：是否开启监听

        public static readonly DependencyProperty MonitorPasswordProperty =
            DependencyProperty.RegisterAttached(
                "MonitorPassword", typeof(bool), typeof(PasswordBoxMonitor),
                new PropertyMetadata(false, OnMonitorPasswordChanged));

        public static bool GetMonitorPassword(DependencyObject obj)
        {
            return (bool)obj.GetValue(MonitorPasswordProperty);
        }

        public static void SetMonitorPassword(DependencyObject obj, bool value)
        {
            obj.SetValue(MonitorPasswordProperty, value);
        }

        private static void OnMonitorPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var box = d as PasswordBox;
            if (box == null)
                return;

            if ((bool)e.OldValue)
                box.PasswordChanged -= Box_PasswordChanged;

            if ((bool)e.NewValue)
            {
                box.PasswordChanged += Box_PasswordChanged;
                // 初始也要同步一次（默认密码为空，长度 0）
                UpdateLength(box);
            }
        }

        #endregion

        #region PasswordLength 只读附加属性：当前密码长度

        private static readonly DependencyPropertyKey PasswordLengthPropertyKey =
            DependencyProperty.RegisterAttachedReadOnly(
                "PasswordLength", typeof(int), typeof(PasswordBoxMonitor),
                new PropertyMetadata(0));

        public static readonly DependencyProperty PasswordLengthProperty =
            PasswordLengthPropertyKey.DependencyProperty;

        public static int GetPasswordLength(DependencyObject obj)
        {
            return (int)obj.GetValue(PasswordLengthProperty);
        }

        #endregion

        private static void Box_PasswordChanged(object sender, RoutedEventArgs e)
        {
            UpdateLength((PasswordBox)sender);
        }

        private static void UpdateLength(PasswordBox box)
        {
            box.SetValue(PasswordLengthPropertyKey, box.Password.Length);
        }
    }
}
