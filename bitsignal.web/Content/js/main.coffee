
window.RegisterController = ($scope, $http) ->
	$scope.register = (user) ->
		$http.post('Register', user).
		success((data, status) ->
			console.log data).
		error((data, status) ->
			console.log data)
	
	