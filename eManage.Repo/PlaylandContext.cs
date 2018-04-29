using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eManage.Repo
{
    public class eManageContext:DbContext
    {
        public eManageContext(DbContextOptions<eManageContext> options)
            : base(options)
        {
        }

        internal DbSet<Entities.User> Users { get; set; }
    }
}
