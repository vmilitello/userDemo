(function(angular) {
    'use strict';

    angular
        .module('emanage.user')
        .component('userList', {
            templateUrl:'/app/modules/user/components/user-list/user-list.html',
            controller: angular.noop,
            controllerAs: '$ctrl',
            bindings:{
                users:'<'
            }
        });
})(window.angular);

