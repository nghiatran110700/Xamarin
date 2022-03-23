using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestPublishing.Model
{
    [Table("AssetType")]
    public class AssetType
    {
        [Key]
        public Guid AssetTypeK { get; set; }

        [StringLength(100)]
        public string AssetTypeName { get; set; }

        public virtual ICollection<Asset> Asset { get; set; }
    }
}
