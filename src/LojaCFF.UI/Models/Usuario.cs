using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaCFF.UI.Models
{
    [Table("Usuarios")]
    public class Usuario : Entity
    {
        [Column(TypeName = "varchar"), Required, StringLength(200)]
        public string Nome { get; set; }
        [Column(TypeName = "varchar"), Required, StringLength(100)]
        public string Email { get; set; }
        [Column(TypeName = "varchar"), Required, StringLength(40)]
        public string Senha { get; set; }
    }
}