using Servidor2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor2.SessionHelpers
{
    public class SessionHelper : Controller
    {
        public bool UsuarioLogueado(ISession session)
        {
            var value = session.GetString("usuario");
            if (value == null)
                return false;

            return true;
        }
        public LoginModel GetUsuario(ISession session)
        {
            var value = session.GetString("usuario");
            if (value == null)
                return null;

            return JsonConvert.DeserializeObject<LoginModel>(value);
        }
        public void SetUsuario(ISession session, string value)
        {
            LoginModel login = new LoginModel();
            login.Usuario = value;
            session.SetString("usuario", JsonConvert.SerializeObject(login));
        }

        public static LoginModel UsuarioCorrecto(string nombre)
        {
            //AppDbContext _context = new AppDbContext();
            //return _context.IcargoUsuarios.Where(o=>o.Active == true &&
            //o.User_Name == nombre).FirstOrDefault();
            return new LoginModel();
        }

    }
        
}
