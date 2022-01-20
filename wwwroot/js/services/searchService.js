define(["viewmodel"], function (vm) {

    let simpleSearch = (query, callback, token) => {
        console.log(token)
        let param = {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + token
            }
        }
        fetch(`api/titles/search?query=${query}`, param)
            .then(response => response.json())
            .then(json => callback(json))

    };
        

    return {
       simpleSearch
    }
});
// let param = {
//     method: "POST",
//     headers: {
//         "Content-Type": "application/json",
//         'Authorization': 'Bearer ' + vm.bearerToken()
//     }
// }
// fetch(`api/Bookmark/TitleBookmark?uconst=${uconst}&tconst=${tconst}`, param)