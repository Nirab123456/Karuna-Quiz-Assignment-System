using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Karuna_assignment_quiz
{
    public partial class quizform : Form
    {
        private string userName;
        private int numberOfQuestions;
        private List<string> selectedTopics;




        public quizform(string userName, int numberOfQuestions, List<string> selectedTopics)
        {
            InitializeComponent();

            // Store the received information
            this.userName = userName;
            this.numberOfQuestions = numberOfQuestions;
            this.selectedTopics = selectedTopics;


            List<Question> quizQuestions = QuestionLoader.LoadQuestions(numberOfQuestions, selectedTopics);

            // Now you have the list of quiz questions (quizQuestions) that you can use in your quizform
            // You can display these questions in your UI or perform any other necessary actions
            // For example, you can display the first question in the list as follows:
            var firstQuestion = quizQuestions.FirstOrDefault();


            if (firstQuestion != null)
            {
                label2.Text = firstQuestion.QuestionText;
                Console.WriteLine(firstQuestion.QuestionText);
                checkedListBox1.Items.AddRange(firstQuestion.Options.ToArray());
            }

            // Customize the form based on the received information
            label1.Text = $"Hello, {userName}! You have chosen {numberOfQuestions} questions. Good luck.";


        }
 



        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
