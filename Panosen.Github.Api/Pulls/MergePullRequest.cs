using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Github.Api.Pulls
{
    /// <summary>
    /// https://docs.github.com/en/rest/reference/pulls#merge-a-pull-request
    /// </summary>
    public class MergePullRequest
    {
        private const string header = "application/vnd.github.v3+json";

        private const string host = "https://api.github.com";

        private readonly IHttpClientFactory httpClientFactory;

        /// <summary>
        /// MergePullRequest
        /// </summary>
        public MergePullRequest(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// CallApiAsync
        /// </summary>
        public async Task<MergePullRequestResponse> CallApiAsync(string owner, string repo, int pull_number, MergePullRequestRequest request)
        {
            var path = host + $"/repos/{owner}/{repo}/pulls/{pull_number}/merge";

            var httpClient = httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("Accppt", header);
            httpClient.DefaultRequestHeaders.Add("User-Agent", BuildUserAgent());

            string userName = "harris2012";
            string password = "e06d67d875e5b7088cb7a54d98a9d3c33162d77a";

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{userName}:{password}")));

            var content = JsonConvert.SerializeObject(request, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var httpResponse = await httpClient.PostAsync(path, new StringContent(content, Encoding.UTF8, "application/json"));

            var httpResponseContent = await httpResponse.Content.ReadAsStringAsync();

            MergePullRequestResponse response = JsonConvert.DeserializeObject<MergePullRequestResponse>(httpResponseContent);
            response.HttpStatusCode = (int)httpResponse.StatusCode;

            return response;
        }

        private string BuildUserAgent()
        {
            var items = new List<string>();
            items.Add(RuntimeInformation.OSDescription.Trim());
            items.Add(RuntimeInformation.OSArchitecture.ToString().ToLowerInvariant().Trim());
            items.Add(CultureInfo.CurrentCulture.Name);
            items.Add($"Panose {this.GetType().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion}");

            string value = $"HarrisApp ({string.Join("; ", items)})";
            return value;
        }
    }

    /// <summary>
    /// AcceptAttribute
    /// </summary>
    public class AcceptAttribute : Attribute
    {
        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// AcceptAttribute
        /// </summary>
        public AcceptAttribute(string value)
        {
            Value = value;
        }
    }
}
