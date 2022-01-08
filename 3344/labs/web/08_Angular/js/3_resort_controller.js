
// code that will run when the user clicks on the users link from the ng index page
// because of the rule for this link as defined in the routing_layout_app.js file.

// must include $scope and $http as parameters since we will be using both
myApp.controller('carController', function ($scope, $http)  {

    $http.get('webAPIs/carAPI.jsp').then(
            
            function (response) { // this function runs if ajax worked 
                console.log("ajax success - called webAPIs/carAPI.jsp (see response on next line)");
                console.log(response);
                console.log("");
                
                // this line of code makes 'users' (arry of user objects) available
                // to userContent.html (the UI that is associated with this controller). 
                $scope.carList = response.data.carList; 
                
            },
            function (response) { // this function runs if ajax call did not work.  -
                console.log("ajax error - unable to call webAPIs/carAPI.jsp (see response on next line)");
                console.log(response);
                console.log("");
            }
    );
    
    $scope.sortField = 'idSort';
    //$scope.reverse = true;

}); // end of def'n of the controller function 