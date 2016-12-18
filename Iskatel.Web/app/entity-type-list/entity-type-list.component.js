angular.
  module('entityTypeList').
  component('entityTypeList', {
      templateUrl: '/app/entity-type-list/entity-type-list.template.html',
      controller: function EntityTypeListController($http) {
          var self = this;

          self.hideModal = function () {
              this.modalVisible = "hidden";
          };

          self.showModal = function () {
              this.modalVisible = "visible";
          };

          self.getData = function () {
              $http.get('/api/EntityTypes/Get').then(function (response) {
                  self.entityTypes = response.data;
              });
          };

          self.showAddForm = function () {
              this.showModal();
              this.Id = "";
              this.Name = "";
              this.Alias = "";
              this.modalModeText = "Создать новый тип сущности";
          };

          self.deleteEntity = function (entity) {
              if (confirm("Удалить запись \"" + entity.Name + "\"?"))
              {
                  $http.delete('/api/EntityTypes/Delete/' + entity.Id).then(function (response) {
                      if (response.data == "OK") {
                          self.hideModal();
                          self.getData();
                      } else {
                          alert(response);
                      }
                  });
              }
          };

          self.addEntity = function () {
              var entity = 
              {
                  Id: this.Id,
                  Name: this.Name,
                  Alias: this.Alias
              };
              $http.put('/api/EntityTypes/Put', entity).then(function (response) {
                  if (response.data == "OK") {
                      self.hideModal();
                      self.getData();
                  } else {
                      alert(response);
                  }
              });
          };

          self.saveEntity = function () {
              self.addEntity();
          };

          self.hideModal();
          self.getData();
      }
  });