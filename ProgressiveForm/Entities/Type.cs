using System;
using System.Collections.Generic;

namespace ProgressiveForm.Entities
{
    public partial class Type
    {
        public Type()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Type1 { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
