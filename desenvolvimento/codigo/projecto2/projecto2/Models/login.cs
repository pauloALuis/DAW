//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projecto2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class login
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public login()
        {
            this.Funcionarios = new HashSet<Funcionario>();
            this.Utentes = new HashSet<Utente>();
        }
    
        public int id_login { get; set; }
        [Required(ErrorMessage = "Email login - Campo deve ser preenchido")]

        public string email { get; set; }
        [Required(ErrorMessage = "Nome de utilizador - Campo deve ser preenchido")]

        public string username { get; set; }
        [Required(ErrorMessage = "password - Campo deve ser preenchido")]

        public string password { get; set; }
        public Nullable<bool> flagAtiva { get; set; }
        [Required(ErrorMessage = "Tipo de previlegio  - Campo deve ser preenchido")]
        public Nullable<bool> privilegio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Utente> Utentes { get; set; }
    }
}