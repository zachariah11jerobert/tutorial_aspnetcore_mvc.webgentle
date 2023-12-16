using BookStore.Enums;
using BookStore.Helpers;
using Microsoft.AspNetCore.Http;
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
        public int LanguageId { get; set; }
        public string Language { get; set; }

        [Required(ErrorMessage = "Please enter the Total pages")]
        [Display(Name = "Total pages of Book")]
        public int? TotalPages { get; set; }

        [Display(Name = "Choose the Cover photo of your book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }

        [Display(Name = "Choose the Gallery Images of your book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }

        [Display(Name = "Upload your Book in pdf format")]
        [Required]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }
    }
}
