using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pottencial.Domain.Entities;

namespace Pottencial.Data.Context
{
    public class PottencialContext : DbContext
    {
        public PottencialContext(DbContextOptions<PottencialContext> options) : base(options) { }

        public DbSet<VendedorEntity> Vendedores { get; set; }
        public DbSet<ProdutoEntity> Produtos { get; set; }
        public DbSet<VendaEntity> Vendas { get; set; }
    }
}