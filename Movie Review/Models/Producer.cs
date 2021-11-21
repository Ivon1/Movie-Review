using System.ComponentModel.DataAnnotations;

namespace Movie_Review.Models
{
    public class Producer
    {
        public int Id { get; set; }


        [Required, Display(Name = "ProducerName")]
        public string ProducerName { get; set; }
    }
}
