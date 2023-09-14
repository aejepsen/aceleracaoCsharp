using System;
using System.Collections.Generic;

namespace PopularLibraries.Models
{
    public partial class Database
    {
        public Database()
        {
            Providers = new HashSet<Provider>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Provider> Providers { get; set; }
    }
}