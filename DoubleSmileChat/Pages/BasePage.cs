using DoubleSmileChat.Animation;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DoubleSmileChat.Pages
{
    /// <summary>
    /// 所有页面的基类。
    /// 动画本身不在这里实现，而是复用 <see cref="PageAnimations"/> 里的扩展方法，
    /// 这样 UserControl、Window 内容等任何元素也能用同一套动画。
    /// </summary>
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {
        #region 私有成员
        /// <summary>
        /// 和页面关联的视图模型
        /// </summary>
        private VM mViewModel;
        #endregion
        #region 公共属性
        /// <summary>
        /// 滑入动画
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// 滑出动画
        /// </summary>
        public PageAnimation PageUnLoadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// 动画持续时间（秒）
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;
        /// <summary>
        /// 和页面关联的数据模型
        /// </summary>
        public VM ViewModel
        {

            get => mViewModel;
            set
            {
                //如果设置的值和当前值相同，则不做任何操作
                if (mViewModel == value) return;
                //设置新的值
                mViewModel = value;
                //将数据模型绑定到页面的 DataContext上
                this.DataContext = mViewModel;
            }
        }
        #endregion

        #region 构造器
        public BasePage()
        {
            // 如果设置了滑入动画，则在页面加载时先将其隐藏
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;
            // 页面加载完成后，执行滑入动画
            this.Loaded += BasePage_Loaded;
            this.DataContext = new VM();
        }

        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            await AnimateIn();
        }
        #endregion

        #region 动画
        /// <summary>
        /// 页面滑入
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            // Make sure we have something to do
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    // Start the animation
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);

                    break;
            }
        }

        /// <summary>
        /// Animates the page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            // Make sure we have something to do
            if (this.PageUnLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnLoadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    // Start the animation
                    await this.SlideAndFadeOutToLeft(this.SlideSeconds);

                    break;
            }
        }

        #endregion
    }
}
