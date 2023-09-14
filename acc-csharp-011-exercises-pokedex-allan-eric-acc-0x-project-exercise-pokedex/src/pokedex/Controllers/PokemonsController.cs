﻿using pokedex.Models;
using pokedex.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using pokedex.API_Requests;

namespace pokedex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {        
        private readonly IPokemonService _service;

        public PokemonsController(IPokemonService service)
        {
           _service = service;
        }
        
        [HttpGet("/pokemon")]
        public ActionResult<IEnumerable<PokemonCatched>> Get()
        {
            var pokemonsList = _service.GetAll();

            return Ok(pokemonsList);
        }
        
        [HttpGet("/pokemon/{id:int}")]
        public ActionResult<PokemonCatched> GetById(int id)
        {
            var pokemon = _service.GetById(id);

            if (pokemon != null)
                return Ok(pokemon);

            return NotFound("Pokemon not exist");
        }
        
        [HttpPost("/pokemon")]
        public ActionResult Post(PokemonRequest pokemonRequest)
        {
            if (pokemonRequest.Id <= 0)
                return BadRequest("Id must be greater than 0");

            var pokemonPost = new PokemonCatched()
            {
                Id = pokemonRequest.Id,
                Name = pokemonRequest.Name,
                Level = pokemonRequest.Level,
                Types = pokemonRequest.Types,
            };

            var newPokemon = _service.Add(pokemonPost);

            if (newPokemon != null)
                return CreatedAtAction("GetById", new { id = newPokemon.Id }, newPokemon);

            return BadRequest("This newPokemon.id already exist");
        }

        
        [HttpPut("/pokemon/{id:int}")]
        public ActionResult Put(int id, PokemonRequest pokemonRequest)
        {
            var pokemonPut = new PokemonCatched()
            {
                Id = id,
                Name = pokemonRequest.Name,
                Level = pokemonRequest.Level,
                Types = pokemonRequest.Types,
            };

            try
            {
                _service.Put(pokemonPut);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Pokemon {id} not exist");
            }

            return Ok($"Pokemon {id} updated");
        }


        
        [HttpDelete("/pokemon/{id:int}")]
        public ActionResult Remove(int id)
        {
            try
            {
                _service.Remove(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Pokemon {id} not exist");
            }

            return Ok("Pokemon deleted");
        }
    }
}
