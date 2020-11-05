using GreenNews.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GreenNews.DataBase
{
    public class ArtigoContexto : DbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Artigo> Artigos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // Tirando o plural das tabelas
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(200)); //Limitando a quantidade de caracteres 

        }
    }
}