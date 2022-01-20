using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Raw5MovieDb_WebApi.Model;
using Raw5MovieDb_WebApi.Services;
using Raw5MovieDb_WebApi.ViewModels;

namespace Raw5MovieDb_WebApi.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public GenreController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all genres
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet(Name = nameof(GetGenres))]
        public IActionResult GetGenres([FromQuery] QueryString queryString)
        {
            IList<Genre> genres = _dataService.GetGenres(queryString);
            var model = genres.Select(GetGenreViewModel);
            var response = CreateResponseObj(model, queryString, _dataService.GenresCount());
            return Ok(response);
        }

        /// <summary>
        /// Returns a single genre
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{genreId}", Name = nameof(GetGenre))]
        public IActionResult GetGenre(int genreId)
        {
            Genre genre = _dataService.GetGenre(genreId);

            if (genre == null)
            {
                return NotFound();
            }

            var model = GetGenreViewModel(genre);
            return Ok(model);
        }

        /// <summary>
        /// Returns all titles matching a given genre
        /// </summary>
        /// <param name="genreId"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{genreId}/titles", Name = nameof(GetTitlesByGenre))]
        public IActionResult GetTitlesByGenre(int genreId, [FromQuery] QueryString queryString)
        {
            IList<Title> titles = _dataService.GetTitlesByGenre(genreId, queryString);
            var model = titles.Select(GetTitleViewModel);
            var response = CreateTitlesResponseObj(genreId, model, queryString, _dataService.TitlesByGenreCount(genreId));
            return Ok(response);
        }

        /*
         *
         * Helper methods
         *
         */

        private object CreateResponseObj(IEnumerable<GenreViewModel> model, QueryString queryString, int total)
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

        private object CreateTitlesResponseObj(int genreId, IEnumerable<TitleViewModel> model, QueryString queryString, int total)
        {
            return new
            {
                total,
                previousPage = CreateTitlePreviousPageLink(genreId, queryString),
                currentPage = CreateTitleCurrentPageLink(genreId, queryString),
                nextPage = CreateTitleNextPageLink(genreId, queryString, total),
                results = model
            };
        }

        private string CreateTitleNextPageLink(int genreId, QueryString queryString, int total)
        {
            var lastPage = GetLastPage(queryString.PageSize, total);
            return queryString.Page >= lastPage ? null : GetTitlesUrl(genreId, queryString.Page + 1, queryString.PageSize);
        }

        private string CreateTitleCurrentPageLink(int genreId, QueryString queryString)
        {
            return GetTitlesUrl(genreId, queryString.Page, queryString.PageSize);
        }

        private string CreateTitlePreviousPageLink(int genreId, QueryString queryString)
        {
            return queryString.Page <= 0 ? null : GetTitlesUrl(genreId, queryString.Page - 1, queryString.PageSize);
        }

        private string GetTitlesUrl(int genreId, int page = 0, int pageSize = 25)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetTitlesByGenre), new { genreId = genreId, page, pageSize });
        }

        private static int GetTitleLastPage(int pageSize, int total)
        {
            return (int)Math.Ceiling(total / (double)pageSize) - 1;
        }

        private string CreateNextPageLink(QueryString queryString, int total)
        {
            var lastPage = GetLastPage(queryString.PageSize, total);
            return queryString.Page >= lastPage ? null : GetGenresUrl(queryString.Page + 1, queryString.PageSize);
        }

        private string CreateCurrentPageLink(QueryString queryString)
        {
            return GetGenresUrl(queryString.Page, queryString.PageSize);
        }

        private string CreatePreviousPageLink(QueryString queryString)
        {
            return queryString.Page <= 0 ? null : GetGenresUrl(queryString.Page - 1, queryString.PageSize);
        }

        private static int GetLastPage(int pageSize, int total)
        {
            return (int)Math.Ceiling(total / (double)pageSize) - 1;
        }

        private GenreViewModel GetGenreViewModel(Genre genre)
        {
            var model = _mapper.Map<GenreViewModel>(genre);
            model.Url = GetGenreUrl(genre);
            model.Titles = GetTitlesUrl(genre.Id);
            return model;
        }

        private TitleViewModel GetTitleViewModel(Title title)
        {
            var model = _mapper.Map<TitleViewModel>(title);
            model.Url = GetTitleUrl(title);
            model.Actors = GetTitleActorsUrl(title);
            return model;
        }

        private string GetTitleActorsUrl(Title title)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(TitleController.GetTitleActors), new { Tconst = title.Tconst.TrimEnd() });
        }

        private string GetTitleUrl(Title title)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(TitleController.GetTitle), new { Tconst = title.Tconst.TrimEnd() });
        }

        private string GetGenresUrl(int page, int pageSize)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetGenres), new { page, pageSize });
        }

        private string GetGenreUrl(Genre genre)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetGenre), new { GenreId = genre.Id });
        }
    }
}
