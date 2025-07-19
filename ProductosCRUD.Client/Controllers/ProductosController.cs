using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductosCRUD.Client.Models;
using System.Net.Http;
using System.Text;

namespace ProductosCRUD.Client.Controllers
{
    public class ProductosController : Controller
    {
        //private readonly HttpClient _httpClient;
        //public ProductosController(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClient = httpClientFactory.CreateClient();
        //    _httpClient.BaseAddress = new Uri("http://localhost:5018");
        //}
        public async Task<IActionResult> Index()
        {
                return View();
        }

        //public async Task<IActionResult> Details(int id)
        //{

        //    var response = await _httpClient.GetAsync($"/api/v1/Productos/ObtenerProducto?id={id}");


        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        var producto = JsonConvert.DeserializeObject<Producto>(content);

        //        return View(producto);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Details"); 
        //    }
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(Producto producto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var json = JsonConvert.SerializeObject(producto);
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //        var response = await _httpClient.PostAsync("/api/v1/Productos/CrearProducto", content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Error al crear el producto.");
        //        }
        //    }
        //    return View(producto);
        //}

        //public async Task<IActionResult> Edit(int id)
        //{

        //    var response = await _httpClient.GetAsync($"/api/v1/Productos/ObtenerProducto?id={id}");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        var producto = JsonConvert.DeserializeObject<Producto>(content);

        //        return View(producto);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Details"); 
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, Producto producto)
        //{
        //    if (ModelState.IsValid)
        //    {
                

        //        var json = JsonConvert.SerializeObject(producto);
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //        var response = await _httpClient.PutAsync($"/api/v1/Productos/EditarProducto?id={id}", content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index", new { id });
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Error al actualizar el producto.");
        //        }
        //    }

        //    return View(producto);
        //}
        
        //public async Task<IActionResult> Delete(int id)
        //{            
        //    var response = await _httpClient.DeleteAsync($"/api/v1/Productos/EliminarProducto?id={id}");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        TempData["Error"] = "Error al eliminar el producto.";
        //        return RedirectToAction("Index");
        //    }
        //}


    }
}
