using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System;
using recipes_api.Models;
using recipes_api.Services;
using recipes_api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace recipes_api.Test;

public class TestRecipesControllerUpdate
{
    public static IEnumerable<object[]> RecipeServiceTestData()
{
        yield return new object[]

        {

                new Recipe() { 
                    Name = "test1", 
                    RecipeType = RecipesType.salty ,
                    PreparationTime = 1, 
                    Ingredients = new List<string>() { "ingredient1", "ingredient2", "ingredient3" },
                    Directions = "test1", 
                    Rating = 10 },

                new List<Recipe>
                {

                    new Recipe() { 
                        Name = "test2", 
                        RecipeType = RecipesType.sweet, 
                        PreparationTime = 1, 
                        Ingredients = new List<string>() { "ingredient1", "ingredient2", "ingredient3" },
                        Directions = "test2", 
                        Rating = 10 },

                    new Recipe() { 
                        Name = "test3", 
                        RecipeType = RecipesType.drink, 
                        PreparationTime = 1, 
                        Ingredients = new List<string>() { "ingredient1", "ingredient2", "ingredient3" },
                        Directions = "test3", 
                        Rating = 10 },

                    new Recipe() { 
                        Name = "test4", 
                        RecipeType = RecipesType.sweet, 
                        PreparationTime = 1, 
                        Ingredients = new List<string>() { "ingredient1", "ingredient2", "ingredient3" },
                        Directions = "test4", 
                        Rating = 10 },

                    new Recipe() { 
                        Name = "test1", 
                        RecipeType = RecipesType.salty ,
                        PreparationTime = 1, 
                        Ingredients = new List<string>() { "ingredient1", "ingredient2", "ingredient3" },
                        Directions = "test1", 
                        Rating = 10 },
             }
        };        
    }


    [Theory]
    [MemberData(nameof(RecipeServiceTestData))]
    public void TestUpdate(string entryName, Recipe entryRecipe, List<Recipe> expected)
    {
        // Arrange
        RecipesController recipesController = new(new RecipeService());

        // Act
        var result = recipesController.Update(entryName, entryRecipe);
        var successResult = result as OkObjectResult;
        var actual = successResult.Value as Recipe;

        // Assert
        actual.Should().BeEquivalentTo(entryRecipe);
        recipesController._service.GetRecipes().Should().BeEquivalentTo(expected);

    }
}