(function(angular) {
  "use strict";

  angular.module("emanage.user").component("userEditor", {
    templateUrl: "app/modules/user/components/user-editor/user-editor.html",
    controller: editUserController,
    controllerAs: "$ctrl",
    bindings: {
      user: "<",
      onSubmit: "&"
    }
  });

  function editUserController() {
    var ctrl = this;
    ctrl.submitForm = submit;

    function submit(isValid, user) {
      if (isValid) {
        var retVal = { isValid: isValid, user: user };
        ctrl.onSubmit({ result: retVal });
      }
    }
  }
})(window.angular);
