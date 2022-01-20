define(['knockout', 'postman', 'viewmodel', 'movieService'], function (ko, postman, vm, ms) {
  return function (params) {
    let popularTitles = ko.observableArray([]);
    let allGenres = ko.observableArray([]);
    let titleCollections = ko.observableArray([]);
    ms.getPopularTitles(popularTitles);
    ms.getAllGenres(allGenres);

    let goToTitleDetails = titleItem => {
      vm.curTitle(titleItem);
      vm.activeView('details');
    };

    allGenres.subscribe(function() {
      // console.log(allGenres());
      allGenres().results.forEach(genre => {
        if (genre.id === 2) {
          return; // skip adult titles
        }
        let genreTitles = ko.observableArray([]);
        ms.getTitlesFromGenre(genre.id, genreTitles);
        genreTitles.subscribe(function() {
          // console.log(genreTitles());
          let newGenreTitles = genreTitles();
          newGenreTitles.genre = genre;
          titleCollections.push(newGenreTitles);
        });
      });
    });

    let loadPreviousTitlePage = (titleCollection) => {
      // console.log(titleCollection.nextPage);
      let newTitleCollection = ko.observableArray([]);
      ms.getTitlesFromUrl(titleCollection.previousPage, newTitleCollection);

      newTitleCollection.subscribe(function(tc) {
        allGenres().results.forEach(genre => {
          if (genre.id === titleCollection.genre.id) {
            let newTitleCollections = titleCollections();
            tc.genre = genre;
            titleCollections().forEach((collection, index) => {
              if (collection.genre.id === tc.genre.id) {
                newTitleCollections[index] = tc;
                titleCollections(newTitleCollections);
              }
            });
          }
        });
      });
    }

    let loadNextTitlePage = (titleCollection) => {
      // console.log(titleCollection.nextPage);
      let newTitleCollection = ko.observableArray([]);
      ms.getTitlesFromUrl(titleCollection.nextPage, newTitleCollection);

      newTitleCollection.subscribe(function(tc) {
        allGenres().results.forEach(genre => {
          if (genre.id === titleCollection.genre.id) {
            let newTitleCollections = titleCollections();
            tc.genre = genre;
            titleCollections().forEach((collection, index) => {
              if (collection.genre.id === tc.genre.id) {
                newTitleCollections[index] = tc;
                titleCollections(newTitleCollections);
              }
            });
          }
        });
      });
    }

    return {
      popularTitles,
      allGenres,
      titleCollections,
      goToTitleDetails,
      loadPreviousTitlePage,
      loadNextTitlePage
    };
  };
});
