(function() {
  var mod;

  mod = angular.module('bitsignal', []);

  mod.controller('registerController', function($scope, $http) {
    return $scope.register = function(user) {
      return $http.post('register', user).success(function(data, status) {
        return console.log(data);
      }).error(function(data, status) {
        return console.log(data);
      });
    };
  });

  mod.controller('loginController', function($scope, $http) {
    return $scope.login = function(user) {
      return $http.post('auth/credentials', user).success(function(data, status) {
        return console.log(data);
      }).error(function(data, status) {
        return console.log(data);
      });
    };
  });

}).call(this);
