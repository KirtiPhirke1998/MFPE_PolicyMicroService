using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_PolicyMicroService.Models
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> op) : base(op) { }


        public virtual DbSet<PolicyMaster> PolicyMasters { get; set; }

        public virtual DbSet<ConsumerPolicy> ConsumerPolicies { get; set; }


    }
}
