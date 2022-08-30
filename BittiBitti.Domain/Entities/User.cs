using BittiBitti.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Domain.Entities
{

    public partial class User : Entity
    {
        public int? Name { get; set; }
        public int? Surname { get; set; }
        public int? Email { get; set; }
        public int? Password { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? RowStatusId { get; set; }
    }
}
