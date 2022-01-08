var myApp = angular.module('myAppBody', ['ngRoute']);

myApp.config(function ($routeProvider) {
    $routeProvider.
            when('/', {
                templateUrl: 'htmlPartials/homeContent.html',
                controller: 'nullController'
            }).
            when('/home', {
                templateUrl: 'htmlPartials/homeContent.html',
                controller: 'nullController'
            }).
            when('/users', {
                templateUrl: 'htmlPartials/userContent.html',
                controller: 'userController'
            }).
            when('/resorts', {
                templateUrl: 'htmlPartials/resortContent.html',
                controller: 'carController'  // this not implemented yet
            }).
            when('/insertUser', {
                templateUrl: 'htmlPartials/userInsert.html',
                controller: 'userInsertController'  // this not implemented yet
            }).
            when('/insertCar', {
                templateUrl: 'htmlPartials/carInsert.html',
                controller: 'carInsertController'  // this not implemented yet
            }).
            otherwise({
                redirectTo: '/'
            });
});

// Each routing rule needs a controller, even if the controller doesn't do anything...
myApp.controller('nullController', function ( ) {
}); // end of def'n of the controller function 