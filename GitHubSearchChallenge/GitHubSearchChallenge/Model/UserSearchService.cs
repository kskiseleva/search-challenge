using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace GitHubSearchChallenge.Model
{
    public interface IUserSearchService
    {
        Task<UserSearchResult> GetUserSearchResults(string keyword, int pageSize, int currentPage);
        int GetNumberOfPages(int totalResults, int pageSize);
    }

    public class UserSearchService : IUserSearchService
    {
        public UserSearchService()
        {

        }

        public async Task<UserSearchResult> GetUserSearchResults(string keyword, int pageSize, int currentPage)
        {
            HttpClient client = new HttpClient();
            var searchUrl = $"https://api.github.com/search/users?q={keyword}&per_page={pageSize}&page={currentPage}";
            var searchRequest = new Uri(searchUrl);

            client.DefaultRequestHeaders.UserAgent.TryParseAdd("GitHubUserSearchRequest");

            string response = await (await client.GetAsync(searchRequest)).Content.ReadAsStringAsync();

            UserSearchResult searchResult = JsonConvert.DeserializeObject<UserSearchResult>(response);

            foreach(User user in searchResult.Items)
            {
                searchUrl = $"https://api.github.com/users/{user.Login}";
                searchRequest = new Uri(searchUrl);

                response = await (await client.GetAsync(searchRequest)).Content.ReadAsStringAsync();

                User searchResult2 = JsonConvert.DeserializeObject<User>(response);

                user.Followers = searchResult2.Followers;
                user.Bio = searchResult2.Bio;

            }

            return searchResult;
        }

        public int GetNumberOfPages(int totalResults, int pageSize)
        {
            int NumberOfPages = 1;

            if (pageSize > 0)
            {
                NumberOfPages = totalResults / pageSize;
                if (totalResults % pageSize > 0)
                    NumberOfPages++;
            }

            return NumberOfPages;
        }
    }
}
