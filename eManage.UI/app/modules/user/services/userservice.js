(function() {
  "use strict";

  angular.module("emanage.user").service("userService", userService);

  userService.$inject = ["$http", "$apiEndpoint"];

  function userService($http, $apiEndpoint) {
    /*Base url to the controller */
    this.apiUrl = $apiEndpoint + "users/";

    this.getAll = getAll;
    this.get = loadUser;
    this.post = createUser;
    this.put = updateUser;

    /**
     * Return a promise of users
     */
    function getAll() {
      return $http.get(this.apiUrl).then(successCallback, erroCallback);
    }

    /**
     * Return the user with the specified ID
     * @param {number} id user Id
     */
    function loadUser(id) {
      if (isNaN(id) || parseInt(id) <= 0)
        throw Error("This is not a valid user ID!");
        var url = this.apiUrl + id;
      return $http.get(url).then(successCallback, erroCallback);
    }

    /**
     * Update a user
     * @param {number} id User ID
     * @param {object} user Object with user new values
     */
    function updateUser(user) {
      if (isNaN(user.id) || parseInt(user.id) <= 0)
        throw Error("This is not a valid user ID!");
      var url = this.apiUrl + user.id;
     return $http.put(url, user).then(successCallback, erroCallback);
    }

    /**
     * Create a new user
     * @param {object} user  Object with user values
     */
    function createUser(user) {
     return $http.post(this.apiUrl, user).then(successCallback, erroCallback);
    }


    /**
     * default success callback
     * @param {object} result result data
     */
    function successCallback(result) {
      return result.data;
    }

    /**
     * Default error callback
     * @param {object} err error object
     */
    function erroCallback(err) {
      throw Error(
        err.message ||
          "Ops! That's embarassing, but seems like something didn't go well. "
      );
    }
  }
})();
