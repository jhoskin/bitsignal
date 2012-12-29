mod = angular.module 'bitsignal', []

mod.controller 'registerController', ($scope, $http) ->
	$scope.register = (user) ->
		$http.post('register', user).
		success((data, status) ->
			console.log data).
		error((data, status) ->
			console.log data)
	
mod.controller 'loginController', ($scope, $http) ->
	$scope.login = (user) ->
		$http.post('auth/credentials', user).
		success((data, status) ->
			console.log data).
		error((data, status) ->
			console.log data)
	