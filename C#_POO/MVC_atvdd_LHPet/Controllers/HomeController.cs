using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LHPet.Models;

namespace LHPet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Instancias do Tipo Cliente
        Cliente cliente1 = new Cliente(1, "Diego", "000.000.000-33", "diego@gmail.com", "Sol");
        Cliente cliente2 = new Cliente(2, "Diegol", "000.000.000-00", "diego@gmail.com", "Lua");
        Cliente cliente3 = new Cliente(3, "Zezin", "333.000.000-00", "zezin@gmail.com", "Leão");
        Cliente cliente4 = new Cliente(4, "Alfredin", "111.000.000-33", "alfredin@gmail.com", "Zizau");
        Cliente cliente5 = new Cliente(5, "Whind", "777.000.000-33", "whind@gmail.com", "Coco");

        //lista de Clientes e atribuir os clientes
        List<Cliente> listaClientes = new List<Cliente>();
        listaClientes.Add(cliente1);
        listaClientes.Add(cliente2);
        listaClientes.Add(cliente3);
        listaClientes.Add(cliente4);
        listaClientes.Add(cliente5);

        ViewBag.listaClientes = listaClientes;

        //Instancia do tipo fornecedor
        Fornecedor fornecedor1 = new Fornecedor(1,"DP33 PET S/A", "33.333.333/3333-33", "dp33@pets/a.org")
        Fornecedor fornecedor2 = new Fornecedor(2,"DP33 PET S/A", "33.333.333/3333-33", "dp33@pets/a.org")
        Fornecedor fornecedor3 = new Fornecedor(3,"DP33 PET S/A", "33.333.333/3333-33", "dp33@pets/a.org")
        Fornecedor fornecedor4 = new Fornecedor(4,"DP33 PET S/A", "33.333.333/3333-33", "dp33@pets/a.org")
        Fornecedor fornecedor5 = new Fornecedor(5,"DP33 PET S/A", "33.333.333/3333-33", "dp33@pets/a.org")

        //lista de Fornecedores e atribuir os fornecedores
        List<Fornecedor> listaFornecedores = new List<Fornecedor>();
        listaFornecedores.Add(fornecedor1);
        listaFornecedores.Add(fornecedor2);
        listaFornecedores.Add(fornecedor3);
        listaFornecedores.Add(fornecedor4);
        listaFornecedores.Add(fornecedor5);

        ViewBag.listaFornecedores = listaFornecedores;

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
