using System;
using System.Collections.Generic;

namespace PopularLibraries.Models
{
    public partial class Provider
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public long Ormid { get; set; }
        public long DatabaseId { get; set; }

        public virtual Database Database { get; set; } = null!;
        public virtual Orm Orm { get; set; } = null!;
    }
}