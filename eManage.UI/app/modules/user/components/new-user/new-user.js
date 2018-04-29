(function(angular) {
  "use strict";

  angular.module("emanage.user").component("newUser", {
    templateUrl: "app/modules/user/components/new-user/new-user.html",
    controller: newUserController,
    controllerAs: "$ctrl"
  });

  newUserController.$inject = ["userService", "$state"];
  function newUserController(userService, $state) {
    var ctrl = this;

    ctrl.$onInit = onInit;
    ctrl.add = addUser;

    /**
     * Hook for the onInit function
     */
    function onInit() {
      ctrl.user = {
        name: null,
        age: null,
        address: null
      };
    }

    /**
     * Create the new user
     */
    function addUser(result) {
      if (result.isValid)
        userService.post(result.user).then(function(result){
          $state.go('userDetail', {id: result});
        });
    }
  }
})(window.angular);
