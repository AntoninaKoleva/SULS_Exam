using System.ComponentModel.DataAnnotations;

namespace SULS.Models
{
    public class Problem
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Points { get; set; }
    }
}
