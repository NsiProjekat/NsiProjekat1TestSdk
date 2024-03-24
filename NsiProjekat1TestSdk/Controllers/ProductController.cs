using Microsoft.AspNetCore.Mvc;
using NsiProjekat1Sdk.Sdk;
using NsiProjekat1Sdk.Application.Client;
using NsiProjekat1Sdk.Application.Models;
using NsiProjekat1Sdk.Sdk.Dto;
using Refit;

namespace NsiProjekat1TestSdk.Controllers;

public class ProductController() : ControllerBase
{
    [HttpPost("createProduct")]
    public async Task<IActionResult> Create(NsiProjekat1SdkProductCreateDto product)
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5140"),
        };

        var api = RestService.For<INsiProjekat1SdkApi>(httpClient);
        var client = new NsiProjekat1SdkClient(api);
        
        var headers = new Dictionary<string, string> 
        {
            {"X-De-Username", "dusan"},
            {"X-De-Password", "test"}
        };
        
        var result = await client.CreateProductAsync(new NsiProjekat1SdkProductRequestModel(
            product.CompanyId, 
            product.Name,
            product.Description,
            "http://localhost:5140", 
            headers));
        return Ok(result);
    }
}