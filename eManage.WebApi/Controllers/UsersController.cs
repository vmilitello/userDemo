using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using eManage.Validators;
using Microsoft.AspNetCore.Cors;

namespace eManage.Controllers
{
    [Route("api/[controller]")]
    [ValidateModelAttribute]
    public class UsersController : Controller
    {
        private Domain.Interfaces.IUserRepo _userRepository;
        private ILogger _logger;
        public UsersController(Domain.Interfaces.IUserRepo userRepository, ILoggerFactory logger)
        {
            _userRepository = userRepository;
            _logger = logger.CreateLogger("UsersController");
        }

        /// <summary>
        /// Get all the users in the repo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Models.UserModel> Get()
        {
            return _userRepository.GetAll()?.Select(u=> new Models.UserModel(u));
        }

        /// <summary>
        /// Retrieve a user with a specific ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Models.UserModel  Get(int id)
        {
            var user = _userRepository.Get(id);
            return user == null ? null : new Models.UserModel(user);
        }

        /// <summary>
        /// Create a new User 
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public int Post([FromBody]Models.UserModel user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            
            var newUser = _userRepository.Create(user.ToDomain());
            return newUser.UserID;
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Models.UserModel user)
        {
            //Guard against invalid Id
            if (id<=0)
                throw new ArgumentNullException(nameof(id), "User id not provided");
            
            //Guard against empty model
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            
            //Guard against inconsistent ID
            if (user.Id!=0 && user.Id != id)
                _logger.LogWarning($"id ({id}) and user.id {user.Id} are not equals. user.id will be used");

            _userRepository.Update(id, user.ToDomain());
        }
               
    }
}
