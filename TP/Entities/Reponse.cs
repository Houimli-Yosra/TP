using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Entities
{
 public  class Reponse
    {
        public int Id { get; set; }
        public string Texte { get; set; }
        public bool EstCorrecte { get; set; }
        public int Idquestion  { get; set; }




    }
}
