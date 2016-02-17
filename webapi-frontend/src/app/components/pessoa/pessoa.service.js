(function(){
  'use strict';



  angular.module('webapiFrontend')
  .service('pessoaService',  pessoaService);

    /** @ngInject */
    function pessoaService($http) {
      return {
        listar: listar,
        cadastrar: cadastrar,
        deletar: deletar
      };

     function listar() {
        return $http.get('http://localhost:58426/api/v1/Pessoas');
      }

       function cadastrar(pessoa){
        return $http.post('http://localhost:58426/api/v1/Pessoa', pessoa);
      }

      function deletar(pessoa){
       return $http.delete('http://localhost:58426/api/v1/Pessoa/' + pessoa.PessoaId);
     }

    }

})();
