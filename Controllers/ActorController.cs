using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Raw5MovieDb_WebApi.Model;
using Raw5MovieDb_WebApi.Services;
using Raw5MovieDb_WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raw5MovieDb_WebApi.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorController : Controller
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public ActorController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all actors
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet(Name = nameof(GetActors))]
        public IActionResult GetActors([FromQuery] QueryString queryString)
        {
            IList<Actor> actors = _dataService.GetActors(queryString);
            var model = actors.Select(GetActorViewModel);
            var response = CreateResponseObj(model, queryString, _dataService.ActorsCount());
            return Ok(response);
        }

        /// <summary>
        /// Return a single actor
        /// </summary>
        /// <param name="nconst"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{nconst}", Name = nameof(GetActor))]
        public IActionResult GetActor(string nconst)
        {
            Actor actor = _dataService.GetActor(nconst);

            if (actor == null)
            {
                return NotFound();
            }

            var model = GetActorViewModel(actor);
            return Ok(model);
        }

        /// <summary>
        /// Returns a list of actors who have previously worked with the given actor
        /// </summary>
        /// <param name="actorname"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("coplayers/{actorname}")]
        public IActionResult GetActorCoPlayers(string actorname)
        {
            IList<Actor> actors = _dataService.find_coplayers(actorname);
            var model = actors.Select(GetActorViewModel);
            return Ok(model);
        }

        /// <summary>
        /// Returns an actor matching a search query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("search")]
        public IActionResult FindActor([FromQuery] string query)
        {
            if (query == null || query == "")
            {
                return new EmptyResult();
            }

            IList<Actor> actors = _dataService.StructuredNameSearch(query);

            var model = actors.Select(GetActorViewModel);
            return Ok(model);
        }


        /*
         *
         * Helper methods
         *
         */

        private object CreateResponseObj(IEnumerable<ActorViewModel> model, QueryString queryString, int total)
        {
            return new
            {
                total,
                previousPage = CreatePreviousPageLink(queryString),
                currentPage = CreateCurrentPageLink(queryString),
                nextPage = CreateNextPageLink(queryString, total),
                results = model
            };
        }

        private string CreateNextPageLink(QueryString queryString, int total)
        {
            var lastPage = GetLastPage(queryString.PageSize, total);
            return queryString.Page >= lastPage ? null : GetActorsUrl(queryString.Page + 1, queryString.PageSize);
        }

        private string CreateCurrentPageLink(QueryString queryString)
        {
            return GetActorsUrl(queryString.Page, queryString.PageSize);
        }

        private string CreatePreviousPageLink(QueryString queryString)
        {
            return queryString.Page <= 0 ? null : GetActorsUrl(queryString.Page - 1, queryString.PageSize);
        }

        private string GetActorsUrl(int page, int pageSize)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetActors), new { page, pageSize });
        }

        private static int GetLastPage(int pageSize, int total)
        {
            return (int)Math.Ceiling(total / (double)pageSize) - 1;
        }

        private ActorViewModel GetActorViewModel(Actor actor)
        {
            var model = _mapper.Map<ActorViewModel>(actor);
            model.Url = GetUrl(actor);
            return model;
        }

        private string GetUrl(Actor actor)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetActor), new { Nconst = actor.Nconst.TrimEnd() });
        }
    }
}
