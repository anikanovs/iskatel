angular.
  module('personList').
  component('personList', {
      templateUrl: '/app/person-list/person-list.template.html',
      controller: function PersonListController($http) {
          var self = this;

          self.getData = function () {
              $http.get('/api/Person/Get').then(function (response) {
                  self.persons = response.data;
              });
          };

          self.deleteEntity = function (entity) {
              if (confirm("Удалить запись \"" + entity.Name + "\"?")) {
                  $http.delete('/api/Person/Delete/' + entity.Id).then(function (response) {
                      if (response.data == "OK") {
                          self.getData();
                      } else {
                          alert(response);
                      }
                  });
              }
          };

          self.getData();
      }
  });