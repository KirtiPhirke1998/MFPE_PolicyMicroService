using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_PolicyMicroService.Models
{
    public class BusinessMaster
    {
        public int id { get; set; }
        public bool HasBusinessTypes { get; set; }

        public int AnnualTurnover { get; set; }

        public int capitalInvested { get; set; }

        [Range(0, 10, ErrorMessage = "Bussiness value should be in the range of 0 to 10")]

        public int BussinessValue { get; set; }
    }
}
