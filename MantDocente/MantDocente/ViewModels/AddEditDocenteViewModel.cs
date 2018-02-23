using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MantDocente.Models;

namespace MantDocente.ViewModels
{
    public class AddEditDocenteViewModel
    {
        public Int32? DocenteId { get; set; }

        [Required]
        public string Nombre { get; set; } = String.Empty;

        [Required]
        public string Apellido { get; set; } = String.Empty;

        [Required]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now.Date;

        [Required]
        public string Sexo { get; set; } = String.Empty;

        [Required]
        public bool Estado { get; set; } = true;


        [Required]
        public int TipoDocumentoId { get; set; }


        [Required]
        public string NroDocumento { get; set; } = String.Empty;

        public List<TipoDocumento> LstTipoDocumento { get; set; } = new List<TipoDocumento>();
        public List<String> LstSexo { get; set; } = new List<String>();

        public void CargarDatos(Docente objdocente)
        {
            DocenteId = objdocente.DocenteId;
            Nombre = objdocente.Nombre;
            Apellido = objdocente.Apellido;
            FechaNacimiento = Convert.ToDateTime(objdocente.FechaNacimiento).Date;
            Sexo = objdocente.Sexo;
            TipoDocumentoId = objdocente.TipoDocumento.TipoDocumentoId;
            NroDocumento = objdocente.NroDocumento;
            if (objdocente.Estado.Equals("ACT"))
                Estado = true;
            else if(objdocente.Estado.Equals("INA"))
                Estado = false;

        }
    }
}