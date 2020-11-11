using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using RazasPerros.Models;
using RazasPerros.Repositories;
using RazasPerros.Models.ViewModels;

namespace RazasPerros.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class HomeController : Controller
    {
        perrosContext context;
        public IWebHostEnvironment Enviroment { get; set; }
        public HomeController(perrosContext con, IWebHostEnvironment env)
        {
            context = con;
            Enviroment = env;
        }


        [Route("Administrador")]
        [HttpGet]
        public IActionResult Index()
        {
            Repository<Razas> repos = new Repository<Razas>(context);
            return View(repos.GetAll().Where(x => x.Eliminado == 0).OrderBy(x => x.Nombre));
        
        }

        [Route("Administrador/Agregar")]
        [HttpPost]
        public IActionResult Agregar()
        {
            Repository<Paises> repos = new Repository<Paises>(context);
            InfoPerroViewModel vm = new InfoPerroViewModel();
            vm.Paises = repos.GetAll();
            return View(vm);
            
        }

        [HttpPost]
        public IActionResult Agregar(InfoPerroViewModel vm)
        {
            try
            {
                if (vm.Archivo == null)
                {
                    ModelState.AddModelError("", "Seleccione una imagen.");

                    return View(vm);
                }
                else
                {
                    if (vm.Archivo.ContentType != "image/jpeg" || vm.Archivo.Length > 1024 * 1024 * 2)
                    {
                        ModelState.AddModelError("", "Tiene que ser un archivo jpg de menos de 2MB.");

                        return View(vm);
                    }
                }
                Repository<Razas> repos = new Repository<Razas>(context);
                repos.Insert(vm.Raza);
                FileStream fls = new FileStream(Enviroment.WebRootPath + "/imgs_perros/" + vm.Raza.Id + "_0.jpg", FileMode.Create);
                vm.Archivo.CopyTo(fls);
                fls.Close();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }
        }

        [Route("Administrador/Editar/{id}")]
        [HttpGet]
        public IActionResult Editar(int id)
        {
            Repository<Razas> reposRazas = new Repository<Razas>(context);
            Repository<Paises> repos = new Repository<Paises>(context);
            Repository<Caracteristicasfisicas> reposCaracteristicas = new Repository<Caracteristicasfisicas>(context);
            Repository<Estadisticasraza> reposEstadisticas = new Repository<Estadisticasraza>(context);
            InfoPerroViewModel vm = new InfoPerroViewModel();
            vm.Raza = reposRazas.GetById(id);
            vm.Paises = repos.GetAll();
            vm.Raza.Caracteristicasfisicas = reposCaracteristicas.GetById(id);
            vm.Raza.Estadisticasraza = reposEstadisticas.GetById(id);


            if (vm.Raza == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (System.IO.File.Exists(Enviroment.WebRootPath + "/imgs_perros/" + vm.Raza.Id + "_0.jpg"))
            {
                vm.Imagen = vm.Raza.Id + "_0.jpg";
            }
            else
            {
                vm.Imagen = "NoPhoto.jpg";
            }

            return View(vm);
        }


        [HttpPost]
        public IActionResult Editar(InfoPerroViewModel vm)
        {
            try
            {
                if (vm.Archivo != null)
                {
                    if (vm.Archivo.ContentType != "image/jpeg" || vm.Archivo.Length > 1024 * 1024 * 2)
                    {
                        ModelState.AddModelError("", "Tiene que ser un archivo jpg de menos de 2MB.");
                        Repository<Paises> repospaises = new Repository<Paises>(context);
                        vm.Paises = repospaises.GetAll();
                        return View(vm);
                    }
                }

                Repository<Razas> repos = new Repository<Razas>(context);
                var raza = repos.GetById(vm.Raza.Id);
                Repository<Caracteristicasfisicas> reposCaracteristicas = new Repository<Caracteristicasfisicas>(context);
                var car = reposCaracteristicas.GetById(vm.Raza.Caracteristicasfisicas.Id);
                Repository<Estadisticasraza> reposEstadisticas = new Repository<Estadisticasraza>(context);
                var es = reposEstadisticas.GetById(vm.Raza.Estadisticasraza.Id);

                if (raza != null && car != null && es != null)
                {
                    raza.Nombre = vm.Raza.Nombre;
                    raza.IdPais = vm.Raza.IdPais;
                    raza.OtrosNombres = vm.Raza.OtrosNombres;
                    raza.PesoMin = vm.Raza.PesoMin;
                    raza.PesoMax = vm.Raza.PesoMax;
                    raza.AlturaMin = vm.Raza.AlturaMin;
                    raza.AlturaMax = vm.Raza.AlturaMax;
                    raza.EsperanzaVida = vm.Raza.EsperanzaVida;
                    raza.Descripcion = vm.Raza.Descripcion;

                    car.Patas = vm.Raza.Caracteristicasfisicas.Patas;
                    car.Cola = vm.Raza.Caracteristicasfisicas.Cola;
                    car.Hocico = vm.Raza.Caracteristicasfisicas.Hocico;
                    car.Pelo = vm.Raza.Caracteristicasfisicas.Pelo;
                    car.Color = vm.Raza.Caracteristicasfisicas.Color;

                    es.NivelEnergia = vm.Raza.Estadisticasraza.NivelEnergia;
                    es.FacilidadEntrenamiento = vm.Raza.Estadisticasraza.FacilidadEntrenamiento;
                    es.EjercicioObligatorio = vm.Raza.Estadisticasraza.EjercicioObligatorio;
                    es.AmistadDesconocidos = vm.Raza.Estadisticasraza.AmistadDesconocidos;
                    es.AmistadPerros = vm.Raza.Estadisticasraza.AmistadPerros;
                    es.NecesidadCepillado = vm.Raza.Estadisticasraza.NecesidadCepillado;

                    repos.Update(raza);
                    reposCaracteristicas.Update(car);
                    reposEstadisticas.Update(es);

                    if (vm.Archivo != null)
                    {
                        FileStream fs = new FileStream(Enviroment.WebRootPath + "/imgs_perros/" + vm.Raza.Id + "_0.jpg", FileMode.Create);
                        vm.Archivo.CopyTo(fs);
                        fs.Close();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                Repository<Paises> repos = new Repository<Paises>(context);

                vm.Paises = repos.GetAll();

                return View(vm);
            }

        }
        [HttpPost]
        public IActionResult Eliminar(Razas r)
        {
            try
            {
                using (perrosContext context = new perrosContext())
                {
                    Repository<Razas> repos = new Repository<Razas>(context);
                    var razas = repos.GetById(r.Id);
                    razas.Eliminado = 1;
                    repos.Update(razas);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(r);
            }
        }
    }
}