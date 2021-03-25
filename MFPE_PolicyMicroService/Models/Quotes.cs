using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_PolicyMicroService.Models
{
    public class Quotes
    {
        public int id { get; set; }

        public int PropertyValueFrom { get; set; }

        public int PropertyValueTo { get; set; }

        public int BussinessValueFrom { get; set; }

        public int BussinessValueTo { get; set; }

        public string PropertyType { get; set; }

        public int QuoteInsurance { get; set; }
    }
}
