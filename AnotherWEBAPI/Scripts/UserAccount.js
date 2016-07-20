// Definition of module
var app = angular.module('userAccountModule', []);

// Defining Controller and injecting UserAccountService
app.controller('demoCtrl', function ($scope, $http, UserAccountService) {

    $scope.usersData = null;
    // Fetching records from the factory created at the bottom of the script file
    UserAccountService.GetAllRecords().then(function (d) {
        $scope.usersData = d.data; // Success
    }, function () {
        alert('Error Occured !!!'); // Failed
    });

    $scope.UserAccount = {
        Id: '',
        Name: '',
        Address: '',
        Postal: '',
        Email: ''
    };

    // Reset UserAccount details
    $scope.clear = function () {
        $scope.UserAccount.Id = '';
        $scope.UserAccount.Name = '';
        $scope.UserAccount.Address = '';
        $scope.UserAccount.Postal = '';
        $scope.UserAccount.Email = '';
    }

    //Add New Item
    $scope.save = function () {
        if ($scope.UserAccount.Name != "") {

            $http({
                method: 'POST',
                url: 'api/UserAccount/',
                data: $scope.UserAccount
            }).then(function successCallback(response) {
                $scope.usersData.push(response.data);
                $scope.clear();
                alert("UserAccount Added Successfully !!!");
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Please Enter All the Values !!');
        }
    };

    // Edit UserAccount details
    $scope.edit = function (data) {
        $scope.UserAccount = { Id: data.Id, Name: data.Name, Address: data.Address, Postal: data.Postal, Email: data.Email };
    }

    // Cancel UserAccount details
    $scope.cancel = function () {
        $scope.clear();
    }

    // Update UserAccount details
    $scope.update = function () {
        if ($scope.UserAccount.Name != "") {
            $http({
                method: 'PUT',
                url: 'api/UserAccount/' + $scope.UserAccount.Id,
                data: $scope.UserAccount
            }).then(function successCallback(response) {
                $scope.usersData = response.data;
                $scope.clear();
                alert("UserAccount Updated Successfully !!!");
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Please Enter All the Values !!');
        }
    };

    // Delete UserAccount details
    $scope.delete = function (index) {
        $http({
            method: 'DELETE',
            url: 'api/UserAccount/' + $scope.usersData[index].Id,
        }).then(function successCallback(response) {
            $scope.usersData.splice(index, 1);
            alert("UserAccount Deleted Successfully !!!");
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });
    };

});

// Factory to create and configure services.
app.factory('UserAccountService', function ($http) {
    var fac = {};
    fac.GetAllRecords = function () {
        return $http.get('api/UserAccount/Get');
    }
    return fac;
});