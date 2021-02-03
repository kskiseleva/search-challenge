using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using GitHubSearchChallenge.Model;
using System.ComponentModel.DataAnnotations;

namespace GitHubSearchChallenge.Pages
{
    public class UserSearchModel : PageModel
    {
        private readonly ILogger<UserSearchModel> _logger;
        private readonly IUserSearchService _userSearchService;

        public UserSearchModel(IUserSearchService userSearchService, ILogger<UserSearchModel> logger)
        {
            _userSearchService = userSearchService;
            _logger = logger;
        }

        [Required(ErrorMessage = "Keyword is required.")]
        [BindProperty(SupportsGet = true)]
        public string Keyword { get; set; }

        [Required(ErrorMessage = "Results Per Page selection is required.")]
        [BindProperty(SupportsGet = true)]
        public int ResultsPerPage { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public UserSearchResult SearchResult;

        [BindProperty(SupportsGet = true)]
        public int NumberOfPages { get; set; }

        public async Task OnGet()
        {
            if(!String.IsNullOrEmpty(Keyword))
            {
                SearchResult = await _userSearchService.GetUserSearchResults(Keyword, ResultsPerPage, CurrentPage);
                
                if(SearchResult.Total_Count > 1000)
                {
                    NumberOfPages = _userSearchService.GetNumberOfPages(1000, ResultsPerPage);
                }
                else
                {
                    NumberOfPages = _userSearchService.GetNumberOfPages(SearchResult.Total_Count, ResultsPerPage);
                }
            }
        }

        public async Task OnPost()
        {
            if (ModelState.IsValid)
            {
                SearchResult = await _userSearchService.GetUserSearchResults(Keyword, ResultsPerPage, CurrentPage);

                if (SearchResult.Total_Count > 1000)
                {
                    NumberOfPages = _userSearchService.GetNumberOfPages(1000, ResultsPerPage);
                }
                else
                {
                    NumberOfPages = _userSearchService.GetNumberOfPages(SearchResult.Total_Count, ResultsPerPage);
                }
            }
        }
    }
}
