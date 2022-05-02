using ProgressiveForm.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProgressiveForm.Models
{
    public class IndexViewModel
    {
        public string NextActivePage { get; set; }
        public string CurrentActivePage { get; set; }



        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is Required")]        
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;

        [RequiredIf("CurrentActivePage", "Middle",ErrorMessage ="Current Date is Required")]
        public string? CurrentDate { get; set; }
        
        [RequiredIf("CurrentActivePage", "Middle",ErrorMessage = "License Expiration Date is Required")]
        public string? LicenseExpiration { get; set; }
        public int TypeId { get; set; }
        public int NumberOfCopies { get; set; }



        public bool IsAlreadyPresent { get; set; } = false;
        public List<Users2> OldRecords { get; set; } = new List<Users2>();
    }
}
