using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Entities;

namespace TP.DatatAccess
{
    class QuizDAO
    {
        public static List<Quiz> FindAll()
        {
            List<Quiz> quiz = new List<Quiz>();
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
                string requette = "SELECT  id,title    FROM t_quiz";

                commande = new MySqlCommand(requette, connexion);

                //Envoyer la commande pour lire les donées à partir de la base de donées 
                dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {
                    Quiz qui = new Quiz
                    {
                       
                        QuizId = (int)dataReader["id"],
                        title= dataReader["title"].ToString(),

                    };
                    quiz.Add(qui);

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

            return quiz;
        }
    }
}
