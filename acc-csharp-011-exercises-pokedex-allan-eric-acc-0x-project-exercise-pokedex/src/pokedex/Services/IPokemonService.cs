﻿﻿using Microsoft.AspNetCore.Mvc;
using pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex.Services
{
    public interface IPokemonService
    {
       public PokemonCatched Add(PokemonCatched newPokemon);

       public IEnumerable<PokemonCatched> GetAll();

       public PokemonCatched? GetById(int id);

       public void Put (PokemonCatched newPokemon);

       public void Remove(int id);
    }
}
