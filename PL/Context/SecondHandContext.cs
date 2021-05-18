using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL
{
    public class SecondHandContext : DbContext
    {
        public SecondHandContext() : base()
        {
        }
        /*public SecondHandContext(DbContextOptions<SecondHandContext> options)
            : base(options)
        {
        }*/

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SecondHand;Trusted_Connection=True;");
        }
    }
}