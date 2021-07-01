using DataAccess.Mappings;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
               @"Server=database-paintmeup.cbmgpelgfj8a.us-east-1.rds.amazonaws.com;Initial Catalog=PaintMeup;Persist Security Info=False;User ID=admin;Password=123456789;");
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TemplateMappings());

        }

        public DbSet<Template> Template { get; set; }
        public DbSet<Image> Image { get; set; }

    }
}
