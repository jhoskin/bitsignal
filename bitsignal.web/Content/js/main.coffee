require.config
	paths :
		backbone : 'backbone.marionette/backbone'
		underscore : 'backbone.marionette/underscore'
		jquery : 'backbone.marionette/jquery'
		marionette : 'backbone.marionette/backbone.marionette'
	shim :
		jquery : 
			exports : 'jQuery'
		underscore :
			exports : '_'
		backbone :
			deps : ['jquery', 'underscore']
			exports : 'Backbone'
		marionette :
			deps : ['jquery', 'underscore', 'backbone']
			exports : 'Marionette'

require ['jquery','app'], ->
	
	