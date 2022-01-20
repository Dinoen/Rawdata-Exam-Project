define(["viewmodel"], function (vm) {

    let authenticate = (username, password, callback) => {
        let param = {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            }
        }
        fetch(`api/Authentication?username=${username}&password=${password}`, param)
            .then(response => response.json())
            .then(json => callback(json));
    };

    return {
        authenticate
    }
});