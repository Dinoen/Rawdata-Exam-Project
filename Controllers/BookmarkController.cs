using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Raw5MovieDb_WebApi.Model;
using Raw5MovieDb_WebApi.Services;

namespace Raw5MovieDb_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookmarkController : ControllerBase
    {
        private readonly IDataService _dataService;

        public BookmarkController(IDataService dataService)
        {
            _dataService = dataService;
        }

        /* ---------------------------  Title Bookmark --------------------------- */

        /// <summary>
        /// Returns all movie bookmarks for a single user
        /// </summary>
        /// <param name="uconst"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("TitleBookmark/{uconst}")]
        public IActionResult GetAllUserTitleBookmarks(string uconst)
        {
            IList<BookmarkTitle> TitleBookmarks = _dataService.GetAllTitleBookmarks(uconst);

            if (TitleBookmarks.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(TitleBookmarks);
            }
        }



        /// <summary>
        /// Adds a new title bookmark
        /// </summary>
        /// <param name="uconst"></param>
        /// <param name="tconst"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("TitleBookmark")]
        public IActionResult AddTitleBookmark([FromQuery] string uconst, string tconst)
        {
            try
            {
                return Created("", _dataService.AddTitleBookmark(tconst, uconst));
            }
            catch (System.Exception)
            {
                return NotFound($"There is no user corresponding to uconst: {uconst} or movie corresponding to {tconst}");
            }

        }

        /// <summary>
        /// Deletes a title bookmark
        /// </summary>
        /// <param name="uconst"></param>
        /// <param name="tconst"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("TitleBookmark")]
        public IActionResult DeleteTitleBookmark(string uconst, string tconst)
        {
            var result = _dataService.DeleteTitleBookmark(tconst, uconst);
            if (result)
            {
                return Ok($"{tconst} deleted succesfully");
            }
            else return NotFound();
        }

        /* ---------------------------  Actor Bookmark --------------------------- */


        /// <summary>
        /// Returns all actor bookmarks for a single user
        /// </summary>
        /// <param name="uconst"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("ActorBookmark/{uconst}")]
        public IActionResult GetAllUserActorBookmarks(string uconst)
        {
            IList<BookmarkActor> ActorBookmarks = _dataService.GetAllActorBookmarks(uconst);

            if (ActorBookmarks.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(ActorBookmarks);
            }
        }



        /// <summary>
        /// Adds a new actor bookmark
        /// </summary>
        /// <param name="uconst"></param>
        /// <param name="nconst"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("ActorBookmark")]
        public IActionResult AddActorBookmark([FromQuery] string nconst, string uconst)
        {
            
            try
            {
                return Ok(_dataService.AddActorBookmark(nconst, uconst));
            }
            catch (System.Exception)
            {
                return NotFound($"There is no user corresponding to {uconst} or actor corresponding to {nconst}");
            }

        }

        /// <summary>
        /// Deletes a title bookmark
        /// </summary>
        /// <param name="uconst"></param>
        /// <param name="nconst"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("ActorBookmark")]
        public IActionResult DeleteActorBookmark(string uconst, string nconst)
        {
            return Ok(_dataService.DeleteActorBookmark(uconst, nconst));
            // var result = _dataService.DeleteActorBookmark(nconst, uconst);
            // if (result)
            // {
            //     return Ok($"{nconst} deleted succesfully");
            // }
            // else return NotFound();
        }
    }
}