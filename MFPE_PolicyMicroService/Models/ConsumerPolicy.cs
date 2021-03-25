using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_PolicyMicroService.Models
{
    public class ConsumerPolicy
    {
        public ConsumerPolicy()
        {
            PolicyMaster policyMaster = new PolicyMaster();
        }
        public int id { get; set; }
        public int ConsumerId { get; set; }

        public string ConsumerName { get; set; }

        // public int PropertyValue { get; set; }

        public string BussinessType { get; set; }

        public string BussinessName { get; set; }
        public int PolicyId { get; set; }
        [ForeignKey("PolicyId")]
        public virtual PolicyMaster PolicyMaster { get; set; }

        public bool PolicyStatus  { get; set; }
    }
}
