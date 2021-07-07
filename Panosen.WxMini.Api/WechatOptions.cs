using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.WxMini.Api
{
    /// <summary>
    /// 开发者ID
    /// </summary>
    public class WechatOptions
    {
        /// <summary>
        /// 小程序ID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 小程序密钥
        /// </summary>
        public string AppSecret { get; set; }
    }
}
