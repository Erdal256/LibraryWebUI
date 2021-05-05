using Core.Records.Bases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class Role : RecordBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
