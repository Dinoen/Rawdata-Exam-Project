define(["viewmodel"], function (vm) {

    let registerUser = (username, email, birthdate, password, callback) => {
        let param = {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            }
        }
        fetch(`api/User/Register?UserName=${username}&Email=${email}&Birthdate=${birthdate}&Password=${password}`, param)
            .then(response => response.json())
            .then(json => callback(json));
    };

    let updateUser = (uconst, username, email, birthdate, password, callback) => {
        let url = `api/User/Update?Uconst=${uconst}&UserName=${username}&Email=${email}&Birthdate=${birthdate}&Password=${password}`;
        let param = {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + vm.bearerToken()
            }
        }
        fetch(url, param) 
            .then(callback);
    };

    

    return {
        registerUser,
        updateUser
    }
});
