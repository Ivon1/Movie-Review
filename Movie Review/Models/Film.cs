using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Review.Models
{
    public class Film
    {
        public int Id { get; set; }


        [Required, Display(Name = "FimlTitle")]
        public string FimlTitle { get; set; }


        [Required, Display(Name = "MovieDescription")]
        public string MovieDescription { get; set; }


        [Required, Display(Name = "PathToPhoto")]
        public string PathToPhoto {  get; set; }

        [Required, Display(Name = "Rate")]
        public int Rate { get; set; }


        [Required, Display(Name = "Producer")]
        public int ProducerId { get; set; }


        [Required , Display(Name = "Country")]
        public int CountryId { get; set; }


        [Required, Display(Name = "Janre")]
        public int JanreId { get; set; }


        public virtual Producer Producer { get; set; }
        public virtual Country Country { get; set; }
        public virtual Janre Janre { get; set; }
    }
}
