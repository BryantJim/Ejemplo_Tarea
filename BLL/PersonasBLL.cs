using Microsoft.EntityFrameworkCore;
using Prestamo.Data;
using Prestamo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Prestamo.BLL
{
    public class PersonasBLL
    {
        private ApplicationDbContext _contexto;

        public PersonasBLL(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public  bool Guardar(Personas persona)
        {
            if (!Existe(persona.PersonaId))
                return Insertar(persona);
            else
                return Modificar(persona);
        }

        private  bool Existe(int id)
        {
            bool Existencia = false;

            try
            {
                Existencia = _contexto.Personas.Any(x => x.PersonaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return Existencia;
        }

        private bool Insertar(Personas persona)
        {
            bool Insertado = false;

            try
            {
                _contexto.Personas.Add(persona);
                Insertado = (_contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
           
            return Insertado;
        }

        private  bool Modificar(Personas persona)
        {
            bool Modificado = false;

            try
            {
                _contexto.Entry(persona).State = EntityState.Modified;
                Modificado = (_contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
        
            return Modificado;
        }

        public  bool Eliminar(int id)
        {
            bool Eliminado = false;


            try
            {
                var persona = _contexto.Personas.Find(id);
                _contexto.Entry(persona).State = EntityState.Deleted;
                Eliminado = (_contexto.SaveChanges() > 0);

            }
            catch (Exception)
            {
                throw;
            }
            return Eliminado;
        }

        public  Personas Buscar(int id)
        {
            Personas persona = new Personas();


            try
            {
                persona = _contexto.Personas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
           
            return persona;
        }

        public List<Personas> GetList(Expression<Func<Personas, bool>> persona)
        {
            List<Personas> Lista = new List<Personas>();

            try
            {
                Lista = _contexto.Personas.Where(persona).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }
    }
}
