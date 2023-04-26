using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamJacobGroupTaskManagerAppAPI.Models;

namespace TeamJacobGroupTaskManagerAppAPI.Services.Context
{
    public class DataContext : DbContext
    {
        public DbSet<UserModel> UserInfo { get; set; }
         public DataContext(DbContextOptions options): base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
        }
    }
}