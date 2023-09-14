using System;
using System.Collections.Generic;

namespace PopularLibraries.Models
{
    public partial class Language
    {
        public Language()
        {
            Orms = new HashSet<Orm>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Orm> Orms { get; set; }
    }
}