
window.RegisterController = ($scope, $http) ->
	$scope.register = (user) ->
		$http.post('Register', user)
	
	