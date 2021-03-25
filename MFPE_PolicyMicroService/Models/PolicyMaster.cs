using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_PolicyMicroService.Models
{
    public class PolicyMaster
    {

        public int ID { get; set; }

        public int BussinessValue { get; set; }

        // public int PropertyValue { get; set; }

        public string PropertyType { get; set; }

        public string ConsumerType { get; set; }
        public int AssuredSum { get; set; }
        public string Tenure { get; set; }
        public string BaseLocation { get; set; }
        public string Type { get; set; }
        


    }
}
