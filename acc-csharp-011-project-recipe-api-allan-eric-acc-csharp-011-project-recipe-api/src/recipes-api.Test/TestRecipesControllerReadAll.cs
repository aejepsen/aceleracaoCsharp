using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System;
using recipes_api.Models;
using recipes_api.Services;
using recipes_api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace recipes_api.Test;

public class TestRecipesControllerReadAll
{
    public static IEnumerable<object[]> RecipeServiceTestData()
    {
        yield return new object[]
        {
            new List<Recipe>() 
            {
                new Recipe() { 
                    Name = "test1", 
                    RecipeType = RecipesType.salty ,
                    PreparationTime = 1, 
                    Ingredients = new List<string>() { "ingredient1", "ingredient2", "ingredient3" },
                    Directions = "test1", 
                    Rating = 10 },

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
                    Rating = 10 }
             }
        };        
    }

    [Theory]
    [MemberData(nameof(RecipeServiceTestData))]
    public void TestReadAll(List<Recipe> expected)
    {
        // Arrange
        RecipesController recipesController = new(new RecipeService());

        // Act
        var result = recipesController.Get();
        var successResult = result as OkObjectResult;

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        successResult.Value.Should().BeEquivalentTo(expected);
        recipesController._service.GetRecipes().Should().BeEquivalentTo(expected);
    }
}