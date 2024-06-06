﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodeFirst.Models
{
    public class LibreriaContext : DbContext
    {
        public DbSet<Libro> Libros { get; set; }

        public DbSet<Autor> Autores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"server=(localdb)\MSSQLLocalDB;database=Libreria;Integrated Security=True");
        }
    }
}
