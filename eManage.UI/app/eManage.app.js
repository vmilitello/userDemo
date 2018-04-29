"use strict";

var app = angular.module("eManage.app", ["ui.router", "emanage.user"]);

setStates.$inject = ["$stateProvider"];
function setStates($stateProvider) {
  var states = [
    {
      name: "userList",
      url: "/list",
      template: '<user-list users="$resolve.users"></user-list>',
      resolve: {
        users: [
          "userService",
          function(userService) {
            return userService.getAll();
          }
        ]
      }
    },
    {
      name: "newUser",
      url: "/new",
      component: "newUser"
    },
    {
      name: "editUser",
      url: "/user/:id",
      template: '<edit-user user="$resolve.user"></edit-user>',
      resolve: {
        user: [
          "userService",
          "$stateParams",
          function(userService, $stateParams) {
            var userId = $stateParams.id;
            return userService.get(userId);
          }
        ]
      }
    },
    {
      name: "userDetail",
      url: "/detail/:id",
      template: '<user-viewer user="$resolve.user"></user-viewer>',
      resolve: {
        user: [
          "userService",
          "$stateParams",
          function(userService, $stateParams) {
            var userId = $stateParams.id;
            return userService.get(userId);
          }
        ]
      }
    }
  ];

  // Loop over the state definitions and register them
  states.forEach(function(state) {
    $stateProvider.state(state);
  });
}

app.config(setStates);

app.config([
  "$locationProvider",
  "$urlRouterProvider",
  "$apiEndpointProvider",
  function($locationProvider, $urlRouterProvider, $apiEndpoint) {
    $apiEndpoint.set("http://localhost:60815/api/");
    $locationProvider.hashPrefix("!");
    $urlRouterProvider.otherwise("/list");
  }
]);
