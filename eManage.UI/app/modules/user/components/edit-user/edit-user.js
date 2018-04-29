(function(angular) {
  "use strict";

  angular.module("emanage.user").component("editUser", {
    templateUrl: "app/modules/user/components/edit-user/edit-user.html",
    controller: newUserController,
    controllerAs: "$ctrl",
    bindings:{
      user:'<'
    }
  });

  newUserController.$inject = ["userService","$state"];
  function newUserController(userService,$state) {
    var ctrl = this;

    ctrl.$onInit = onInit;
    ctrl.edit = editUser;

    /**
     * Hook for the onInit function
     */
    function onInit() {
       
    }

    /**
     * Edit the user
     */
    function editUser(result) {
      if (result.isValid)
        userService.put(result.user).then(function(){
            $state.go('userDetail', {id: ctrl.user.id});
        })
    }
  }
})(window.angular);
