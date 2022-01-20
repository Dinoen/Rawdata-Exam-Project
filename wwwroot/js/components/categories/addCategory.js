define(['knockout', 'postman'], function (ko, postman) {
    return function (params) {

        let name = ko.observable();
        let description = ko.observable();

        let cancel = () => {
            postman.publish("changeView", "list-categories");
        }

        let add = () => {
            postman.publish("newCategory", { name: name(), description: description() });
            postman.publish("changeView", "list-categories");
        }

    

        let getCategories = (callback) => {
            fetch("api/categories")
                .then(response => response.json())
                .then(json => callback(json));
        };
    
        let deleteCategory = category => {
            fetch(category.url, { method: "DELETE" })
                .then(response => console.log(response.status))
        };
    
        let createCategory = (category, callback) => {
            let param = {
                method: "POST",
                body: JSON.stringify(category),
                headers: {
                    "Content-Type": "application/json"
                }
            }
            fetch("api/categories", param)
                .then(response => response.json())
                .then(json => callback(json));
        };

        
    };
});