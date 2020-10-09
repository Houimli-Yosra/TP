using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Entities;

namespace TP.DatatAccess
{
  public static  class AccesDonees
    {
        public static  List<Question> FindAll()
        {
            // il faut donnée le chemin de code 
            string chaineDeConnexion = Properties.Settings.Default.ConnexionString;
            MySqlConnection connexion = new MySqlConnection(chaineDeConnexion);
            MySqlCommand commande = null;
            MySqlDataReader dataReader = null;


            try
            {
                //ouvrir la connexion
                connexion.Open();

                // Préparer l'envoi de la commande Envoie d'une commande 
                string requette = "SELECT  id, enonce, multipleChoice, ordre  FROM t_question";
                
                commande = new MySqlCommand(requette, connexion);

                //Envoyer la commande pour lire les donées à partir de la base de donées 
                dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {


                }
            }
        }
           
        
    }
}
