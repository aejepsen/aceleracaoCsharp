﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex.Models
{
    public class PokemonCatched
    {           
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Level { get; set; }
        public string[]? Types { get; set; }
    }
}
