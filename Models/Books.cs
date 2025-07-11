using System.ComponentModel.DataAnnotations;

namespace crudapplication.Models
{
    public class Books
    {
        [Key]
        [Display(Name ="ISBN")]
        public string isbn { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int qunatity { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string category { get; set; }

        [Required]
        [Display(Name = "Author")]
        public string author { get; set; }

        [Required]
        [Display(Name = "Language")]
        public string language { get; set; }



    }


}
