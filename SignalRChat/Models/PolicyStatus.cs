using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SignalRChat.Models
{
    public class PolicyStatus
    {
        [Display(Name="POLICY NUMBER")]
        public string policy_no { get; set; }
        [Display(Name = "POLICY STATUS")]
        public string policy_status { get; set; }
        [Display(Name = "STATUS ID")]
        public string status_id { get; set; }
    }
}