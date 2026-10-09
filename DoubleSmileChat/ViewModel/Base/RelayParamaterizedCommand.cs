using System;
using System.Windows.Input;

namespace DoubleSmileChat
{
    /// <summary>
    /// A basic command that runs an Action
    /// </summary>
    public class RelayParamaterizedCommand : ICommand
    {
        #region 私有成员

        /// <summary>
        /// The action to run
        /// </summary>
        private Action<object> mAction;

        #endregion

        #region 公共事件

        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region 构造器

        /// <summary>
        /// Default constructor
        /// </summary>
        public RelayParamaterizedCommand(Action<object> action)
        {
            mAction = action;
        }

        #endregion

        #region command方法

        /// <summary>
        /// A relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the commands Action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction(parameter);
        }

        #endregion
    }
}
