using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamJacobGroupTaskManagerAppAPI.Models.DTO;
using TeamJacobGroupTaskManagerAppAPI.Services.Context;

namespace TeamJacobGroupTaskManagerAppAPI.Services
{
    public class TaskService
    {
         private readonly DataContext _context;
        public TaskService(DataContext context){
            _context = context;
        }

        public bool UpdateTask(TaskItemModel userToUpdate){
            _context.Update<TaskItemModel>(userToUpdate);
            return _context.SaveChanges() !=0;
        }

        public bool deleteTask(TaskItemModel TaskDelete){
            _context.Update<TaskItemModel>(TaskDelete);
            return _context.SaveChanges() !=0;
        }
    }
}