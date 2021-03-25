using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MFPE_PolicyMicroService.Models
{
    public class IssuePolicy
    {
        [Key]
        public int  IssueId { get; set; }
        public int CustomerId { get; set; }
    }
}
