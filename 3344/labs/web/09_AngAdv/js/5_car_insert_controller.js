
myApp.controller('carInsertController', function ($scope, $http) {
    console.log("carInsertController running");
    // When the user first clicks insert, they will see the person_insert_update.html partial 
    // and at that time, all the user data fields should have empty string (not undefined) 
    // and there is a second person object that holds all the field level error messages - 
    // clear all of those out too... 

    // private function can be used only in here... 

    function emptyCar() {
        return {
            descriptor: "",
            urlImage: "",
            urlWeb: "",
            designDate: "",
            carRate:"",
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
    $scope.newCar = emptyCar();

    // set the initial values of the field level error messages that will show in the UI: userInsert.html (partial)
    $scope.errors = emptyCar();

    //Create a new person (this is the Insert/Save button)
    $scope.insertSave = function () {
        console.log("car insertSave function running. Ready to try to insert this car (see next line)");
        console.log($scope.newCar);

        var newData = escape(JSON.stringify($scope.newCar));
        var url = "webAPIs/insertCarAPI.jsp?jsonData=" + newData;
        console.log("ready to make AJAX call with this url: " + url);

        $http.get(url).then(
                function (response) { // this function will run if http.get success
                    console.log("Insert car API ajax call - success");
                    console.log(response);
                    console.log("");
                    $scope.errors = response.data;
                    if ($scope.errors.errorMsg.length === 0) {
                        $scope.errors.errorMsg = "Car " + $scope.newCar.descriptor + " sucessfully saved.";
                    }
                },
                function (response) { // this function will run if http.get error
                    console.log("Insert car API ajax call - failed");
                    console.log(response);
                    console.log("");
                    $scope.errors.errorMsg = "Error: " + response.status + " " + response.statusText;

                } // end of error fn

        ); // closes off "then" function call

    }; // end of function insertSave

}); // end of insert controller


