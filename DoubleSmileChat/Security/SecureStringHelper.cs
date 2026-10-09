using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DoubleSmileChat.Security
{
    public static class SecureStringHelper
    {

        public static string UnSecure(this SecureString securePassword) 
        {
            //如果 SecureString 为 null，则返回空字符串
            if (securePassword == null) 
            {
                return string.Empty;
            }
            //将非托管内存中的 Unicode 字符串的指针初始化为零
            var unManagedString = IntPtr.Zero;
            try 
            {
                //将 SecureString 转换为非托管内存中的 Unicode 字符串
                unManagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                //返回非托管内存中的 Unicode 字符串
                return Marshal.PtrToStringUni(unManagedString);
            } 
            finally 
            {
                //释放非托管内存中的 Unicode 字符串
                Marshal.ZeroFreeGlobalAllocUnicode(unManagedString);
            }
        }
    }
}
