using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Application.Features.Users.Dtos.Response
{
    public class LoginCheckResponse
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fullname { get; set; }
        public void SetFullname()
        {
            this.Fullname = $"{Name} {Surname}";
        }
    }
}
