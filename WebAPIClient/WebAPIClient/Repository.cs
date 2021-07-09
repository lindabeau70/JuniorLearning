using System;
using System.Text.Json.Serialization;


namespace WebAPIClient
{
    /// <summary>
    /// Class to hold objects received via JSON - repos in this case
    /// </summary>
    public class Repository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }  

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("html_url")]
        public Uri GitHubHomeUrl { get; set; }

        [JsonPropertyName("homepage")]
        public Uri Homepage { get; set; }

        [JsonPropertyName("watchers")]
        public int Watchers { get; set; }  // apparently int and Uri have built in functionality to conver to/from string rep

        [JsonPropertyName("pushed_at")]
        public DateTime LastPushUtc { get; set; }       // is a UTC DateTime
        public DateTime LastPush => LastPushUtc.ToLocalTime();  // Convert to local time - note no setter (read-only) - this is a get statement
    }
}
