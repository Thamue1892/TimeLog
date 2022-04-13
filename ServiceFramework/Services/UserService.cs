using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dataframework.Entities;
using Dataframework.Interface;
using Microsoft.IdentityModel.Protocols;
using ServiceFramework.Interface;
using ServiceFramework.Utils;

namespace ServiceFramework.Services
{
    public class UserService : IUserService
    {
        private List<IUser> users { get; set; }
        private IRepository<User> _userRepository;

        public UserService()
        {
            
        }

        public UserService(IRepository<User> userRepository) => this._userRepository = userRepository;

        public List<User> GetAllUser()
        {
            List<User> model = new List<User>();

            try
            {
                model = _userRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                Error.LogFileLogger.Error(ex.Message);
                Error.DbLoggerError("WARNING Function - GetAllUser :", ex);
            }

            return model;
        }


        public bool RegisterUser(User user)
        {
            try
            {
                _userRepository.Insert(user);
                var supervisor = _userRepository.GetWhere(x => x.SupervisorId == 1).FirstOrDefault();
                string buildEmailBody = EmailBody(supervisor.FullName.ToString(), user.Email);
                new SendMail().SendEmail(user.Email, supervisor.Email, "12mymailserver12.com", "New Registration", body: buildEmailBody);
            }
            catch (Exception ex)
            {
                Error.LogFileLogger.Error(ex.Message);
                Error.DbLoggerError("Error Function - RegisterUser :", ex);
                return false;
            }
            return true;
        }

        public User GetFirst(string emailAddress)
        {
           return _userRepository.GetWhere(x => x.Email == emailAddress).FirstOrDefault();
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }


        private string EmailBody(string supervisor, string newUser)
        {
            string body = null;

            try
            {
                //TODO Move path to config.
                var activateMailTmplPath = "C:\\Thami\\TimeLog\\ServiceFramework\\EmailTemplate\\new_registration.txt";
                if (File.Exists(activateMailTmplPath))
                {
                    var tmpl = File.ReadAllText(activateMailTmplPath);
                    // TODO Move these values to a config file.
                    JwtTokenIssuer.Issuer = "www.tirisan.co.za";
                    JwtTokenIssuer.EncryptionSecretKey = "super-hashed-key";
                    var payLoad = new JwtTokenIssuer.TokenInfo
                    {
                        Iss = JwtTokenIssuer.Issuer,
                        Sub = newUser,
                        Aud = supervisor,
                        Jti = supervisor.ToLower() + newUser.ToLower()
                    };


                    var token = JwtTokenIssuer.GenerateJwtToken(payLoad);
                    
                    var url = "www.tirisan.co.za/timelog/Account/Activate" + "?token=" + token;

                    body = string.Format(tmpl, supervisor, newUser, url);
                }
            }
            catch (Exception ex)
            {
                Error.LogFileLogger.Error(ex.Message);
                Error.DbLoggerError("WARNING Function -UserService.EmailBody :", ex);
            }

            return body;
        }
    }
}