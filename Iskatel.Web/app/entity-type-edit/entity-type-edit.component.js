angular.
  module('entityTypeEdit').
  component('entityTypeEdit', {
      templateUrl: '/app/entity-type-edit/entity-type-edit.template.html',
      controller: ['$routeParams', '$http', function EntityTypeEditController($routeParams, $http) {
          var self = this;

          self.hideModal = function () {
              this.modalVisible = "hidden";
          };

          self.showModal = function () {
              this.modalVisible = "visible";
          };

          self.getSimpleTypes = function () {
              $http.get('/api/SimpleTypes/Get').then(function (response) {
                  self.simpleTypes = response.data;
              });
          }

          self.getData = function () {
              $http.get('/api/EntityFields/Get/' + $routeParams.entityId).then(function (response) {
                  self.fields = response.data;
              });
              $http.get('/api/EntityTypes/Get/' + $routeParams.entityId).then(function (response) {
                  self.entity = response.data;
              });
          };

          self.showEditForm = function (entity) {
              this.showModal();
              this.FieldId = entity.Id;
              this.FieldName = entity.Name;
              this.FieldAlias = entity.Alias;
              this.FieldTypeId = entity.TypeId;
              this.modalModeText = "Редактировать поле";
              this.mode = "edit";
          };

          self.showAddForm = function () {
              this.showModal();
              this.Id = "";
              this.Name = "";
              this.Alias = "";
              this.TypeId = 0;
              this.modalModeText = "Создать новое поле";
              this.mode = "add";
          };

          self.deleteField = function (field) {
              if (confirm("Удалить поле \"" + field.Name + "\"?"))
              {
                  $http.delete('/api/EntityFields/Delete/' + field.Id).then(function (response) {
                      if (response.data == "OK") {
                          self.hideModal();
                          self.getData();
                      } else {
                          alert(response);
                      }
                  });
              }
          };

          self.addField = function () {
              var entity = 
              {
                  Id: this.Id,
                  Name: this.FieldName,
                  Alias: this.FieldAlias,
                  TypeId: this.FieldTypeId
              };
              $http.put('/api/EntityFields/Put/' + $routeParams.entityId, entity).then(function (response) {
                  if (response.data == "OK") {
                      self.hideModal();
                      self.getData();
                  } else {
                      alert(response);
                  }
              });
          };

          self.updateField = function () {
              var entity =
              {
                  Id: this.FieldId,
                  Name: this.FieldName,
                  Alias: this.FieldAlias,
                  TypeId: this.FieldTypeId
              };
              $http.post('/api/EntityFields/Post', entity).then(function (response) {
                  if (response.data == "OK") {
                      self.hideModal();
                      self.getData();
                  } else {
                      alert(response);
                  }
              });
          };

          self.saveEntity = function () {
              $http.post('/api/EntityTypes/Post', this.entity).then(function (response) {
                  if (response.data != "OK") {
                      alert(response);
                  }
              });
          };

          self.saveField = function () {
              if (this.mode == "edit") {
                  self.updateField();
              } else {
                  self.addField();
              }
          };

          self.hideModal();
          self.getData();
          self.getSimpleTypes();
      }]
  });