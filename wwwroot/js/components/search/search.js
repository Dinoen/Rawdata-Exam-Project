define(['knockout', 'postman','viewmodel','searchService'], function (ko, postman, vm, ss) {
    return function (params) {
        
        let searchResults = ko.observableArray([]);

        let simpleSearch = (query) => {

            ss.simpleSearch(query, searchResults)

        }
        
        return {
           simpleSearch
        }
    };
});