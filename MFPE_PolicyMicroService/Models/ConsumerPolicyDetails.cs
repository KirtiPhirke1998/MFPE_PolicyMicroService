using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_PolicyMicroService.Models
{
    public class ConsumerPolicyDetails
    {
        public int id { get; set; }
        public int ConsumerId { get; set; }

        public string ConsumerName { get; set; }

        // public int PropertyValue { get; set; }

        public string BussinessType { get; set; }

        public string BussinessName { get; set; }
    }
}
