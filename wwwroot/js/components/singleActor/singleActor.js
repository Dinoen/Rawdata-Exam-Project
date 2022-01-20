define(['knockout', 'postman','viewmodel','actorService', 'movieService'], function (ko, postman, vm, as, ms) {
    return function (params) {
        // console.log(vm.currentactor().nconst);
        // console.log(vm.currentactor());

        let actornconst = vm.currentactor().nconst;
        let actorToBeShown = ko.observableArray([]);
        let actorProfessions = ko.observableArray([]);
        let actorTitles = ko.observableArray([]);

        as.getActorByNconst(actorToBeShown, actornconst);

        let getProfessions = (callback, actor) => {
          callback(actor().primaryprofession.split(','));
        };

        let getTitles = (callback, actor) => {
          let titles = [];
          actor().knownfortitles.split(',').forEach((tconst, index, array) => {
            let title = ko.observableArray([]);
            ms.getMovieByTconst(title, tconst);
            title.subscribe(function() {
              if (title().primarytitle) { // Validate that the title was found and has data
                titles.push(title());
                if (index === array.length - 1) {
                  // Return if it's the last item
                  callback(titles);
                }
              }
            });
          });
        }

        let goToTitleDetails = titleItem => {
          vm.curTitle(titleItem);
          vm.activeView('details');
        };

        actorToBeShown.subscribe(function() {
          getProfessions(actorProfessions, actorToBeShown);
          getTitles(actorTitles, actorToBeShown);
        });

        return {
            actorToBeShown,
            actorProfessions,
            actorTitles,
            goToTitleDetails
        }
    };
});
