using System.ComponentModel.DataAnnotations;

namespace Movie_Review.Models
{
    public class Country
    {
        public int Id { get; set; }


        [Required, Display(Name = "CountryName")]
        public string CountryName { get; set; }
    }
}
