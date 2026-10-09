using DoubleSmileChat.ViewModel;
using DoubleSmileChat.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoubleSmileChat.Pages
{
    /// <summary>
    /// LoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
    {
        #region 构造器
        public LoginPage()
        {
            InitializeComponent();
        }

       
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword;


    }
}
