using BittiBitti.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Domain.Entities
{
    public partial class Category:Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Sequence { get; set; }
        public int? RowStatusId { get; set; }
    }
}
