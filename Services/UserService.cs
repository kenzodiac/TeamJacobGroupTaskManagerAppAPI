using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamJacobGroupTaskManagerAppAPI.Models;
using TeamJacobGroupTaskManagerAppAPI.Models.DTO;
using TeamJacobGroupTaskManagerAppAPI.Services.Context;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace TeamJacobGroupTaskManagerAppAPI.Services
{
    public class UserService : ControllerBase
    {
        private readonly DataContext _context;
        public UserService(DataContext context){
            _context = context;
        }

        public bool DoesUserExist(string Username)
        {
            // Check the table to see if the username exists
            // If an item matches the condition, return null
            // If multiple items match, an error occurs

            return _context.UserInfo.SingleOrDefault(User => User.Username == Username) != null;

        }

        public bool AddUser(CreateAccountDTO UserToAdd)
        {
            // Checks if they user already exists
            //If not, create an account. If so, throw false
            bool result = false;
            if(!DoesUserExist(UserToAdd.Username))
            {
                UserModel newUser = new UserModel();

                var hashPassword = HashPassword(UserToAdd.Password);
                newUser.Id = UserToAdd.Id;
                newUser.Username = UserToAdd.Username;
                newUser.Salt = hashPassword.Salt;
                newUser.Hash = hashPassword.Hash;

                _context.Add(newUser);

                result = _context.SaveChanges() != 0;
            }
            return result;

        }

        public PasswordDTO HashPassword(string? password)
        {
            PasswordDTO newHashedPassword = new PasswordDTO();
    // This is a byte array with a length of 64
            byte[] SaltByte = new byte[64];
            var provider = new RNGCryptoServiceProvider();

            provider.GetNonZeroBytes(SaltByte);

            var Salt = Convert.ToBase64String(SaltByte);

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltByte, 10000);

            var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = Hash;

            return newHashedPassword;
        }


        public bool VerifyUserPassword(string? Password, string? storedHash, string storedSalt)
        {
            var SaltBytes = Convert.FromBase64String(storedSalt);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);

            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            return newHash == storedHash;
        }


         public IActionResult Login(LoginDTO User)
        {
            IActionResult Result = Unauthorized();

            if(DoesUserExist(User.Username))
            {
                // If true, we want to store the user object to create another helper function
                UserModel foundUser = GetUserByUsername(User.Username);
                // Check if password is correct
                if(VerifyUserPassword(User.Password, foundUser.Hash, foundUser.Salt))
                {
                   var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    Result = Ok(new { Token = tokenString });   
                }
            }

            return Result;
        }

        public UserModel GetUserByUsername(string? username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }

        

    }
}