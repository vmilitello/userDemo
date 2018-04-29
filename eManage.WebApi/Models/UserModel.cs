using System;
using System.ComponentModel.DataAnnotations;

namespace eManage.Models
{
    public class UserModel
    {
        internal UserModel(Domain.User user)
        {
            this.Address = user.Address;
            this.Age = user.Age;
            this.Name = user.FullName;
            this.Id = user.UserID;
        }

        /// <summary>
        /// Public constructor 
        /// </summary>
        public UserModel()
        {

        }

        /// <summary>
        /// Return the correspondent instance of <seealso cref="Domain.User"/> 
        /// for the class
        /// </summary>
        /// <returns>The domain.</returns>
        internal Domain.User ToDomain(){
            var retVal =  new Domain.User
            {
                UserID=this.Id,
                Address = this.Address,
                Age = this.Age,
                FullName = this.Name
            };

            return retVal;
        }

        /// <summary>
        /// User ID
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// User name
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// User Age
        /// </summary>
        [Required]
        [Range(0, Int32.MaxValue)]
        public int Age { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        [MaxLength(50)]
        public string Address { get; set; }
        
    }
}
