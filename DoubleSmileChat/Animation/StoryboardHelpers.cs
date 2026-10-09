using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace DoubleSmileChat.Animation
{
    public static class StoryboardHelpers
    {
        /// <summary>
        /// 向故事板添加一个从右侧滑入的动画
        /// </summary>
        /// <param name="storyboard">要添加动画的故事板</param>
        /// <param name="seconds">动画持续的时间</param>
        /// <param name="offset">动画开始时向右偏移的距离</param>
        /// <param name="decelerationRatio">减速比例</param>
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            // 创建一个从右侧滑入的边距动画
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

        // 设置目标属性名称
        Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // 将动画添加到故事板
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// 向故事板添加一个向左滑出的动画
        /// </summary>
        /// <param name="storyboard">要添加动画的故事板</param>
        /// <param name="seconds">动画持续的时间</param>
        /// <param name="offset">向右移动的距离</param>
        /// <param name="decelerationRatio">减速比例</param>
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            // 创建一个从右侧滑出的边距动画
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelerationRatio
            };

            // 设置目标属性名称
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // 将动画添加到故事板
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// 向故事板添加一个淡入动画
        /// </summary>
        /// <param name="storyboard">要添加动画的故事板</param>
        /// <param name="seconds">动画持续的时间</param>
        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
            // 创建一个淡入动画
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1,
            };

            // 设置目标属性名称
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // 将动画添加到故事板
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// 向故事板添加一个淡出动画
        /// </summary>
        /// <param name="storyboard">要添加动画的故事板</param>
        /// <param name="seconds">动画持续的时间</param>
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            // 创建一个淡出动画
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0,
            };

            // 设置目标属性名称
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // 将动画添加到故事板
            storyboard.Children.Add(animation);
        }
    }
}
