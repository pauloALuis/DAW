using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGestaoLivros.Models
{
    public class AutoresModel
    {
        public int id_autor { get; set; }
        [Required(ErrorMessage = " nome autor - Campo deve ser preenchido")]
        public string nome_autor { get; set; }
        public string email_autor { get; set; }
        public string obs_autor { get; set; }
        public DateTime dataNascimento_autor { get; set; }
    }
}