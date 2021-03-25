using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_PolicyMicroService.Models
{
    public class Business
    {
        public int id { get; set; }

        public string BussinessName { get; set; }
        public string BussinessType { get; set; }


        public int TotalEmployees { get; set; }

        public int BussinessMasterId { get; set; }
        [ForeignKey("BussinessMasterId")]
        public BusinessMaster BusinessMaster { get; set; }
    }
}
