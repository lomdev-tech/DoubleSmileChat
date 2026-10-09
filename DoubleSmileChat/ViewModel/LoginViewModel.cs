using DoubleSmileChat.Models;
using DoubleSmileChat.Security;
using DoubleSmileChat.ViewModel.Base;
using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DoubleSmileChat.ViewModel
{
    /// <summary>
    /// 登陆界面的视图模型
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region 私有成员

        #endregion

        #region 公共属性
        /// <summary>
        /// 用户的邮箱地址
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 用户的密码
        /// </summary>
        public SecureString Password { get; set; }
        /// <summary>
        /// 是否正在执行登录操作
        /// </summary>
        public bool LoginIsRunning { get; set; }
        #endregion

        #region 指令
        /// <summary>
        /// 登录命令
        /// </summary>
        public ICommand LoginCommand { get; set; }

        #endregion

        #region 构造器

       
        public LoginViewModel()
        {

            //创建Command实例
            LoginCommand = new RelayParamaterizedCommand(async (parameter) => await Login(parameter));
            
        }
        #endregion

        #region 方法
        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="parameter">视图中传入的<see cref="SecureString"/>用户密码</param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning)
                var email = this.Email?.Trim();
                var password = (parameter as IHavePassword).SecurePassword.UnSecure();
           
        #endregion


        #region Private Helper


        #endregion


    }
}
