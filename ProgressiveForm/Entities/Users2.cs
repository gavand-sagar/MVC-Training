using System;
using System.Collections.Generic;

namespace ProgressiveForm.Entities
{
    public partial class Users2
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime CurrentDate { get; set; }
        public DateTime LicenseExpiration { get; set; }
        public int Type { get; set; }
        public int NumberOfCopies { get; set; }

        public virtual Type TypeNavigation { get; set; } = null!;
    }
}
