using Microsoft.EntityFrameworkCore;
using ORIONDEV.ENTITY.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORIONDEV.DATA.DBContexts
{
    public class OrionDevDataContext : DbContext
    {
        public OrionDevDataContext(DbContextOptions<OrionDevDataContext> options) : base(options)
        {
        }
        public DbSet<Company> Company { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<ClientAdress> ClientAdress { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
