using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raw5MovieDb_WebApi.Model;
using Raw5MovieDb_WebApi.Services;

namespace Raw5MovieDb_WebApi.Controllers
{
    [ApiController]
    [Route("api/rating")]
    public class RatingController : ControllerBase
    {
        private readonly IDataService _dataService;
        public RatingController(IDataService dataService)
        {
            _dataService = dataService;
        }

        /// <summary>
        /// Returns all Title ratings from a single user
        /// </summary>
        /// <param name="uconst"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{uconst}")]
        public IActionResult GetAllUserRatings(string uconst)
        {
            return Ok(_dataService.GetAllUserRatings(uconst));
        }

        /// <summary>
        /// Return user rating for a single title
        /// </summary>
        /// <param name="uconst"></param>
        /// <param name="tconst"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetUserTitleRating([FromQuery] string uconst, string tconst)
        {
            return Ok(_dataService.GetTitleRating(uconst, tconst));
        }


        /// <summary>
        /// Adds a new userrating to a title
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public IActionResult CreateUserRating([FromBody] UserRating rating)
        {
            try
            {
                if (_dataService.CreateTitleRating(rating.Rating, rating.Tconst, rating.Uconst))
                {
                    return Ok("Rating Created");
                }
                else return BadRequest("A rating for this title already exist");
            }
            catch (System.Exception)
            {
                return NotFound($"Rating not created");
            }
        }

        /// <summary>
        /// Updates a single user rating
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        public IActionResult UpdateUserRating([FromBody] UserRating rating)
        {
            try
            {
                if (_dataService.UpdateTitleRating(rating.Rating, rating.Tconst, rating.Uconst))
                {
                    return Ok("Rating Updated");
                }
                else return BadRequest("This title has not yet been rated");
            }
            catch (System.Exception)
            {
                return NotFound($"An unknow error occured");
            }
        }


    }
}