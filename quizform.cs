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

        private int correctanswered = 0;

        //private double currentPercentage()
        //    {

        //    if (currentQuestion == 0) { return 0; }

        //    else
        //    {
        //        return  (correctanswered / numberOfQuestions) * 100;
        //    }

        //    }



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
            label4.Text = $"CURRENT.Q : {currentQuestion + 1}";
            List<Question> quizQuestions = QuestionLoader.LoadQuestions(numberOfQuestions, selectedTopics);

            // Check if the current question is valid
            if (currentQuestion < quizQuestions.Count)
            {
                var question = quizQuestions[currentQuestion];
                label3.Text = question.QuestionText;
                label7.Text = question.Topic;

                checkedListBox1.Items.Clear();
                checkedListBox1.Items.AddRange(question.Options.ToArray());

                // Check if an answer is selected before proceeding
                if (selectedAnswer == -1)
                {
                    if (e != null)
                    {

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
                    correctanswered++;
                    label2.Text = $"CURRENT MARK : {correctanswered}";
                    double percentage = ((double)correctanswered / numberOfQuestions) * 100;
                    label5.Text = $"CURRENT PERCENTAGE: {percentage:F2}%";

                }
                else
                {

                    MessageBox.Show("Wrong Answer");

                }

                currentQuestion++;

                // Check if all questions are answered
                if (currentQuestion >= numberOfQuestions)
                {
                    MessageBox.Show($"QUIZ DONE");
                    checkedListBox1.Enabled = false;
                    button1.Enabled = false;
                    double percentage = ((double)correctanswered / numberOfQuestions) * 100;
                    if (percentage >= 95)
                    {
                        label6.Text = $"Congratulations {userName}! You are truly exceptional.";
                    }
                    else if (percentage >= 80)
                    {
                        label6.Text = $"Well done {userName}! You have passed with my respect and a commendable score.";
                    }
                    else if (percentage >= 60)
                    {
                        label6.Text = $"Congratulations {userName}! You've passed the exam. It's a satisfactory result, but there's room for improvement.";
                    }
                    else if (percentage >= 40)
                    {
                        label6.Text = $"Keep pushing {userName}! You're close, but more effort is needed to reach 60% and pass.";
                    }
                    else if (percentage >= 20)
                    {
                        label6.Text = $"Stay determined {userName}! More hard work is required to achieve a 60% pass.";
                    }
                    else if (percentage >= 0)
                    {
                        label6.Text = $"Stay focused {userName}! Work diligently to reach a 60% pass.";
                    }
                    else
                    {
                        label6.Text = $"Stay committed {userName}! Work hard to improve your performance.";
                    }



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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void quizform_Load(object sender, EventArgs e)
        {

        }



        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
