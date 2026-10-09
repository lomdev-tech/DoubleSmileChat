using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleSmileChat.Animation
{
    public enum PageAnimation
    {
        /// <summary>
        /// 无动画
        /// </summary>
        None = 0,
        /// <summary>
        /// 滑入动画
        /// </summary>
        SlideAndFadeInFromRight = 1,
        /// <summary>
        /// 滑出动画
        /// </summary>
        SlideAndFadeOutToLeft = 2,
    }
}
