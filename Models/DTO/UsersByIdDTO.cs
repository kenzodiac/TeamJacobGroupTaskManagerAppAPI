using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamJacobGroupTaskManagerAppAPI.Models.DTO
{
    public class UsersByIdDTO
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public bool isAdmin { get; set; }
    }
}