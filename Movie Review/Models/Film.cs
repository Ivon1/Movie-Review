using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Movie_Review.Models
{
    public class Film
    {
        public int Id { get; set; }


        [Required, Display(Name = "FimlTitle")]
        public string FimlTitle { get; set; }


        [Required, Display(Name = "MovieDescription"), MaxLength(400)]
        public string MovieDescription { get; set; }


        [Display(Name = "PathToPhoto")]
        public string PathToPhoto {  get; set; }

        [Required, Display(Name = "Rate")]
        public int Rate { get; set; }


        [Required, Display(Name = "Producer")]
        public int ProducerId { get; set; }


        [Required , Display(Name = "Country")]
        public int CountryId { get; set; }


        [Required, Display(Name = "Janre")]
        public int JanreId { get; set; }

        [Required, Display(Name = "Url")]
        public string Url { get; set; }


        public virtual Producer Producer { get; set; }
        public virtual Country Country { get; set; }
        public virtual Janre Janre { get; set; }

    }
}
