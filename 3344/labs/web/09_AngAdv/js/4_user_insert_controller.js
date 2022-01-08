
myApp.controller('userInsertController', function ($scope, $http) {
    console.log("userInsertController running");
    // When the user first clicks insert, they will see the person_insert_update.html partial 
    // and at that time, all the user data fields should have empty string (not undefined) 
    // and there is a second person object that holds all the field level error messages - 
    // clear all of those out too... 

    // private function can be used only in here... 

    function emptyUser() {
        return {
            userEmail: "",
            userPassword: "",
            birthday: "",
            membershipFee: "",
            errorMsg: ""
        };
    }
    /* The field names from the JSON of the Web API (use same names in JS):
     "webUserId": "1",
     "userEmail": "donald.j.otto@temple.edu",
     "userPassword": "p@ssw0rd",
     "birthday": "03/24/1994",
     "membershipFee": "$2,500.00",
     "errorMsg": ""
     */


    // set the initial values of the new user that will show in the UI: userInsert.html (partial)
    $scope.newUser = emptyUser();

    // set the initial values of the field level error messages that will show in the UI: userInsert.html (partial)
    $scope.errors = emptyUser();

    //Create a new person (this is the Insert/Save button)
    $scope.insertSave = function () {
        console.log("user insertSave function running. Ready to try to insert this user (see next line)");
        console.log($scope.newUser);

        var newData = escape(JSON.stringify($scope.newUser));
        var url = "webAPIs/insertUserAPI.jsp?jsonData=" + newData;
        console.log("ready to make AJAX call with this url: " + url);

        $http.get(url).then(
                function (response) { // this function will run if http.get success
                    console.log("Insert user API ajax call - success");
                    console.log(response);
                    console.log("");
                    $scope.errors = response.data;
                    if ($scope.errors.errorMsg.length === 0) {
                        $scope.errors.errorMsg = "User " + $scope.newUser.userEmail + " sucessfully saved.";
                    }
                },
                function (response) { // this function will run if http.get error
                    console.log("Insert user API ajax call - failed");
                    console.log(response);
                    console.log("");
                    $scope.errors.errorMsg = "Error: " + response.status + " " + response.statusText;

                } // end of error fn

        ); // closes off "then" function call

    }; // end of function insertSave

}); // end of insert controller


