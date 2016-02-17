(function(){
  'use strict';

  angular.module('webapiFrontend')
  .controller('PessoaListagemController', PessoaListagemController );

  function PessoaListagemController(pessoaService){
    var vm = this;

    vm.lista = pessoaService.listar();

  }
});
