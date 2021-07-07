using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace Panosen.WxMini.Api.MSTest
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        public async Task TestMethod()
        {
            var services = new ServiceCollection();
            services.AddHttpClient();
            services.AddSingleton<JscodeToSession>();
            services.AddSingleton(new WechatOptions
            {
                AppId = "",
                AppSecret = ""
            });

            var serviceProvider = services.BuildServiceProvider();

            var jscodeToSession = serviceProvider.GetRequiredService<JscodeToSession>();

            var response = await jscodeToSession.FetchSessionAsync("");

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.OpenId);
            Assert.IsNotNull(response.SessionKey);
        }
    }
}
