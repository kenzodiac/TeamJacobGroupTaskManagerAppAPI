using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamJacobGroupTaskManagerAppAPI.Models.DTO;
using TeamJacobGroupTaskManagerAppAPI.Services;

namespace TeamJacobGroupTaskManagerAppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
         private readonly TaskService _data;
        public TaskController(TaskService dataFromService){
            _data = dataFromService;
        }

         //Update Task
        [HttpPost]
        [Route("UpdateTask")]

        public bool UpdateTask(TaskItemModel TaskUpdate){
            return _data.UpdateTask(TaskUpdate);
        }

        [HttpPost]
        [Route("deleteTask")]

        public bool deleteTask(TaskItemModel TaskDelete){
            return _data.deleteTask(TaskDelete);
        }
    }
}