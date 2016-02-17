(function(){
  'use strict';

  angular.module('webapiFrontend')
  .controller('PessoaCadastroController', PessoaCadastroController);

  /** @ngInject */
  function PessoaCadastroController(pessoaService) {
    var vm = this;
    vm.pessoa = {};

    vm.cadastrar = function(){
      pessoaService.cadastrar(vm.pessoa).then(function(){
        vm.success = "Cadastrado com sucesso!";
      },
      function(error){
          vm.errors = error.data;
          console.log(error);
      });
    }
  }

})();
