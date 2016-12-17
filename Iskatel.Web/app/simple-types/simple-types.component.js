angular.
  module('simpleTypes').
  component('simpleTypeList', {
      templateUrl: '/app/simple-types/simple-types.template.html',
      controller: function SimpleTypeListController($http) {
          var self = this;
          self.showModal = "hidden";
          $http.get('/api/Class/Get').then(function (response) {
              self.simpleTypes = response.data;
          });
          self.showEditForm = function (id) {
              self.showModal = "visible";
          };
      }
  });