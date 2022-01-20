define(['knockout', 'userService', 'viewmodel'], function (ko, us, vm) {
    return function (params) {

        let userName = ko.observable('')
        let email = ko.observable('')
        let password = ko.observable('')
        let birthdate = ko.observable('')
        let response = ko.observable('')

        let spinner = false;
        
        

        let registerUser = () => {
            show()
            us.registerUser(userName(), email(), birthdate(), password(), response)
            setTimeout(navigate, 2000)

        }

        let navigate = () => {
            if (response != '') {
                console.log(response())

                vm.activeView('login')
                hide()
            } else { console.log('error'); hide(); alert("An error occured: " + response); }
        }

        function show() {
            document.getElementById("loading").style.display = 'block';
            document.getElementById("loginbtn").style.display = 'none';
        }
        function hide() {
            document.getElementById("loading").style.display = 'none';
            document.getElementById("loginbtn").style.display = 'block';
        }

        function goBackToLogin(){
            vm.activeView('login')
        }



        return {
            registerUser,
            userName,
            password,
            spinner,
            email,
            birthdate,
            goBackToLogin

        };


    };
});