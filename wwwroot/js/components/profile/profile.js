define(['knockout', 'viewmodel', 'searchHistoryService', 'userService'], function (ko, vm, sh, us) {
    return function (params) {

        let loggedInUser = ko.observable('');
        let searchHistory = ko.observableArray([]);
        let editMode = ko.observable(false)
        let response = ko.observable('')

        loggedInUser(vm.loggedInUser());

        sh.getSearchHistory(searchHistory);

        let changeContent = menuItem => {
            console.group(menuItem)
            vm.activeView(menuItem.component)
        };

        function updateUser(){
            us.updateUser(loggedInUser().uconst, loggedInUser().userName, loggedInUser().email, loggedInUser().birthdate, loggedInUser().password,  logout)
            console.log(response())
            editMode(false)
        }
        
        function editUser(){
            if(editMode()){
                editMode(false);
            } else if(!editMode()){
                editMode(true)
            }
        }

        function logout(){
            vm.loggedInUser({})
            vm.activeView('login')
        }

        

        return {
            loggedInUser,
            searchHistory,
            editMode,
            editUser,
            updateUser,
            logout
        }
    };
})
