using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Core.Domain.Biblioteca
{
    public class RegistroDeEmprestimo
    {
        public int RegistroDeEmprestimoId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataDeEmprestimo { get; set; }

        [Required]
        public int PeriodoDeEmprestimo { get; set; }

        public DateTime DataDeEntrega()
        {
            return DataDeEmprestimo.AddDays(PeriodoDeEmprestimo);
        }

        public bool EmAtrazo()
        {
            return DateTime.Now > DataDeEntrega();
        }

        public virtual Conta ContaDaReserva { get; set; }

        public virtual Conta ContaDoEmprestimo { get; set; }

    }
}