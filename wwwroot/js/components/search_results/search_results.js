define(['knockout', 'postman','viewmodel','searchService'], function (ko, postman, vm, ss) {
    return function (params) {

        let searchResults = ko.observableArray([]);

        function search() {
            ss.simpleSearch(vm.searchQuery(), searchResults, vm.bearerToken());
            searchResults.subscribe(() => {
                console.log(searchResults());
                vm.searchQuery('');
            });
        }

        search();

        let goToTitleDetails = titleItem => {
          vm.curTitle(titleItem);
          vm.activeView('details');
        };

        return {
            searchResults,
            goToTitleDetails
        }
    };
});
