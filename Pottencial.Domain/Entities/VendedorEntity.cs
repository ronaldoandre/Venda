using System.Collections.Generic;

namespace Pottencial.Domain.Entities
{
    public class VendedorEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public List<VendaEntity> Vendas { get; set; }
    }
}