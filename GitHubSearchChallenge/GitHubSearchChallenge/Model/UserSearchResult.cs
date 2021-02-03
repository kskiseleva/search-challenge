using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubSearchChallenge.Model
{
    public class UserSearchResult
    {
        public int Total_Count { get; set; }

        public bool Incomplete_Results { get; set; }

        public List<User> Items { get; set; }

        public UserSearchResult()
        {

        }
    }
}
