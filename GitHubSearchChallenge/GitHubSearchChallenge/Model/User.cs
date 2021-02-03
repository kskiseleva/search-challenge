using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubSearchChallenge.Model
{
    public class User
    {
        [Display(Name = "Username")]
        public string Login { get; set; }

        public int ID { get; set; }

        public string Node_ID { get; set; }

        [Display(Name = "Profile Image")]
        public string Avatar_Url { get; set; }

        public string Gravatar_ID { get; set; }

        public string Url { get; set; }

        public string Html_Url { get; set; }

        public string Followers_Url { get; set; }

        public string Following_Url { get; set; }

        public string Gists_Url { get; set; }

        public string Starred_Url { get; set; }

        public string Subscriptions_Url { get; set; }

        public string Organizations_Url { get; set; }

        public string Repos_Url { get; set; }

        public string Events_Url { get; set; }

        public string Received_Events_Url { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }

        public bool Site_Admin { get; set; }

        [Display(Name = "Score")]
        public double Score { get; set; }

        [Display(Name = "Followers")]
        public int Followers { get; set; }

        [Display(Name = "Description")]
        public string Bio { get; set; }
    }
}
