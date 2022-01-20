using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raw5MovieDb_WebApi.Model;
using Raw5MovieDb_WebApi.Services;

namespace Raw5MovieDb_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchHistoryController : Controller
    {
        private readonly IDataService _dataService;
        public SearchHistoryController(IDataService dataService)
        {
            _dataService = dataService;
        }

        /// <summary>
        /// Returns searchhistory for a single user
        /// </summary>
        /// <param name="uconst"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{uconst}")]
        public IActionResult GetSearchHistory(string uconst)
        {
            return Ok(_dataService.GetUserSearchHistory(uconst));
        }

        /// <summary>
        /// Adds a searchhistory entry in the database
        /// </summary>
        /// <param name="uconst"></param>
        /// <param name="searchParam"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public IActionResult CreateSearchHistoryEntry([FromBody] string uconst, string searchParam)
        {   
            UserSearchHistory searchHistory = new UserSearchHistory
            {
                SearchId = 0,
                Uconst = uconst,
                Query = searchParam
            };

            try
            {
                return Ok(_dataService.AddUserSearchHistory(searchHistory));
            }
            catch (System.Exception)
            {
                return NotFound($"There is no user corresponding to {uconst}");
            }
        }
    }
}