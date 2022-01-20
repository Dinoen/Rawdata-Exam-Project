/// <reference path="addcategory.js" />
define(['knockout', 'postman', 'movieService', 'bookmarkService'], function (ko, postman, ms, bs) {
    return function (params) {

        let movies = ko.observableArray([]);
        let bookmarks = ko.observableArray([]);

   



        ms.getMovies(movies);

        bs.getBookmarks(bookmarks)

        // postman.subscribe("newCategory", category => {
        //     ds.createCategory(category, newCategory => {
        //         categories.push(newCategory);
        //     });
        // }, "list-categories");

        return {
            categories,
            movies,
            bookmarks,
            del,
            create
        };
    };
});
