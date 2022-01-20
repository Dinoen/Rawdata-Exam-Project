define(['knockout', 'postman', 'movieService','viewmodel'], function (ko, postman, ms, vm) {
    return function (params) {

        let movies = ko.observableArray([]);

        ms.getMovies(movies)


        let goToTitleDetails = titleItem => {
            vm.curTitle(titleItem);
            vm.activeView('details');
        };

        return {

            movies,
            goToTitleDetails

        };

        
    };
});