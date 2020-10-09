using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Entities
{
  public  class Question
    {
        public int QuesId { get; set; }
        public string Enonce { get; set; }
        public bool EstChoixMultiple { get; set; }
        public int Ordre { get; set; }
        public List<Reponse> Reponses { get; set; }


    }
}
