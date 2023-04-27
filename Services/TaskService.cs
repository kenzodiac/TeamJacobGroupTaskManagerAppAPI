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
        public TaskService(DataContext context)
        {
            _context = context;
        }

        public bool AddTaskItem(TaskItemModel newTaskItem)
        {
            _context.Add(newTaskItem);
            return _context.SaveChanges() != 0;
        }

         public IEnumerable<TaskItemModel> GetAllTaskItems()
        {
            return _context.TaskInfo;
        }

          public IEnumerable<TaskItemModel> GetTasksByAsignee(string AssignedTo)
        {
            return _context.TaskInfo.Where(item => item.AssignedTo == AssignedTo);
        }
    }
}