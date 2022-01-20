define(['knockout', 'authenticationService', 'viewmodel'], function (ko, as, vm) {
    return function (params) {

        let userName = ko.observable('JohnDoe')
        let password = ko.observable('123')
        let token = ko.observable('');

        let spinner = false;


        let login = () => {
            show()
            as.authenticate(userName(), password(), token)
            setTimeout(navigate, 1000)

        }
        let navigate = () => {
            if (token().token) {
                console.log(token())
                vm.bearerToken(token().token)
                vm.userName(token().userName)
                vm.uconst(token().uconst)
                vm.loggedInUser(token())
                vm.navigationBarVisible(true)

                vm.activeView('home')
                hide()
            } else { console.log('error'); hide(); alert("wrong username or password"); }
        }

        function show() {
            document.getElementById("loading").style.display = 'block';
            document.getElementById("loginbtn").style.display = 'none';

        }
        function hide() {
            document.getElementById("loading").style.display = 'none';
            document.getElementById("loginbtn").style.display = 'block';
        }

        function registerUser(){
            vm.activeView('register')
        }



        return {
            login,
            userName,
            password,
            token,
            spinner,
            registerUser

        };


    };
});
