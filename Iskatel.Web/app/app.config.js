angular.
  module('iskateliBackend').
  config(['$locationProvider', '$routeProvider',
    function config($locationProvider, $routeProvider) {
      $locationProvider.hashPrefix('!');

      $routeProvider.
        when('/simple-types', {
            template: '<simple-type-list></simple-type-list>'
        }).
        when('/entity-types', {
            template: '<entity-type-list></entity-type-list>'
        }).
        when('/entity-types/:entityId', {
          template: '<entity-type-edit></entity-type-edit>'
        }).
        when('/person', {
            template: '<person-list></person-list>'
        }).
        otherwise('/simple-types');
    }
  ])