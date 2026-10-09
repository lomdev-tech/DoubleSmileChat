using DoubleSmileChat.Models;
using System.Windows;
using System.Windows.Input;

namespace DoubleSmileChat.ViewModel
{
    public class WindowViewModel : BaseViewModel
    {
        #region 私有成员

        // 保存当前 Window 窗体对象
        //
        // 构造函数中会把 MainWindow 传进来：
        //
        // new WindowViewModel(this)
        //
        // 所以这里的 _window 实际上就是 MainWindow
        private Window _window;


        // 窗口正常状态下的外边距
        // 默认值为 10
        private int _outerMaginSize = 10;


        // 窗口正常状态下的圆角半径
        // 默认值为 10
        private int _windowRadius = 10;
        private WindowDockPosition _dockPosition;
        #endregion

        #region 公共属性

        public int WindowMiniumWidth { get; set; } = 420;
        public int WindowMiniumHeight { get; set; } = 400;
        public bool Borderless { get => _window.WindowState == WindowState.Maximized || _dockPosition != WindowDockPosition.Undocked; }
        // 窗体调整大小时，鼠标可以拖动的边框区域大小
        // 单位：像素
        // 默认值为 6
        public int ResizeBorder { get => Borderless ? 0 : 6; }

        // 将 ResizeBorder 转换成 WPF 的 Thickness 类型
        // Thickness 可以表示：
        // 左、上、右、下 四个方向的边距
        //
        // new Thickness(6)
        // 等价于：
        // Left   = 6
        // Top    = 6
        // Right  = 6
        // Bottom = 6
        //
        // 这个属性一般会绑定到 XAML 中的 Margin、Padding 等属性
        public Thickness ResizeBorderThickness
        {
            get => new Thickness(ResizeBorder + OuterMarginSize);
        }

        public Thickness InnerContentPadding
        {
            get => new Thickness(0);
        }


        // 窗体外边距大小
        //
        // 当窗口处于“最小化”状态时：
        //     返回 0
        //
        // 正常状态：
        //     返回 _outerMaginSize
        //
        // 这样做的目的通常是：
        // 窗口最小化时去掉外部 Margin，
        // 避免窗口周围还保留空白区域。
        public int OuterMarginSize
        {
            get => _window.WindowState == WindowState.Maximized ? 0 : _outerMaginSize;


            set
            {
                _outerMaginSize = value;
            }
        }
        public Thickness OuterMarginSizeThickness
        {
            get => new Thickness(OuterMarginSize);
        }

        // 窗口圆角半径
        //
        // 正常情况下：
        //     返回 _windowRadius
        //
        // 窗口最小化时：
        //     返回 0
        //
        // 这样最小化窗口时就不会保留圆角。
        public int WindowRadius
        {
            get => _window.WindowState == WindowState.Maximized ? 0 : _windowRadius;


            set
            {
                _windowRadius = value;
            }
        }

        public CornerRadius WindowCornerRadius
        {
            get => new CornerRadius(WindowRadius);
        }

        public int TitleHeight { get; set; } = 35;

        public GridLength TitleHeightGridLength
        {
            get => new GridLength(TitleHeight + ResizeBorder);
        }

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;
        #endregion

        #region 构造器

        // 创建 WindowViewModel 对象时，
        // 必须传入一个 Window 对象
        //
        // MainWindow 中：
        //
        // this.DataContext = new WindowViewModel(this);
        //
        // 这里的 this 就是 MainWindow
        public WindowViewModel(Window window)
        {
            _window = window;
            //监听窗口大小变化事件
            _window.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };
            //创建Command实例
            MinimizeWindowCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
            MaximizeWindowCommand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
            CloseWindowCommand = new RelayCommand(() => _window.Close());
            MenuWindowCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_window,
                new Point(Mouse.GetPosition(_window).X + _window.Left, Mouse.GetPosition(_window).Y + _window.Top)));
            var resizer = new WindowResizer(_window);

            // Listen out for dock changes
            resizer.WindowDockChanged += (dock) =>
            {
                // Store last position
                _dockPosition = dock;

                // Fire off resize events
                WindowResized();
            };
        }

        #endregion
        #region Commands
        /// <summary>
        /// 最小化窗口
        /// </summary>
        public ICommand MinimizeWindowCommand { get; set; }
        /// <summary>
        /// 最大化窗口
        /// </summary>
        public ICommand MaximizeWindowCommand { get; set; }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        public ICommand CloseWindowCommand { get; set; }
        /// <summary>
        /// 菜单窗口
        /// </summary>
        public ICommand MenuWindowCommand { get; set; }

        #endregion
        #region Private Helper

        private void WindowResized()
        {
            // Fire off events for all properties that are affected by a resize
            OnPropertyChanged(nameof(Borderless));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }
        #endregion
    }
}
