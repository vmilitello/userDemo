using System;

namespace eManage.Domain
{
    public class User
    {
        
        public int UserID { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// User Age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }
    }
}
