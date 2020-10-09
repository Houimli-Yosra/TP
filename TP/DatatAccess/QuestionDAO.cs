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
  public static  class QuestionDAO
    {
        public static  List<Question> FindAll(int quizzId)//c'est ma méthode 
        {
            List<Question> questions = new List<Question>();
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
                string requette = "SELECT  id, enonce, multipleChoice, ordre  FROM t_question WHERE quizId=" +quizzId;
                
                commande = new MySqlCommand(requette, connexion);

                //Envoyer la commande pour lire les donées à partir de la base de donées 
                dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {
                    Question ques = new Question
                    {
                        Enonce = dataReader["enonce"].ToString(),
                        EstChoixMultiple = (bool)dataReader["multipleChoice"],
                        QuesId = (int)dataReader["id"],
                        Ordre = (int)dataReader["ordre"]
                    };
                    questions.Add(ques);

                }
            }
            catch (Exception ex)
            {
                //TODO FAIRE QUELQUE CHOSE (log...)
               
            }
            finally
            {
                //FERMER la connexion
                dataReader?.Close();
                commande?.Dispose();

                connexion.Close();
            }

            return questions; 
        }
           
        
    }
}
