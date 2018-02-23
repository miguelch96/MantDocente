using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MantDocente.Tests
{
    class Elements
    {

        public static string URL_INICIAL = "http://localhost:50963/";


        //LOGIN
        public static readonly By txtUsuario = By.Id("Usuario");
        public static readonly By txtPassword = By.Id("Password");
        public static readonly By btnIngresar = By.Id("btnIngresar");
     
        //Main
        public static readonly By btnAgregar = By.Id("btnAgregar");
        public static readonly By btnEditar = By.Id("btnEditar");
        public static readonly By btnEliminar = By.Id("btnEliminar");
        public static readonly By divMsjAlertaMain = By.Id("mensajeAlertaMain");
        public static readonly By check = By.Id("check");
        public static readonly By divMainList = By.Id("divMainList");


        //Agregar Editar
        public static readonly By txtNombre = By.Id("Nombre");
        public static readonly By txtApellido = By.Id("Apellido");
        public static readonly By dtpFechaNacimiento = By.Id("FechaNacimiento");
        public static readonly By cbbTipoDocumento = By.Id("TipoDocumentoId");
        public static readonly By txtNroDocumento = (By.Id("NroDocumento"));
        public static readonly By rbMasculino = By.Id("rbMas");
        public static readonly By rbFemenino = By.Id("rbFem");
        public static readonly By cbEstado = By.Id("cbEstado");
        public static readonly By btnSubmit = By.Id("btnSubmit");
        public static readonly By divMsjAlertaAddEdit = By.Id("mensajeAlertaAddEdit");

        
    }
}
