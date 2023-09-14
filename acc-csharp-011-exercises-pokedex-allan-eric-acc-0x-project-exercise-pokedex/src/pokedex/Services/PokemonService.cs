﻿﻿using pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex.Services
{
    public class PokemonService : IPokemonService
    {
        public List<PokemonCatched> pokemons;

        public PokemonService()
        {
            pokemons = new List<PokemonCatched>();
        }

        public PokemonCatched Add(PokemonCatched newPokemon)
        {
            var existPokemon = pokemons.Where(pokemon => pokemon.Id == newPokemon.Id).FirstOrDefault();

            if (existPokemon != null)
                return null;

            pokemons.Add(newPokemon);

            return newPokemon;
        }
        public IEnumerable<PokemonCatched> GetAll()
        {
            return pokemons;
        }
        public PokemonCatched? GetById(int id)
        {
            return pokemons.Where(pokemon => pokemon.Id == id).FirstOrDefault();
        }
        public void Put (PokemonCatched newPokemon)
        {
            /*
            for (int i = 0; i < Pokemon.Count; i++)
            {
                if (Pokemon[i].Id == newPokemon.Id)
                {
                    Pokemon[i].Name = newPokemon.Name;
                    Pokemon[i].Level = newPokemon.Level;
                    Pokemon[i].Types = newPokemon.Types;

                    return;
                }
            }
            */
            foreach (var pokemon in pokemons)
            {
                if (pokemon.Id == newPokemon.Id)
                {
                    pokemon.Name = newPokemon.Name;
                    pokemon.Level = newPokemon.Level;
                    pokemon.Types = newPokemon.Types;

                    return;
                }
            }
            

            throw new KeyNotFoundException("Pokemon not found");
        }
        public void Remove(int id)
        {
            var pokemon = pokemons.FirstOrDefault(p => p.Id == id);

            if (pokemon != null)
            {
                pokemons.Remove(pokemon);

                return;
            }

            throw new KeyNotFoundException("Pokemon not found");
        }
    }
}
