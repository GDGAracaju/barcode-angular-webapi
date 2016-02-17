(function() {
  'use strict';

  angular
    .module('webapiFrontend')
    .config(routerConfig);




  /** @ngInject */
  function routerConfig($stateProvider, $urlRouterProvider) {
    $stateProvider
      .state('home', {
        url: '/',
        templateUrl: 'app/pessoa/pessoa-listagem.html',
        controller: 'PessoaListagemController',
        controllerAs: 'vm'
      }).state('cadastro', {
          url: '/',
          templateUrl: 'app/pessoa/pessoa-cadastro.html',
          controller: 'PessoaCadastroController',
          controllerAs: 'vm'
        });

    $urlRouterProvider.otherwise('/');
  }

})();
