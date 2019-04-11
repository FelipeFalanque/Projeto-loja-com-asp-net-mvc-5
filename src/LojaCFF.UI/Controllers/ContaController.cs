using LojaCFF.UI.Data;
using LojaCFF.UI.Infra.Helpers;
using LojaCFF.UI.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace LojaCFF.UI.Controllers
{
    public class ContaController : Controller
    {
        private readonly LojaCFFDataContext _contexto = new LojaCFFDataContext();

        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            var login = new LoginViewModel { ReturnURL = ReturnUrl };

            return View(login);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            var user = _contexto.Usuarios.FirstOrDefault(u => u.Email.ToLower() == login.Email.ToLower());

            if (user == null)
                ModelState.AddModelError("Email", "Email não encontrado.");
            else
            {
                if (user.Senha != login.Senha.Encrypt())
                    ModelState.AddModelError("Senha", "Senha errada.");
            }

            if (ModelState.IsValid)
            {
                //Autenticar
                FormsAuthentication.SetAuthCookie(login.Email, login.PermanecerLogado);

                // Segura url vazia e url imbutida (somente redireciona para urls do sistema)
                if (!string.IsNullOrEmpty(login.ReturnURL) && Url.IsLocalUrl(login.ReturnURL))
                {
                    return Redirect(login.ReturnURL);
                }

                return RedirectToAction("Index", "Home");
            }

            return View(login);
        }

        [HttpGet]
        public ActionResult LogOut(string ReturnUrl)
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }
        

        protected override void Dispose(bool disposing)
        {
            _contexto.Dispose();
        }
    }
}