using BookStore.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the Title of your book")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the author name")]
        public string Author { get; set; }
        [StringLength(500, MinimumLength = 30)]
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Please choose the language of your book")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Please choose the languages of your book")]
        public LanguageEnum LanguageEnum { get; set; }

        [Required(ErrorMessage = "Please enter the Total pages")]
        [Display(Name = "Total pages of Book")]
        public int? TotalPages { get; set; }

    }
}
