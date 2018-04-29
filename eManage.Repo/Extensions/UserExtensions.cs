using System;
using System.Collections.Generic;
using System.Text;

namespace eManage.Repo.Extensions
{
    internal static class UserExtensions
    {
        /// <summary>
        /// Transform a <paramref name="user"/> <typeparamref name="user"/>
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        internal static  Domain.User ToUserModel(this Repo.Entities.User user)
        {
            return new Domain.User
            {
                UserID = user.UserID,
                Address = user.Address,
                Age = user.Age,
                FullName = user.FullName
            };
        }
    }
}
