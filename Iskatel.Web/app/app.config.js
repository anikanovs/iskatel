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
        when('/phones/:phoneId', {
          template: '<phone-detail></phone-detail>'
        }).
        otherwise('/simple-types');
    }
  ])