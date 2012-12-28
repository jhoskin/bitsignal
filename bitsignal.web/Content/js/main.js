(function() {

  window.RegisterController = function($scope, $http) {
    return $scope.register = function(user) {
      return $http.post('Register', user);
    };
  };

}).call(this);
