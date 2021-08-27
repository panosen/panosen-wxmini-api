using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panosen.Github.Api.Pulls;
using System.Threading.Tasks;

namespace Panosen.Github.Api.MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod()
        {
            var services = new ServiceCollection();
            services.AddHttpClient();
            services.AddSingleton<MergePullRequest>();

            var serviceProvider = services.BuildServiceProvider();

            var mergePullRequest = serviceProvider.GetRequiredService<MergePullRequest>();

            var response = await mergePullRequest.CallApiAsync("harris2012", "probable-dollop", 1, new MergePullRequestRequest
            {
                CommitTitle = "title 1",
                CommitMessage = "message 1",
                MergeMethod = MergeMethod.Rebase
            });

            Assert.IsNotNull(response);
        }
    }
}
