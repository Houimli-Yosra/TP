using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Entities;

namespace TP.DatatAccess
{
 public   class ReponseDAO
    {
        public static List<Reponse> FindAll(int idquestion)
        {
            List<Reponse> Reponses = new List<Reponse>();
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
                string requette = "SELECT  id, texte, Correct, questionid  FROM t_reponse WHERE questionid="+ idquestion;

                commande = new MySqlCommand(requette, connexion);

                //Envoyer la commande pour lire les donées à partir de la base de donées 
                dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {
                    Reponse Rep = new Reponse
                    {
                        Id = (int)dataReader["id"],
                        Texte = dataReader["texte"].ToString(),
                        Idquestion = (int)dataReader["idquestion "],

                    };
                    Reponses.Add(Rep);

                }
            }
            catch (Exception ex)
            {
                //TODO FAIRE QUELQUE CHOSE (log...)

            }
            finally
            {
                //FERMER la connexion
                dataReader.Close();
                commande.Dispose();

                connexion.Close();
            }

            return Reponses;
        }
    }
}
