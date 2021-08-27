using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Github.Api.Pulls
{
    /// <summary>
    /// MergePullRequestResponse
    /// </summary>
    public class MergePullRequestResponse: Response
    {
        /// <summary>
        /// Sha
        /// </summary>
        [JsonProperty("sha")]
        public string Sha { get; set; }

        /// <summary>
        /// Merged
        /// </summary>
        [JsonProperty("merged")]
        public bool Merged { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    /// <summary>
    /// Response
    /// </summary>
    public abstract class Response
    {
        /// <summary>
        /// HttpStatusCode
        /// </summary>
        public int HttpStatusCode { get; set; }
    }
}
