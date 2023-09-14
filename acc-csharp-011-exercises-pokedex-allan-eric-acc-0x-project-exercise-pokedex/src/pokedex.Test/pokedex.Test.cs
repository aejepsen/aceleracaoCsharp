using pokedex.Models;
using pokedex.Controllers;
using pokedex.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;
using pokemon.Test;
using FluentAssertions;
using pokedex.API_Requests;

namespace pokedex.Test
{
    public class PokemonsControllerTest
    {
        private readonly PokemonsController _controllerFake;
        private readonly PokemonServiceFake _serviceFake;

        public PokemonsControllerTest()
        {
            _serviceFake = new PokemonServiceFake();

            _controllerFake = new PokemonsController(_serviceFake);
        }

        // Testes GET
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var pokemonsFake = _controllerFake.Get();

            Assert.IsType<OkObjectResult>(pokemonsFake.Result);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllPokemons()
        {
            var pokemonsFake = _controllerFake.Get().Result as OkObjectResult;

            var pokemonList = Assert.IsType<List<PokemonCatched>>(pokemonsFake.Value);
            Assert.Equal(3, pokemonList.Count);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            var notExist = _controllerFake.GetById(1000);

            Assert.IsType<NotFoundObjectResult>(notExist.Result);
        }
        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            var Id = 1;

            var pokemonFake = _controllerFake.GetById(Id);

            pokemonFake.Result.Should().BeOfType<OkObjectResult>("O tipo esperado é do tipo {0}", typeof(OkObjectResult));
        }
        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            var Id = 1;

            var pokemonFake = _controllerFake.GetById(Id).Result as OkObjectResult;

            var pokemon = Assert.IsType<PokemonCatched>(pokemonFake.Value);
            pokemon.Name.Should().Be("Chespin");
        }

        // Testes POST
        [Fact]
        public void Add_PokemonWithoutId_ReturnsBadRequest()
        {
            var pokemon = new PokemonRequest()
            {
                Name = "Oshawott",
                Level = 80,
                Types = new string[] { "Water", "Fighting" }
            };

            var notExist = _controllerFake.Post(pokemon);

            Assert.IsType<BadRequestObjectResult>(notExist);
        }

        [Fact]
        public void Add_ValidPokemonPassed_ReturnsCreatedResponse()
        {
            var pokemon = new PokemonRequest()
            {
                Id = 4,
                Name = "Oshawott",
                Level = 80,
                Types = new string[] { "Water", "Fighting" }
            };

            var pokemonFake = _controllerFake.Post(pokemon);

            Assert.IsType<CreatedAtActionResult>(pokemonFake);
        }

        [Fact]
        public void Add_ValidPokemonPassed_ReturnedResponseHasCreatedItem()
        {
            var pokemon = new PokemonRequest()
            {
                Id = 4,
                Name = "Oshawott",
                Level = 80,
                Types = new string[] { "Water", "Fighting" }
            };

            var pokemonFake = _controllerFake.Post(pokemon) as CreatedAtActionResult;

            var newPokemon = Assert.IsType<PokemonCatched>(pokemonFake.Value);
            newPokemon.Name = "Oshawott";
        }

        // Testes PUT
        [Fact]
        public void PutById_ExistingIdPassed_ReturnsOkResult()
        {
            var Id = 1;

            var pokemon = new PokemonRequest()
            {
                    Name = "Chespin",
                    Level = 50,
                    Types = new string[] { "Grama", "Dragon" }
            };

            var pokemonFake = _controllerFake.Put(Id, pokemon);

            Assert.IsType<OkObjectResult>(pokemonFake);
        }

        [Fact]
        public void PutById_IdNotFound_ReturnsNotFoundResult()
        {
            var Id = 4;

            var pokemon = new PokemonRequest()
            {
                Name = "Snivy",
                Level = 80,
                Types = new string [] { "Snake", "Grass"}
            };

            var notExist = _controllerFake.Put(Id, pokemon);

            Assert.IsType<NotFoundObjectResult>(notExist);
        }


        // Testes DELETE
        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            var Id = 4;

            var notExist = _controllerFake.Remove(Id);

            Assert.IsType<NotFoundObjectResult>(notExist);
        }
        [Fact]
        public void Remove_ExistingIdPassed_ReturnsOkResult()
        {
            var Id = 1;

            var pokemonFake = _controllerFake.Remove(Id);

            Assert.IsType<OkObjectResult>(pokemonFake);
        }

    }
}
