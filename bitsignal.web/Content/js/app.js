(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

  define(['marionette'], function() {
    var RegisterModel, RegisterView;
    RegisterModel = (function(_super) {

      __extends(RegisterModel, _super);

      function RegisterModel() {
        return RegisterModel.__super__.constructor.apply(this, arguments);
      }

      RegisterModel.prototype.defaults = {
        "username": "",
        "password": "",
        "email": ""
      };

      return RegisterModel;

    })(Backbone.Model);
    RegisterView = (function(_super) {

      __extends(RegisterView, _super);

      function RegisterView() {
        return RegisterView.__super__.constructor.apply(this, arguments);
      }

      RegisterView.prototype.template = "#registerTmpl";

      return RegisterView;

    })(Backbone.Marionette.ItemView);
    return $(function() {
      var app;
      app = new Backbone.Marionette.Application;
      app.addRegions({
        registerRegion: '#register'
      });
      return app.registerRegion.show(new RegisterView({
        model: new RegisterModel
      }));
    });
  });

}).call(this);
