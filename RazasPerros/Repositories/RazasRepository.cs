using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazasPerros.Models;
using Microsoft.EntityFrameworkCore;
using RazasPerros.Models.ViewModels;

namespace RazasPerros.Repositories
{
    public class RazasRepository:Repository<Razas>
	{
		perrosContext context = new perrosContext();
		public RazasRepository(perrosContext con) : base(con){}
		public IEnumerable<RazaViewModel> GetRazas()
		{
			return context.Razas.Where(x => x.Eliminado == 0).OrderBy(x => x.Nombre).Select(x => new RazaViewModel
				{
					Id = x.Id,
					Nombre = x.Nombre
				});
		}

		public IEnumerable<RazaViewModel> GetRazasByLetraInicial(string letra)
		{
			return GetRazas().Where(x => x.Nombre.StartsWith(letra));
		}


		public IEnumerable<char> GetLetrasIniciales()
		{
			return context.Razas.OrderBy(x => x.Nombre)
				.Select(x => x.Nombre.First());
		}

		public Razas GetRazaByNombre(string nombre)
		{
			nombre = nombre.Replace("-", " ");
			return context.Razas
				.Include(x => x.Estadisticasraza)
				.Include(x => x.Caracteristicasfisicas)
				.Include(x => x.IdPaisNavigation)
				.FirstOrDefault(x => x.Nombre == nombre);
		}

		public IEnumerable<RazaViewModel> Get4RandomRazasExcept(string nombre)
		{
			nombre = nombre.Replace("-", " ");
			Random r = new Random();
			return context.Razas
				.Where(x => x.Nombre != nombre)
				.OrderBy(x => r.Next())
				.Take(4)
				.Select(x => new RazaViewModel { Id = x.Id, Nombre = x.Nombre });
		}

		public Razas GetRazaById(int id)
		{
			return context.Razas.Where(x => x.Eliminado == 0).Include(x => x.Estadisticasraza).Include(x => x.IdPaisNavigation).Include(x => x.Caracteristicasfisicas).FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Paises> GetPaises()
		{
			return context.Paises.OrderBy(x => x.Nombre);
		}
		public IEnumerable<Paises> GetRazasByPais()
		{
			return context.Paises.Include(x => x.Razas).OrderBy(x => x.Nombre);
		}

		public override bool Validate(Razas entidad)
		{
			if (string.IsNullOrEmpty(entidad.Nombre))
			{
				throw new Exception("Falta el nombre");
			}


			if (entidad.PesoMin <= 0 || entidad == null)
			{
				throw new Exception("Falta el peso minimo");
			}

			if (entidad.PesoMax <= 0 || entidad == null)
			{
				throw new Exception("Falta el peso maximo");
			}


			if (string.IsNullOrEmpty(entidad.IdPaisNavigation.Nombre))
			{
				throw new Exception("Falta el pais");
			}

			if (entidad.AlturaMin <= 0 || entidad == null)
			{
				throw new Exception("Falta el la altura minima");
			}

			if (entidad.AlturaMax <= 0 || entidad == null)
			{
				throw new Exception("Falta el la altura maxima");
			}

			if (entidad.EsperanzaVida <= 0 || entidad == null)
			{
				throw new Exception("Falta la esperanza de vida");
			}


			if (string.IsNullOrEmpty(entidad.Descripcion))
			{
				throw new Exception("Falta descripción");
			}

			if (string.IsNullOrEmpty(entidad.OtrosNombres))
			{
				throw new Exception("Falta agregar otros nombres similares");
			}



			if (string.IsNullOrEmpty(entidad.Caracteristicasfisicas.Cola))
			{
				throw new Exception("Faltan las características de la cola");
			}

			if (string.IsNullOrEmpty(entidad.Caracteristicasfisicas.Pelo))
			{
				throw new Exception("Faltan las características del pelo");
			}

			if (string.IsNullOrEmpty(entidad.Caracteristicasfisicas.Color))
			{
				throw new Exception("Faltan las características del color");
			}

			if (string.IsNullOrEmpty(entidad.Caracteristicasfisicas.Patas))
			{
				throw new Exception("Faltan las características de las patas");
			}

			

			if (string.IsNullOrEmpty(entidad.Caracteristicasfisicas.Hocico))
			{
				throw new Exception("Faltan las características del hocico");
			}

			


			if (entidad.Estadisticasraza.NecesidadCepillado < 0 || entidad.Estadisticasraza.NecesidadCepillado > 10)
			{
				throw new Exception("Los valores de necesidad de cepillado van entre 0 y 10");
			}

			if (entidad.Estadisticasraza.AmistadDesconocidos < 0 || entidad.Estadisticasraza.AmistadDesconocidos > 10)
			{
				throw new Exception("Los valores de nivel de amistad con desconocidos van entre 0 y 10");
			}

			if (entidad.Estadisticasraza.FacilidadEntrenamiento < 0 || entidad.Estadisticasraza.FacilidadEntrenamiento > 10)
			{
				throw new Exception("Los valores de nivel de felicidad al entrenar van entre 0 y 10");
			}


			if (entidad.Estadisticasraza.AmistadPerros < 0 || entidad.Estadisticasraza.AmistadPerros > 10)
			{
				throw new Exception("Los valores de nivel de amistad con otros perros van entre 0 y 10");
			}

			if (entidad.Estadisticasraza.NivelEnergia < 0 || entidad.Estadisticasraza.NivelEnergia > 10)
			{
				throw new Exception("Los valores de nivel de energia van entre 0 y 10");
			}

		

			return true;
		}
	}
}

