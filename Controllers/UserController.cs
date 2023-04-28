using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamJacobGroupTaskManagerAppAPI.Services;
using TeamJacobGroupTaskManagerAppAPI.Models;
using TeamJacobGroupTaskManagerAppAPI.Models.DTO;

namespace TeamJacobGroupTaskManagerAppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        
        private readonly UserService _data;
            public UserController(UserService dataFromService)
            {
                _data = dataFromService;
                
            }


        // Login

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDTO User)
        {
            return _data.Login(User);
        }

        // Add a user

        [HttpPost]
        [Route("AddUser")]
        public bool AddUser(CreateAccountDTO UserToAdd)
        {
          return _data.AddUser(UserToAdd);
        }

        //Update User Account
        [HttpPost]
        [Route("UpdateUser")]
        public bool UpdateUser(UserModel userToUpdate){
            return _data.UpdateUser(userToUpdate);
        }

        //Update User's Username
        [HttpPost]
        [Route("UpdateUser/{id}/{username}")]
        public bool UpdateUser(int id, string username){
            return _data.UpdateUsername(id, username);
        }

        //Delete User Account
        [HttpDelete]
        [Route("DeleteUser/{userToDelete}")]
        public bool DeleteUser(string userToDelete){
            return _data.DeleteUser(userToDelete);
        }

        //Get All Users
        [HttpGet]
        [Route("GetAllUsers")]
        public IEnumerable<UsersByIdDTO> GetAllUsers(){
            return _data.GetAllUsers();
        }

        [HttpGet]
        [Route("UserByUserName/{userName}")]

        public UsersByIdDTO GetUserByUserName(string userName){
            return _data.GetUserIdDTOByUserName(userName);
        }
    }
}