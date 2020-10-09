using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP.DatatAccess;
using TP.Entities;

namespace TP
{
    public partial class Form1 : Form
    {
        public List<Question> questions;
        public List<Quiz> quiz;
        public List<Reponse> Reponses;


        private const int MARGE = 12;
        private const int SIZE = 75;
        private int nbNouveauBouton = 0;
        private int dernierTabIndex = 50;
        private int tempsEcoule = 0;


        private Question selected;
        public Form1()
        {
            InitializeComponent();
            //InitData();
            comboBox1.DisplayMember = "title";
            comboBox1.DataSource = QuizDAO.FindAll();


        }

       /* private void InitData()
        {
            questions = QuestionDAO.FindAll();
            quiz = QuizDAO.FindAll();
            Reponses = ReponseDAO.FindAll();


           

        }*/




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //QuestionDAO ques; 

            //quiz = QuizDAO.FindAll();
            // comboBox1.DisplayMember = "id";
            // comboBox1.DataSource = QuizDAO.FindAll();
            // comboBox1.Text = quiz.;
           
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void BtnCommencer_Click(object sender, EventArgs e)
        {
            List<Quiz> quiz = QuizDAO.FindAll();
            //Quiz quizz;
            Quiz quizz= comboBox1.SelectedItem as Quiz;//il faut caster selectedItem retourne un objet dc il faut  que cet objet devin un quiz


            List<Question> questions = QuestionDAO.FindAll(quizz.QuizId);

            Question q = questions[0];

            groupBox1.Text = q.Enonce;

            List<Reponse> Reponses = ReponseDAO.FindAll(quizz.QuizId);
            Reponse reponse= Reponses[0];
            RadioButton nouveauBouton = new RadioButton
            {

                Name = "radioButton1",
                Location = new Point((MARGE + SIZE) * nbNouveauBouton + MARGE, 365),
               // Name = "RadioButtonNew" + ++nbNouveauBouton,
                Size = new Size(SIZE, 23),
                TabIndex = dernierTabIndex++,
                Text = reponse.Texte,
                 



                // Location = new Point(409, 315);


                //TabStop = true;

                // UseVisualStyleBackColor = true;
                // CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            };






        }

       
    }
}
