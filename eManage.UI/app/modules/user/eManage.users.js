(function(angular) {
  "use strict";

  var app = angular.module("emanage.user", []);

  /*Used to set the domain endpoint of the API*/
  app.provider("$apiEndpoint", function() {
    var url;
    return {
      set: function(value) {
        url = value;
      },
      $get: function() {
        return url;
      }
    };
  });
 
})(window.angular);
