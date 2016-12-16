angular.
  module('simpleTypes').
  component('simpleTypeList', {
    templateUrl: 'simple-types/simple-types.template.html',
    controller: function SimpleTypeListController($http) {
      var self = this;
      $http.get('/api/Class/Get').then(function (response) {
        self.simpleTypes = response.data;
      });
    }
  })