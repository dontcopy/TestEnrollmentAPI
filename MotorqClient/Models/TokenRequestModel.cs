using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorqService.Models
{
    public class TokenRequestModel
    {
        public string clientId { get; set; }

        public string clientSecret { get; set; }

        public string audience { get; set; }
        public string grantType { get; set; }
    }
}
