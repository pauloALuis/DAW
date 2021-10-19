using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecto2.Models.Repository
{
   public interface IAutorRpository
    {
        Autore Autore(int id);
        IEnumerable<Autore> GetAllAutores();
        Autore AddAutor(Autore autore);
        Autore UpdateAutor(Autore autorChanges);

        Autore deleteAutor(int id);

    }
}
