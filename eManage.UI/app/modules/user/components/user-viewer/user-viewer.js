(function(angular) {
    "use strict";
  
    angular.module("emanage.user").component("userViewer", {
      templateUrl: "app/modules/user/components/user-viewer/user-viewer.html",
      controller: angular.noop,
      controllerAs: "$ctrl",
      bindings: {
        user: "<"
      }
    });
  })(window.angular);
  