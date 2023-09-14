using Microsoft.AspNetCore.Mvc;
using pokedex.Models;
using pokedex.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pokemon.Test
{
    public class PokemonServiceFake : IPokemonService
    {
        private readonly List<PokemonCatched> pokemonFake;
        public PokemonServiceFake()
        {
            pokemonFake = new List<PokemonCatched>()
            {                
                new PokemonCatched()
                {
                    Id = 1,
                    Name = "Chespin",
                    Level = 50,
                    Types = new string[] { "Grama", "Dragon" },
                },
                new PokemonCatched()
                {
                    Id = 2,
                    Name = "Fennekin",
                    Level = 60,
                    Types = new string[] { "Fire", "Ghost" },
                },
                new PokemonCatched()
                {
                    Id = 3,
                    Name = "Froakie",
                    Level = 70,
                    Types = new string[] { "Water", "Dragon" },
                },
            };
        }

        public PokemonCatched Add(PokemonCatched newPokemon)
        {
            var existPokemon = pokemonFake.Where(pokemon => pokemon.Id == newPokemon.Id).FirstOrDefault();

            if (existPokemon != null)
                return null;

            pokemonFake.Add(newPokemon);

            return newPokemon;
        }
        public IEnumerable<PokemonCatched> GetAll()
        {
            return pokemonFake;
        }
        public PokemonCatched? GetById(int id)
        {
            return pokemonFake.Where(pokemon => pokemon.Id == id).FirstOrDefault();
        }
        public void Put (PokemonCatched newPokemon)
        {

            for (int i = 0; i < pokemonFake.Count; i++)
            {
                if (pokemonFake[i].Id == newPokemon.Id)
                {
                    pokemonFake[i].Name = newPokemon.Name;
                    pokemonFake[i].Level = newPokemon.Level;
                    pokemonFake[i].Types = newPokemon.Types;

                    return;
                }
            }

            throw new KeyNotFoundException("Pokemon not exist");
        }
        public void Remove(int id)
        {
            var pokemon = pokemonFake.FirstOrDefault(pokemon => pokemon.Id == id);

            if (pokemon != null)
            {
                pokemonFake.Remove(pokemon);
                
                return;
            }

            throw new KeyNotFoundException("Pokemon not exist");
        }
    }
}
