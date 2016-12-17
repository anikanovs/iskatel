angular.
  module('simpleTypes').
  component('simpleTypeList', {
      templateUrl: '/app/simple-types/simple-types.template.html',
      controller: function SimpleTypeListController($http) {
          var self = this;

          self.hideModal = function () {
              this.modalVisible = "hidden";
          };

          self.showModal = function () {
              this.modalVisible = "visible";
          };

          self.getData = function () {
              $http.get('/api/Class/Get').then(function (response) {
                  self.simpleTypes = response.data;
              });
          };

          self.showEditForm = function (entity) {
              this.showModal();
              this.Id = entity.Id;
              this.Name = entity.Name;
              this.Alias = entity.Alias;
              this.modalModeText = "Редактировать тип поля";
              this.mode = "edit";
          };

          self.showAddForm = function () {
              this.showModal();
              this.Id = "";
              this.Name = "";
              this.Alias = "";
              this.modalModeText = "Создать новый тип поля";
              this.mode = "add";
          };

          self.deleteEntity = function (entity) {
              if (confirm("Удалить запись \"" + entity.Name + "\"?"))
              {
                  $http.delete('/api/Class/Delete/' + entity.Id).then(function (response) {
                      if (response.data == "OK") {
                          self.hideModal();
                          self.getData();
                      } else {
                          alert(response);
                      }
                  });
              }
          };

          self.updateEntity = function () {
              var entity = 
              {
                  Id: this.Id,
                  Name: this.Name,
                  Alias: this.Alias
              };
              $http.post('/api/Class/Post', entity).then(function (response) {
                  if (response.data == "OK") {
                      self.hideModal();
                      self.getData();
                  } else {
                      alert(response);
                  }
              });
          };

          self.addEntity = function () {
              var entity = 
              {
                  Id: this.Id,
                  Name: this.Name,
                  Alias: this.Alias
              };
              $http.put('/api/Class/Put', entity).then(function (response) {
                  if (response.data == "OK") {
                      self.hideModal();
                      self.getData();
                  } else {
                      alert(response);
                  }
              });
          };

          self.saveEntity = function () {
              if (this.mode == "edit") {
                  self.updateEntity();
              } else {
                  self.addEntity();
              }
          };

          self.hideModal();
          self.getData();
      }
  });