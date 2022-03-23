using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestPublishing.Model
{
    [Table("UserTB")]
    public class UserTB
    {
        [Key]
        public Guid UserK { get; set; }

        [StringLength(100)]
        public string Username { get; set; }

        [StringLength(100)]
        public string PasswordHash { get; set; }
    }
}
