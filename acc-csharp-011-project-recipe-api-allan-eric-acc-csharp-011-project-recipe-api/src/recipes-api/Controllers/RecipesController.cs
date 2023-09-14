using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;
using recipes_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
// ok
namespace recipes_api.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipesController : ControllerBase
{    
    public readonly IRecipeService _service;
    
    public RecipesController(IRecipeService service)
    {
        this._service = service;        
    }

    //Read
    [HttpGet]
    public IActionResult Get()
    {
        var recipes = _service.GetRecipes();
        return Ok(recipes);   
    }

    //Read
    [HttpGet("{name}", Name = "GetRecipe")]
    public IActionResult Get(string name)
    {                
        var recipe = _service.GetRecipe(name);
        if (recipe == null)
        {
            return NotFound();
        }
        return Ok(recipe);
    }

    [HttpPost]
    public IActionResult Create([FromBody]Recipe recipe)
    {
        if (recipe == null || _service.RecipeExists(recipe.Name))
        {
            return BadRequest();
        }
        _service.AddRecipe(recipe);
        return CreatedAtRoute("GetRecipe", new { name = recipe.Name }, recipe);
    }

    [HttpPut("{name}")]
    public IActionResult Update(string name, [FromBody]Recipe recipe)
    {
        if (recipe == null || recipe.Name != name || !_service.RecipeExists(name))
        {
            return BadRequest();
        }
        var recipeToUpdate = _service.GetRecipe(name);
        if (recipeToUpdate == null)
        {
            return NotFound();
        }
        _service.UpdateRecipe(recipe);
        return Ok(recipe);
    }

    [HttpDelete("{name}")]
    public IActionResult Delete(string name)
    {
        if (!_service.RecipeExists(name) || name == null || name == "" )
        {
            return NotFound();
        }
        _service.DeleteRecipe(name);
        return NoContent();
    }    
}
