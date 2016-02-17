(function(){
  'use strict';

  angular.module('webapiFrontend')
  .controller('PessoaListagemController', PessoaListagemController);

  /** @ngInject */
  function PessoaListagemController(pessoaService, $state) {
    var vm = this;

      vm.deletar = function(pessoa){
          pessoaService.deletar(pessoa).then(
            function() {
                vm.sucess = "Deletado com sucesso!";
                $state.go('home');
            },
            function(error){
               vm.erros = error.data;
            }
          );
      };
     pessoaService.listar().then(function (data) {
       vm.lista = data.data;
     });
  }

})();
