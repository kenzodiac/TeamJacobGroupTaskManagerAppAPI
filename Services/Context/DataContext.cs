using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamJacobGroupTaskManagerAppAPI.Services.Context
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions options): base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
        }
    }
}