using System;
using System.Collections.Generic;

namespace ProgressiveForm.Entities
{
    public partial class Type
    {
        public Type()
        {
            Users = new HashSet<User>();
            Users2s = new HashSet<Users2>();
        }

        public int Id { get; set; }
        public string Type1 { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Users2> Users2s { get; set; }
    }
}
