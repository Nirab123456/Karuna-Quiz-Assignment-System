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
        private int selectedAnswer = -1; // Initialize with an invalid index

        public quizform(string userName, int numberOfQuestions, List<string> selectedTopics)
        {
            InitializeComponent();

            // Store the received information
            this.userName = userName;
            this.numberOfQuestions = numberOfQuestions;
            this.selectedTopics = selectedTopics;

            // Customize the form based on the received information
            label1.Text = $"Hello, {userName}! You have chosen {numberOfQuestions} questions. Good luck.";

            // Auto-generate first click
            button1_Click(null, null);
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Save the selected answer index
            selectedAnswer = checkedListBox1.SelectedIndex;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<Question> quizQuestions = QuestionLoader.LoadQuestions(numberOfQuestions, selectedTopics);

            // Check if the current question is valid
            if (currentQuestion < quizQuestions.Count)
            {
                var question = quizQuestions[currentQuestion];
                label3.Text = question.QuestionText;

                checkedListBox1.Items.Clear();
                checkedListBox1.Items.AddRange(question.Options.ToArray());

                // Check if an answer is selected before proceeding
                if (selectedAnswer == -1)
                {
                    if ( e != null) {

                        MessageBox.Show("Please select an answer");
                        return;
                    }
                    else
                    {
                        return;
                    }

                }

                var correctAnswer = question.Answer.ToLower();
                var selectedCorrectAnswer = question.Options[selectedAnswer].ToString().ToLower();

                if (selectedCorrectAnswer == correctAnswer)
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
                    return;
                }

                // Display the next question
                var nextQuestion = quizQuestions[currentQuestion];
                label3.Text = nextQuestion.QuestionText;
                checkedListBox1.Items.Clear();
                checkedListBox1.Items.AddRange(nextQuestion.Options.ToArray());

                // Reset selected answer for the next question
                selectedAnswer = -1;
            }
        }
    }
}
