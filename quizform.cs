using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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




            // Now you have the list of quiz questions (quizQuestions) that you can use in your quizform
            // You can display these questions in your UI or perform any other necessary actions
            // For example, you can display the first question in the list as follows:

            List<Question> quizQuestions = QuestionLoader.LoadQuestions(numberOfQuestions, selectedTopics);
            var firstQuestion = quizQuestions.FirstOrDefault();
            if (firstQuestion != null)
            {
                label3.Text = firstQuestion.QuestionText;
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
        private void button1_Click(object sender, EventArgs e)
        {
            var currentQuestion = 0;
            List<Question> quizQuestions = QuestionLoader.LoadQuestions(numberOfQuestions, selectedTopics);
            var firstQuestion = quizQuestions.FirstOrDefault();
            if (firstQuestion != null)
            {
                label3.Text = firstQuestion.QuestionText;
                checkedListBox1.Items.AddRange(firstQuestion.Options.ToArray());
            }
            if (currentQuestion < quizQuestions.Count)
            {
                var question = quizQuestions[currentQuestion];
                label3.Text = question.QuestionText;
                checkedListBox1.Items.Clear();
                checkedListBox1.Items.AddRange(question.Options.ToArray());
                currentQuestion++;
            }
            else
            {
                MessageBox.Show("You have reached the end of the quiz");
            }

        }
    }
}
