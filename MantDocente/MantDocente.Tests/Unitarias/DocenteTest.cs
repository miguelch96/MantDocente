using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MantDocente.Controllers;
using MantDocente.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MantDocente.Tests
{
    [TestFixture]
    public class DocenteTest
    {
        private DocenteController controller;

        [SetUp]
        protected void SetUp()
        {
            controller=new DocenteController();
        }

        [Test]
        public void AgregarTest()
        {

            Docente docente = new Docente()
            {
                Nombre = "Nombre Prueba",
                Apellido = "Apellido Prueba",
                TipoDocumentoId = 1,
                NroDocumento = "12345678",
                FechaNacimiento = DateTime.Now,
                Sexo = "Masculino"
            };

            var result = controller.Post(docente);
            Assert.IsTrue(result.DocenteId != 0);
        }

        [Test]
        public void AgregarFailTest()
        {
            var result = controller.Post(null);
            Assert.IsNull(result);
        }

        [Test]
        public void AgregarFailCatchTest()
        {
            Docente docente = new Docente()
            {             
                TipoDocumentoId = 1,            
                FechaNacimiento = DateTime.Now,
                Sexo = "Masculino"
            };
            var result = controller.Post(docente);
            Assert.IsNull(result);
        }

        [Test]
        public void EditarTest()
        {
            var controller = new DocenteController();

            Docente docente = new Docente()
            {
                Nombre = "Nombre Prueba Editar",
                Apellido = "Apellido Prueba",
                TipoDocumentoId = 2,
                NroDocumento = "12345678",
                FechaNacimiento = DateTime.Now,
                Sexo = "Masculino",
                Estado = "ACT"
            };

            var result = controller.Put(1, docente);
            Assert.IsTrue(result);
        }

        [Test]
        public void EditarFailTest()
        {
            var controller = new DocenteController();

            Docente docente = new Docente()
            {
                Nombre = "Nombre Prueba Editar",
                Apellido = "Apellido Prueba",
                TipoDocumentoId = 2,
                NroDocumento = "12345678",
                FechaNacimiento = DateTime.Now,
                Sexo = "Masculino",
                Estado = "ACT"
            };

            var result = controller.Put(10000, docente);
            Assert.IsTrue(result==false);
        }

        [Test]
        public void EditarFailCatchTest()
        {
            var controller = new DocenteController();

            Docente docente = new Docente()
            {            
                TipoDocumentoId = 2,
                FechaNacimiento = DateTime.Now,
                Sexo = "Masculino",
                Estado = "ACT"
            };

            var result = controller.Put(1, docente);
            Assert.IsFalse(result);
        }

        [Test]
        public void EliminarTest()
        {
            var controller = new DocenteController();
            var result = controller.Delete(1);
            Assert.IsTrue(result);
        }

        [Test]
        public void EliminarFailTest()
        {
            var controller = new DocenteController();
            var result = controller.Delete(10000);
            Assert.IsTrue(result==false);
        }

        [Test]
        public void ListarTest()
        {
            var controller = new DocenteController();
            var result = controller.Get();
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void BuscarTest()
        {
            var controller = new DocenteController();
            var result = controller.Get(1);
            Assert.IsNotNull(result);
        }

        [Test]
        public void BuscarFailTest()
        {
            var controller = new DocenteController();
            var result = controller.Get(10000);
            Assert.IsNull(result);
        }
    }
}