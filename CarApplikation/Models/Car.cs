using System.ComponentModel.DataAnnotations;

namespace CarApplikation.Models
{
    public class Car
    {
        [Key] 
        public int Id { get; set; }

       [Required]
        public string Name { get; set; }
        [Required]

        public int ModelNumber { get; set; }
        [Required]
        public int ModelYear { get; set; }
    }
}
