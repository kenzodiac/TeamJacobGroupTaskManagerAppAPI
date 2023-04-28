using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamJacobGroupTaskManagerAppAPI.Models.DTO
{
    public class TaskItemModel
    {
         public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? DueDate { get; set; }
        public string? Priority { get; set; }
        public string? Status { get; set; }
        public int AssignedBy { get; set; }
        public int AssignedTo { get; set; }
       
        public bool isDeleted { get; set; }

        public TaskItemModel(){}
    }
}