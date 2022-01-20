define(["viewmodel"], function (vm) {

    let getSearchHistory = (callback) => {
        let param = {
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + vm.bearerToken()
            }
        }

        fetch(`api/SearchHistory/${vm.loggedInUser().uconst}`, param)
            .then(response => response.json())
            .then(json => callback(json));
    };

    return {
        getSearchHistory
    }
});