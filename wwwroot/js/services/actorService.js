define(['viewmodel'], function (vm) {

    

    let getActors = (callback) => {
        let param = {
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + vm.bearerToken()
            }
        }
        fetch("api/actors?Page=10&PageSize=50", param)
            .then(response => response.json())
            .then(json => callback(json))

    };



    let getActorByNconst = (callback, nconst) => {
        let param = {
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + vm.bearerToken()
            }
        }
        fetch(`/api/actors/${nconst}`, param)
            .then(response => response.json())
            .then(json => callback(json))

    };

    return {
        getActors,
        getActorByNconst

    }
});
