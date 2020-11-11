using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazasPerros.Models;
using RazasPerros.Models.ViewModels;
using RazasPerros.Repositories;
using System.Runtime.CompilerServices;


namespace RazasPerros.Controllers
{
    public class HomeController : Controller
    {
		public IActionResult Index(string id)
		{
			using perrosContext context = new perrosContext();
			Repository<Razas> reposr = new Repository<Razas>(context);
			RazasRepository repos = new RazasRepository(context);
			IndexViewModel vm = new IndexViewModel
			{
				Razas = id == null ? repos.GetRazas() : repos.GetRazasByLetraInicial(id),
				LetrasIniciales = repos.GetLetrasIniciales()
			};
			return View(vm);
		}
		[Route("Raza/{id}")]
		public IActionResult InfoPerro(string id)
		{
			perrosContext context = new perrosContext();
			RazasRepository repos = new RazasRepository(context);
			InfoPerroViewModel vm = new InfoPerroViewModel();
			vm.Raza = repos.GetRazaByNombre(id);

			if (vm.Raza == null)
			{
				return RedirectToAction("Index");
			}
			else
			{
				vm.OtrasRazas = repos.Get4RandomRazasExcept(id);
				return View(vm);
			}
		}

		public IActionResult RazasPorPais()
		{
			perrosContext context = new perrosContext();
			RazasRepository repos = new RazasRepository(context);
			RazasPaisesViewModel vm = new RazasPaisesViewModel();
			vm.Paises = repos.GetRazasByPais();
			return View(vm);
		}
	}
}
