using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace vega.Models
{
    public class Make
    {
        [Required]
        [StringLength(255)]
        public int Id { get; set; }
        public string Name { get; set; }
        public  ICollection<Model> Models {get; set; }

        public Make()
        {
            Models = new Collection<Model>();
        }
    }
}