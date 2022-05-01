using System.ComponentModel.DataAnnotations;

namespace ProgressiveForm.Models
{
    public class IndexViewModel
    {
        public string ActivePage { get; set; }



        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string CurrentDate { get; set; }
        public string LicenseExpiration { get; set; }
        public int TypeId { get; set; }
        public int NumberOfCopies { get; set; }
    }
}
