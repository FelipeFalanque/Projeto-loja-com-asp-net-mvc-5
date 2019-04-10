using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaCFF.UI.Models
{
    public class LoginViewModel
    {
        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(10)]
        public string Senha { get; set; }

        public bool PermanecerLogado { get; set; }

        public string ReturnURL { get; set; }
    }
}