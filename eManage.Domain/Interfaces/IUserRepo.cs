using System;
using System.Collections.Generic;
using System.Text;

namespace eManage.Domain.Interfaces
{
    public interface IUserRepo
    {
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User Create(User user);

        /// <summary>
        /// Retrieve a user with the specific ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User Get(int userId);

        /// <summary>
        /// Update the user
        /// </summary>
        /// <param name="id">Id of the user that needs to be updated</param>
        /// <param name="user"></param>
        /// <returns></returns>
        User Update(int id, User user);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAll();
    }
}
