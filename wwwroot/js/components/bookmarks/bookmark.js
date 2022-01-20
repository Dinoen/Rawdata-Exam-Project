
define(['knockout', 'postman','bookmarkService', 'viewmodel','movieService','actorService'], function (ko, postman, bs, vm, ms, as) {
    return function (params) {

        let token = ko.observable('');
        let userName = ko.observable('');
        let uconst = ko.observable('');

        let loggedInUser = ko.observable('');



        token(vm.bearerToken());
        userName(vm.userName());
        uconst(vm.uconst());
        loggedInUser(vm.loggedInUser());


        let bookmarks = ko.observableArray([]);
        let actorbookmarks = ko.observableArray([]);

        let deltitle = title => {
            bookmarks.remove(title);
            console.log(title.tconst)
            bs.deleteTitleBookmark(title, uconst, title.tconst);
        }

        let navigateToMovie = title => {
            let ltitle = ko.observable('');
            vm.curTitle(title);
            ms.getMovieByTconst(ltitle, title.tconst);
            ltitle.subscribe(function() {
              vm.activeView('details');
            });
        }

        let navigateToActor = actor => {
          let lactor = ko.observable('');
          vm.currentactor(actor);
          as.getActorByNconst(lactor, actor.nconst);
          lactor.subscribe(function() {
            vm.activeView('singleActor');
          });
        }

        let delactor = actor => {
          actorbookmarks.remove(actor);
          // console.log(actor)
          bs.deleteActorBookmark(actor.uconst, actor.nconst);
        }

        bs.getBookmarks(bookmarks);
        bs.getActorBookmarks(actorbookmarks);


        let goToTitleDetails = titleItem => {
            vm.curTitle(titleItem);
            vm.activeView('details');
        };




        return {

            bookmarks,
            deltitle,
            actorbookmarks,
            delactor,
            token,
            userName,
            uconst,
            loggedInUser,
            goToTitleDetails,
            navigateToActor,
            navigateToMovie
        };
    };
});
