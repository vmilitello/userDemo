using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eManage.Repo.Entities
{
    [Table("Users")]
    internal class User
    {
        [Key]
        [Column("Id")]
        public int UserID { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        [Required]
        [Column("Name")]
        [MaxLength(50)]
        public string FullName { get; set; }

        /// <summary>
        /// User Age
        /// </summary>
        [Required]
        public int Age { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        [MaxLength(50)]
        public string Address { get; set; }
    }
}
