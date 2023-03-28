using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vueJsBack.Models;

namespace vueJsBack.Conext
{
    public class AplicationDbContext : DbContext
    {


        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) 
        { 
        }
        public DbSet<Gasto> Gastos { get; set; }

    }
}
