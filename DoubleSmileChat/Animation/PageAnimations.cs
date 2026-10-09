using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace DoubleSmileChat.Animation
{
    public static class PageAnimations
    {
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            // 必须先设为可见并跑一次布局：折叠(Collapsed)的元素不参与布局，
            // ActualWidth 恒为 0，位移距离会算成 0，结果就是"只有淡入、没有滑动"。
            page.Visibility = Visibility.Visible;
            page.UpdateLayout();

            var sb = new Storyboard();

            sb.AddSlideFromRight(seconds, GetOffset(page));

            sb.AddFadeIn(seconds);

            sb.Begin(page);

            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            page.Visibility = Visibility.Visible;
            page.UpdateLayout();

            var sb = new Storyboard();

            sb.AddSlideToLeft(seconds, GetOffset(page));

            sb.AddFadeOut(seconds);

            sb.Begin(page);

            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// 位移距离：优先取元素的实际宽度。
        ///
        /// 不要用 Page.WindowWidth —— 它只在 NavigationWindow 宿主里才有值，
        /// 用普通 Window + Frame 承载页面时它是 NaN，
        /// 动画的 From/To 会变成非法 Thickness，滑动整个失效（只剩淡入淡出）。
        /// </summary>
        private static double GetOffset(FrameworkElement element)
        {
            if (element.ActualWidth > 0)
                return element.ActualWidth;

            if (!double.IsNaN(element.Width) && element.Width > 0)
                return element.Width;

            // 兜底：还没布局过时用屏幕半宽，保证动画一定看得见
            return SystemParameters.PrimaryScreenWidth / 2;
        }
    }
}
