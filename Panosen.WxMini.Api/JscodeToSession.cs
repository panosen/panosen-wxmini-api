using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Panosen.WxMini.Api
{
    /// <summary>
    /// 登录凭证校验。通过 wx.login 接口获得临时登录凭证 code 后传到开发者服务器调用此接口完成登录流程。
    /// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/login/auth.code2Session.html
    /// </summary>
    public class JscodeToSession
    {
        private const string Host = "https://api.weixin.qq.com/sns/jscode2session";

        private readonly IHttpClientFactory httpClientFactory;
        private readonly WechatOptions options;

        /// <summary>
        /// JscodeToSession
        /// </summary>
        /// <param name="httpClientFactory"></param>
        /// <param name="options"></param>
        public JscodeToSession(IHttpClientFactory httpClientFactory, IOptions<WechatOptions> options)
        {
            this.httpClientFactory = httpClientFactory;
            this.options = options.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsCode"></param>
        /// <returns></returns>
        public async Task<JscodeToSessionResponse> FetchSessionAsync(string jsCode)
        {
            var path = $"{Host}?appid={options.AppId}&secret={options.AppSecret}&js_code={jsCode}&grant_type=authorization_code";

            var httpClient = httpClientFactory.CreateClient();
            var response = await httpClient.GetStringAsync(path);
            if (string.IsNullOrEmpty(response))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<JscodeToSessionResponse>(response);
        }
    }
}
