using System.ComponentModel.DataAnnotations;

namespace Movie_Review.Models
{
    public class Janre
    {
        public int Id { get; set; }


        [Required, Display(Name = "JanreName")]
        public string JanreName { get; set; }
    }
}
