using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vega.Models
{
    [Table("Models")]
    public class Model
    {        
        [Required]
        [StringLength(255)]
        public int Id { get; set; }
        public string Name { get; set; }
        public Make Make { get; set; }

        // forgein key property
        public int MakeId { get; set; }
    }

}