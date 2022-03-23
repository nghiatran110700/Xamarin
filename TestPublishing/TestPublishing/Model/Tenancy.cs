using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestPublishing.Model
{
    [Table("Tenancy")]
    public class Tenancy
    {
        [Key]
        public Guid TenancyK { get; set; }

        [StringLength(100)]
        public string TenancyName { get; set; }

        public virtual ICollection<LocationTB> LocationTB { get; set; }
    }
}
