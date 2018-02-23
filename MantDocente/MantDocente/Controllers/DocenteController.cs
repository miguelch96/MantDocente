using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MantDocente.Models;
using System.Data.Entity;


namespace MantDocente.Controllers
{
    public class DocenteController : ApiController
    {
    	//Hi
        [HttpGet]
        public IEnumerable<Docente> Get()
        {
            using (dbdocenteEntities entities = new dbdocenteEntities())
            {
                return entities.Docente.Include(x=>x.TipoDocumento).ToList();
            }
        }

        [HttpGet]
        public Docente Get(Int32 DocenteId)
        {
            using (dbdocenteEntities entities = new dbdocenteEntities())
            {
                var docente= entities.Docente.Include(x=>x.TipoDocumento).SingleOrDefault(x => x.DocenteId == DocenteId);
                if (docente == null)
                {
                    return null;
                }
                return entities.Docente.SingleOrDefault(x => x.DocenteId == DocenteId);
            }
        }

        [HttpPut]
        public bool Put(Int32 DocenteId,Docente docenteDto)
        {
            try
            {
                using (dbdocenteEntities entities = new dbdocenteEntities())
                {
                    var docente = entities.Docente.SingleOrDefault(x => x.DocenteId == DocenteId);
                    if (docente==null)
                    {
                        return false;
                    }
                    docente.Nombre = docenteDto.Nombre;
                    docente.Apellido = docenteDto.Apellido;
                    docente.TipoDocumentoId = docenteDto.TipoDocumentoId;
                    docente.NroDocumento = docenteDto.NroDocumento;
                    docente.FechaNacimiento = docenteDto.FechaNacimiento;
                    docente.Sexo = docenteDto.Sexo;
                    docente.Estado = docenteDto.Estado;
                    entities.SaveChanges();
                    return true;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        public Docente Post(Docente docente)
        {
            try
            {
                using (dbdocenteEntities entities = new dbdocenteEntities())
                {
                    if (docente == null)
                    {
                        return null;
                    }
                    docente.Estado="ACT";
                    entities.Docente.Add(docente);
                    entities.SaveChanges();

                    return docente;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpDelete]
        public bool Delete(int DocenteId)
        {
            using (dbdocenteEntities entities = new dbdocenteEntities())
            {
                var docente = entities.Docente.SingleOrDefault(x => x.DocenteId == DocenteId);
                if (docente == null)
                {
                    return false;
                }
                docente.Estado = "INA";
                entities.SaveChanges();
                return true;

            }
        }
    }
}
