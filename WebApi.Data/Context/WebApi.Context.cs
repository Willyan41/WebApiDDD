using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Data.Mapping;
using WebApi.Domain.Entities;

namespace WebApi.Data.Context
{
    public class WebApiContext : DbContext
    {
        
        public DbSet<Usuario> Usuarios { get; set; }

        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.Entity<Usuario>(new UsuarioMap().Configure);


        }


    }
}
