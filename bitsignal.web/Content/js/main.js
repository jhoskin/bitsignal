(function() {

  window.RegisterController = function($scope, $http) {
    return $scope.register = function(user) {
      return $http.post('Register', user).success(function(data, status) {
        return console.log(data);
      }).error(function(data, status) {
        return console.log(data);
      });
    };
  };

}).call(this);
