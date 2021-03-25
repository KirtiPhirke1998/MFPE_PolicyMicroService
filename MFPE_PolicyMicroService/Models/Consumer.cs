using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_PolicyMicroService.Models
{
    public class Consumer
    {
        public int id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string AgentId { get; set; }

        public DateTime ValidityOfConsumer { get; set; }

        public int BussinessId { get; set; }
        [ForeignKey("BussinessId")]
        public Business Business { get; set; }
    }
}
