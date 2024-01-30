namespace Karuna_assignment_quiz
{
    public partial class inputform : Form
    {

        // Variables to store user input
        private string userName;
        private int numberOfQuestions;
        private List<string> selectedTopics;

        public inputform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // name of the person


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // amount of question between 30 to 50



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the selected subjects topics
            var subjectt_list = subjects.CheckedItems;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate and gather user input
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter your name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox2.Text, out numberOfQuestions) || numberOfQuestions < 30 || numberOfQuestions > 50)
            {
                MessageBox.Show("Please enter a valid number of questions (30-50).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectedTopics = subjects.CheckedItems.Cast<string>().ToList();
            if (selectedTopics.Count < 2)
            {
                MessageBox.Show("Please select at least 2 topics.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Store user input in variables
            userName = textBox1.Text;

            // Now, you can transition to the quiz form or create a new form for the quiz
            // For simplicity, let's display a message with the gathered information
            string selectedTopicsText = string.Join(", ", selectedTopics);
            string message = $"Hello, {userName}! You have chosen {numberOfQuestions} questions from the following topics: {selectedTopicsText}. Let's start the quiz!";
            //MessageBox.Show(message, "Quiz Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Optionally, you can create a new form for the quiz and show it
            // QuizForm quizForm = new QuizForm(userName, numberOfQuestions, selectedTopics);
            // quizForm.Show();
            // Create and show the QuizForm, passing the gathered information
            quizform quizForm = new quizform(userName, numberOfQuestions, selectedTopics);

            quizForm.Show();
            // Close the current form
            this.Hide();
        }
    }
}
