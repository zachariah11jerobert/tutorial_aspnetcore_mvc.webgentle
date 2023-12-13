using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookModel
    {
        [DataType(DataType.DateTime)]
        //[DataType(DataType.Date)]
        //[DataType(DataType.Time)]
        [Display(Name ="Choose Date and time")]
        public string MyField { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Enter your password")]
        public string MyPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Enter your Email")]
        [EmailAddress]
        public string MyEmailAddress { get; set; }
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the Title of your book")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the author name")]
        public string Author { get; set; }
        [StringLength(500, MinimumLength = 30)]
        public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        [Required(ErrorMessage = "Please enter the Total pages")]
        [Display(Name ="Total pages of Book")]
        public int? TotalPages { get; set; }

    }
}
