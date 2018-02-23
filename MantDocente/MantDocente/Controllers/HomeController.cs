using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MantDocente.Models;
using MantDocente.ViewModels;
using System.Transactions;
using System.Data.Entity;

namespace MantDocente.Controllers
{
    public class HomeController : Controller
    {
        
        public dbdocenteEntities context { get; set; }
        public DocenteController docenteController { get; set; }

        public HomeController()
        {
            context = new dbdocenteEntities();
            docenteController = new DocenteController();
        }
        // GET: Login
        public ActionResult Index()
        {
            
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (model.Usuario.Equals("admin") && model.Password.Equals("admin"))
            {
                Session["Nombre"] = "Sergio";
                return RedirectToAction("Main");
            }
            else
            {
                TempData["message"] = "Ingresar datos correctos.";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }


        public ActionResult Main()
        {
            using (DocenteController docenteController = new DocenteController())
            {
                var docentes = docenteController.Get();
                ViewBag.ListaDocentes = docentes;
                return View();
            }
        }


        public ActionResult AddEditDocente(Int32? DocenteId)
        {
            var viewModel = new AddEditDocenteViewModel();

            if (DocenteId.HasValue)
            {
                var objDocente = docenteController.Get(DocenteId.Value);

                viewModel.CargarDatos(objDocente);
            }

            viewModel.LstTipoDocumento = context.TipoDocumento.ToList();
            viewModel.LstSexo.Add("Masculino");
            viewModel.LstSexo.Add("Femenino");
            return View(viewModel);
        }

        public ActionResult DeleteDocente(Int32? DocenteId)
        {
            try
            {
                if (DocenteId.HasValue)
                {
                    var docente = docenteController.Get(DocenteId.Value);

                    if (docente.Estado == "INA")
                    {
                        TempData["message"] = "El docente ya ha sido eliminado.";
                        return RedirectToAction("Main");
                    }


                    
                    using (var Transaction = new TransactionScope())
                    {
                        docenteController.Delete(docente.DocenteId);
                        Transaction.Complete();
                    }
                }

                TempData["message"] = "Docente eliminado con éxito.";

            }
            catch
            {
                TempData["message"] = "No se ha podido eliminar el docente con éxito";
            }


            return RedirectToAction("Main");
        }

        [HttpPost]
        public ActionResult AddEditDocente(AddEditDocenteViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.LstTipoDocumento = context.TipoDocumento.ToList();
                    model.LstSexo.Add("Masculino");
                    model.LstSexo.Add("Femenino");
                    TempData["message"] = "Debe corregir o completar los campos marcados.";
                    TryUpdateModel(model);
                    return View(model);
                }
                using (var Transaction = new TransactionScope())
                {
                    var docente = new Docente();

                    docente.Nombre = model.Nombre;
                    docente.Apellido = model.Apellido;
                    docente.FechaNacimiento = model.FechaNacimiento;
                    docente.TipoDocumentoId = model.TipoDocumentoId;
                    docente.NroDocumento = model.NroDocumento;
                    docente.Sexo = model.Sexo;
                    if (model.Estado.Equals(true))
                        docente.Estado = "ACT";
                    else
                        docente.Estado = "INA";

                    if (model.DocenteId.HasValue)
                    {
                        docenteController.Put(model.DocenteId.Value,docente);
                        TempData["message"] = "Docente editado con éxito.";
                    }

                    else
                    {
                        docenteController.Post(docente);
                        TempData["message"] = "Docente agregado con éxito.";
                    }
                    
                    Transaction.Complete();
                }
               
                return RedirectToAction("Main");
            }
            catch (Exception ex)
            {
                var viewModel = new AddEditDocenteViewModel();
                viewModel.LstTipoDocumento = context.TipoDocumento.ToList();
                model.LstSexo.Add("Masculino");
                model.LstSexo.Add("Femenino");
                TryUpdateModel(model);
                TempData["message"] = "Por favor, ingresar los datos correctamente.";
                return View(model);
            }
        }
    }
}