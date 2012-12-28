define ['marionette'], ->

	class RegisterModel extends Backbone.Model
		defaults:
			"username": ""
			"password": ""
			"email": ""
	
	class RegisterView extends Backbone.Marionette.ItemView
		template: "#registerTmpl"

	$ ->
		app = new Backbone.Marionette.Application
		app.addRegions 
			registerRegion: '#register'

		app.registerRegion.show new RegisterView(model: new RegisterModel)