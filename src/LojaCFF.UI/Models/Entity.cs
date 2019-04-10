using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaCFF.UI.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}