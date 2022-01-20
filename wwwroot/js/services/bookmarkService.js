
define(['viewmodel'], function (vm)  {

    let getBookmarks = (callback) => {
        let param = {
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + vm.bearerToken()
            }
        }
        fetch("/api/Bookmark/TitleBookmark/1", param)
            .then(response => response.json())
            .then(json => callback(json));

    };


    let deleteTitleBookmark = (uconst, tconst) => {
        let param = {
            method: "DELETE",
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + vm.bearerToken()

            }

        }
        fetch(`api/Bookmark/TitleBookmark?uconst=${uconst}&tconst=${tconst}`, param)
            .then(response => console.log(response.status))
    };

    let addTitleBookmark = (uconst, tconst ) => {
        let param = {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + vm.bearerToken()
            }
        }
        fetch(`api/Bookmark/TitleBookmark?uconst=${uconst}&tconst=${tconst}`, param)
            .then(response => console.log(response.status))
    };


    let getActorBookmarks = (callback) => {
        let param = {
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + vm.bearerToken()
            }
        }
        fetch("/api/Bookmark/ActorBookmark/1", param)
            .then(response => response.json())
            .then(json => callback(json));

    };
    

    let deleteActorBookmark = (uconst, nconst) => {
      let param = {
          method: "DELETE",
          headers: {
              "Content-Type": "application/json",
              'Authorization': 'Bearer ' + vm.bearerToken()

          }

      }
      fetch(`api/Bookmark/ActorBookmark?uconst=${uconst}&nconst=${nconst}`, param)
          .then(response => console.log(response.status))
  };


    return {
        getBookmarks,
        deleteTitleBookmark,
        getActorBookmarks,
        deleteActorBookmark,
        addTitleBookmark
    }
});
