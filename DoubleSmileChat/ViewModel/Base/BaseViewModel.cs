using PropertyChanged;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DoubleSmileChat
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    [ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        //监听属性变化方法
        public void OnPropertyChanged(string name) 
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #region Command方法

        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            //检查是否正在运行
            if (updatingFlag.GetPropertyValue())
                return;
            updatingFlag.SetPropertyValue(true);
        }

        #endregion

    }




}
