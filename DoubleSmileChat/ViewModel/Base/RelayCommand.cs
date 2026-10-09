using System;
using System.Windows.Input;

namespace DoubleSmileChat
{
    /// <summary>
    /// A basic command that runs an Action
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region 私有成员

        private Action mAction;

        #endregion

        #region 公共事件

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region 构造器

        /// <summary>
        /// 默认的构造器
        /// </summary>
        public RelayCommand(Action action)
        {
            mAction = action;
        }

        #endregion

        #region command方法

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }

        #endregion
    }
}
