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
        private int currentQuestion = 0;
        private int selectedAnswer;




        public quizform(string userName, int numberOfQuestions, List<string> selectedTopics)
        {
            InitializeComponent();

            // Store the received information
            this.userName = userName;
            this.numberOfQuestions = numberOfQuestions;
            this.selectedTopics = selectedTopics;

;



            // Now you have the list of quiz questions (quizQuestions) that you can use in your quizform
            // You can display these questions in your UI or perform any other necessary actions
            // For example, you can display the first question in the list as follows:

            //List<Question> quizQuestions = QuestionLoader.LoadQuestions(numberOfQuestions, selectedTopics);
            //var firstQuestion = quizQuestions.FirstOrDefault();
            //if (firstQuestion != null)
            //{
            //    label3.Text = firstQuestion.QuestionText;
            //    checkedListBox1.Items.AddRange(firstQuestion.Options.ToArray());
            //}

            // Customize the form based on the received information
            label1.Text = $"Hello, {userName}! You have chosen {numberOfQuestions} questions. Good luck.";

            //auto generate first click
            button1_Click(null, null);



        }
 



        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //save the selected answer
            selectedAnswer = checkedListBox1.Items.IndexOf(checkedListBox1.SelectedItem);


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<Question> quizQuestions = QuestionLoader.LoadQuestions(numberOfQuestions, selectedTopics);
            var runningQuestion = quizQuestions[currentQuestion];
            label3.Text = runningQuestion.QuestionText;
            checkedListBox1.Items.Clear();
            checkedListBox1.Items.AddRange(runningQuestion.Options.ToArray());

            if (e != null)
            {

                if (selectedAnswer == null)
                {
                    MessageBox.Show("Please select an answer");
                }
                else
                {
                    var question = quizQuestions[currentQuestion];
                    var correctAnswer = question.Answer.ToLower();
                    var selectedcorrectanswer = question.Options[selectedAnswer].ToString().ToLower();

                    if (selectedcorrectanswer == correctAnswer) 
                    {
                        MessageBox.Show("Correct Answer");
                    }
                    else
                    {
                        MessageBox.Show("Wrong Answer");
                    }

                    currentQuestion++;

                    // Check if all questions are answered
                    if (currentQuestion >= numberOfQuestions)
                    {
                        MessageBox.Show("Quiz completed!");
                        // You might want to handle the completion of the quiz here
                        // For example, display a summary or navigate to another form
                    }

                    // Display the next question
                    var nextQuestion = quizQuestions[currentQuestion];
                    label3.Text = nextQuestion.QuestionText;
                    checkedListBox1.Items.Clear();
                    checkedListBox1.Items.AddRange(nextQuestion.Options.ToArray());


                }
            }
        }

    }
}
