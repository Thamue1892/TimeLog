using System;
using Dataframework;
using Dataframework.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceFramework.Interface;
using ServiceFramework.Services;
using System.Linq;
using Dataframework.Entities;
using Microsoft.AspNetCore.Http;
using ServiceFramework;
using ServiceFramework.Utils;
using User = TimeLog.API.Models.User;

namespace TimeLog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private IRepository<Dataframework.Entities.User> repository;
        private IRepository<Project> projectRepository;
        private IRepository<UserInProject> userInProjectRepository;
        public AccountController()
        {
            repository = new Repository<Dataframework.Entities.User>();
            userService = new UserService(repository);
            projectRepository = new Repository<Project>();
            userInProjectRepository = new Repository<UserInProject>();
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult Login() => Ok();


        [HttpPost]
        [AllowAnonymous]
        [Route("/Account/Login")]
        public IActionResult Login([FromBody] Models.User model)
            {
            IActionResult response = Unauthorized();
            var account = userService.GetAllUser().Where(x => x.Email == "rendani@tirisan.co.za");

            if (account.Count() == 1)
            {
                JwtTokenIssuer.Issuer = "www.tirisan.co.za";
                JwtTokenIssuer.EncryptionSecretKey = "super-hashed-key";
                var payLoad = new JwtTokenIssuer.TokenInfo
                {
                    Iss = JwtTokenIssuer.Issuer,
                    Sub = model.Email,
                    Aud = "rendani@tirisan.co.za",
                    Jti = "rendani@tirisan.co.za".ToLower() + model.Email.ToLower()
                };

                var tokenStr = JwtTokenIssuer.GenerateJwtToken(payLoad);
                HttpContext.Session.SetString("token", tokenStr);
                HttpContext.Session.SetString("EmailAddress", model.Email);
                HttpContext.Session.SetString("Id", "1");
                response = Ok(new { token = tokenStr });
            }

            return response;
        }
        

        [HttpPost]
        [AllowAnonymous]
        [Route("/Account/Register")]
        public User Register([FromBody] User model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool userExist = userService.GetAllUser().Where(x => x.Email == model.Email).Any();
                    if (userExist)
                    {
                        model.ErrorCode = 101;
                        model.ErrorString = $"Email Address {model.Email} already registered.";
                    }
                    else
                    {
                        var newUser = new Dataframework.Entities.User
                        {
                            FullName = model.FullName,
                            Address = model.Address,
                            IsActive = false,
                            RoleId = model.RoleId,
                            SupervisorId = model.SupervisorId,
                            Email = model.Email
                        };
                        bool registerUser = userService.RegisterUser(newUser);
                        if (registerUser)
                        {
                            model.ErrorCode = 201;
                            model.ErrorString =
                                "You have been successfully registered, Please wait for confirmation from the supervisor";
                        }
                        else
                        {
                            model.ErrorCode = 404;
                            model.ErrorString =
                                "Ops, there was a error in your registration!, please try again.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogFileLogger.Error(ex.Message);
                Error.DbLoggerError("Error - Controller.Register :", ex);
            }
            return model;
        }

        [HttpGet]
        public IActionResult Activate(string token)
        {
            try
            {
                if (token != null)
                {
                    var tokenData = JwtTokenIssuer.IsValidToken(token);
                    var newUser = userService.GetFirst(tokenData.Sub);

                    if (newUser is not null)
                    {
                        newUser.IsActive = true;
                        userService.Update(newUser);

                        var projects =  projectRepository.GetAll().ToList();
                        int index = new Random().Next(projects.Count);
                        // Give new user atleast 1 project.
                        var userInProj = new UserInProject
                        {
                            UserId = newUser.Id,
                            ProjectId = index
                        };
                        userInProjectRepository.Insert(userInProj);

                    }
                    
                }
            }
            catch (Exception ex)
            {
                Error.LogFileLogger.Error(ex.Message);
                Error.DbLoggerError("Error - Controller.ActivateUser :", ex);
            }

            return Ok();
        }

    }
}
