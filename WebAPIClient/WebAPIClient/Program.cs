using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Collections.Generic;

namespace WebAPIClient
{
    class Program
    {
        /// <summary>
        /// Create instance of HttpClient for use accessing .NET Foundation repos via GitHub API
        /// </summary>
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            var repositories = await ProcessRepositories();  // create a list of repository objects

            foreach (var repo in repositories)
            {
                Console.WriteLine(repo.Name);
                Console.WriteLine(repo.Description);
                Console.WriteLine(repo.GitHubHomeUrl);
                Console.WriteLine(repo.LastPush);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Task which returns a list of Repository objects as extracted from JSON
        /// </summary>
        /// <returns>List of Repository objects</returns>
        private static async Task<List<Repository>> ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();  // clear any accept headers already stored
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));  // add new accept header for Github media type JSON version 3 of the REST API
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");  // Add a User-Agent header to identify app making requests - required by GitHub

            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");  // sends GET request to Uri - return response as stream in async op
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask); // deserialise the stream into Repository objects (in List)
            return repositories;
        }
    }
}
