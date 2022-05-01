using System;
using System.Collections.Generic;

namespace ProgressiveForm.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime CurrentDate { get; set; }
        public DateTime LicenseExpiration { get; set; }
        public int TypeId { get; set; }
        public int NumberOfCopies { get; set; }

        public virtual Type Type { get; set; } = null!;
    }
}
