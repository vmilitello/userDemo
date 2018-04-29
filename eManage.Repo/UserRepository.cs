using eManage.Repo.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using eManage.Domain;

namespace eManage.Repo
{
    public class UserRepository : eManage.Domain.Interfaces.IUserRepo
    {
        eManageContext dbContext;

        public UserRepository(eManageContext context)
        {
            dbContext = context;
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Domain.User Create(Domain.User user)
        {
            var eUser = new Entities.User
            {
                Address = user.Address,
                FullName = user.FullName,
                Age = user.Age
            };
            
            //Add the user to the context
            dbContext.Users.Add(eUser);

            //Save the context
            Save();

            //Return the refreshed user
            return eUser.ToUserModel();
        }

        /// <summary>
        /// Search the user with a specific <paramref name="userId"/>
        /// If not found, returns null
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Domain.User Get(int userId)
        {
            return GetUserById(userId)?.ToUserModel();
        }

        /// <summary>
        /// Retrieve all the users in the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Domain.User> GetAll()
        {
            return dbContext.Users.Select(u => u.ToUserModel()).AsEnumerable();
            
        }
 
        /// <summary>
        /// Update the user
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="user"></param>
        /// <returns></returns>
        public User Update(int id, User user)
        {
            var dbUser = GetUserById(id);

            if (dbUser == null)
                throw new ArgumentException(); //TODO: this should be a custom domain exception, not a generic one.

            //set new values
            dbUser.Address = user.Address;
            dbUser.Age = user.Age;
            dbUser.FullName = user.FullName;

            //Saving
            Save();

            return dbUser.ToUserModel();
        }

        #region Private methods

        /// <summary>
        /// Search the specific user in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Entities.User GetUserById(int id)
        {
            return dbContext.Users.FirstOrDefault(u => u.UserID == id);
        }

        /// <summary>
        /// Save onto database and catch exceptions
        /// </summary>
        private void Save()
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to save on database", ex);
            }
        } 

        #endregion
    }
}
