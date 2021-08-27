using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.Github.Api.Pulls
{
    /// <summary>
    /// MergePullRequestRequest
    /// </summary>
    public class MergePullRequestRequest
    {
        /// <summary>
        /// Title for the automatic commit message.
        /// </summary>
        [JsonProperty("commit_title")]
        public string CommitTitle { get; set; }

        /// <summary>
        /// Extra detail to append to automatic commit message.
        /// </summary>
        [JsonProperty("commit_message")]
        public string CommitMessage { get; set; }

        /// <summary>
        /// SHA that pull request head must match to allow merge.
        /// </summary>
        [JsonProperty("sha")]
        public string Sha { get; set; }

        /// <summary>
        /// Merge method to use. Possible values are merge, squash or rebase. Default is merge.
        /// </summary>
        [JsonProperty("merge_method")]
        [JsonConverter(typeof(MergeMethodConverter))]
        public MergeMethod MergeMethod { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum MergeMethod
    {
        /// <summary>
        /// Keep Deafult
        /// </summary>
        None,

        /// <summary>
        /// merge
        /// </summary>
        Merge,

        /// <summary>
        /// squash
        /// </summary>
        Squash,

        /// <summary>
        /// rebase
        /// </summary>
        Rebase
    }

    /// <summary>
    /// MergeMethodConverter
    /// </summary>
    public class MergeMethodConverter : JsonConverter<MergeMethod>
    {
        /// <summary>
        /// ReadJson
        /// </summary>
        public override MergeMethod ReadJson(JsonReader reader, Type objectType, MergeMethod existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.ReadAsString();
            switch (value.ToLower())
            {
                case "merge":
                    return MergeMethod.Merge;
                case "squash":
                    return MergeMethod.Squash;
                case "rebase":
                    return MergeMethod.Rebase;
                default:
                    return MergeMethod.None;
            }
        }

        /// <summary>
        /// WriteJson
        /// </summary>
        public override void WriteJson(JsonWriter writer, MergeMethod value, JsonSerializer serializer)
        {
            switch (value)
            {
                case MergeMethod.Merge:
                    writer.WriteValue("merge");
                    break;
                case MergeMethod.Squash:
                    writer.WriteValue("squash");
                    break;
                case MergeMethod.Rebase:
                    writer.WriteValue("rebase");
                    break;
                case MergeMethod.None:
                default:
                    writer.WriteNull();
                    break;
            }
        }
    }
}
