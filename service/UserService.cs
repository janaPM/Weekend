using Db_DI;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<UserService> _logger;
        public UserService( AppDbContext appContext, ILogger<UserService> logger) 
        {
            _appDbContext = appContext;
            _logger = logger;
        }



        public async Task<UserModel> GetUser(string id)
        {
            try
            {
                var userdata = await _appDbContext.user.Where(u => u.id == id).FirstOrDefaultAsync();  

                if (userdata != null)
                {

                    var interestsList = string.IsNullOrEmpty(userdata.interest)? new List<string>() : userdata.interest.Split(',').Select(i => i.Trim()).ToList();


                    var userModel = new UserModel
                    {
                        id = userdata.id,
                        name = userdata.name,
                        bio = userdata.bio,
                        work = userdata.work,
                        education = userdata.education,
                        gender = userdata.gender,
                        location = userdata.location,
                        hometown = userdata.hometown,
                        height = userdata.height,
                        exercise = userdata.exercise,
                        educationLevel = userdata.educationlevel,
                        interest = interestsList
                    };

                    return userModel;
                }
                return new UserModel();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UserService /Getuser : {ex.Message}");
                return new UserModel();
            }
        }

    }
}
