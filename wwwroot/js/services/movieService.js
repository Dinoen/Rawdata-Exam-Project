define(['viewmodel'], function(vm) {
  let getMovies = (callback) => {
    let param = {
      headers: {
        "Content-Type": "application/json",
        'Authorization': 'Bearer ' + vm.bearerToken()
      }
    }
    fetch("api/titles?Page=10&PageSize=50", param)

      .then(response => response.json())
      .then(json => callback(json))
  };

  let getPopularTitles = (callback) => {
    let param = {
      headers: {
        "Content-Type": "application/json",
        'Authorization': 'Bearer ' + vm.bearerToken()
      }
    }
    fetch("api/titles/popular", param)
      .then(response => response.json())
      .then(json => callback(json))
  };

  let getAllGenres = (callback) => {
    let param = {
      headers: {
        "Content-Type": "application/json",
        'Authorization': 'Bearer ' + vm.bearerToken()
      }
    }
    fetch("api/genres?pageSize=30", param)
      .then(response => response.json())
      .then(json => callback(json))
  };

  let getTitlesFromGenre = (genreid, callback) => {
    let param = {
      headers: {
        "Content-Type": "application/json",
        'Authorization': 'Bearer ' + vm.bearerToken()
      }
    }
    fetch(`api/genres/${genreid}/titles`, param)
      .then(response => response.json())
      .then(json => callback(json))
  };

  let getTitlesFromUrl = (url, callback) => {
    let param = {
      headers: {
        "Content-Type": "application/json",
        'Authorization': 'Bearer ' + vm.bearerToken()
      }
    }
    fetch(url, param)
      .then(response => response.json())
      .then(json => callback(json))
  };

  let getMovieByTconst = (callback, tconst) => {
    let param = {
      headers: {
        "Content-Type": "application/json",
        'Authorization': 'Bearer ' + vm.bearerToken()
      }
    }
    fetch(`/api/titles/${tconst}`, param)
      .then(response => response.json())
      .then(json => callback(json))
  };


  let getTitle = (url, callback) => {
    let param = {
      headers: {
        "Content-Type": "application/json",
        'Authorization': 'Bearer ' + vm.bearerToken()
      }
    }
    fetch(url, param)
      .then(response => response.json())
      .then(json => callback(json))
  };

  let getTitleActors = (url, callback) => {
    let param = {
      headers: {
        "Content-Type": "application/json",
        'Authorization': 'Bearer ' + vm.bearerToken()
      }
    }
    fetch(url, param)
      .then(response => response.json())
      .then(json => callback(json))
  };

  return {
    getMovies,
    getPopularTitles,
    getAllGenres,
    getTitlesFromGenre,
    getTitle,
    getTitleActors,
    getTitlesFromUrl,
    getMovieByTconst
  }
});
