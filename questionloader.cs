using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Question
{
    [JsonProperty("topic")]

    public string Topic { get; set; }
    [JsonProperty("questiontext")]

    public string QuestionText { get; set; }
    [JsonProperty("options")]

    public List<string> Options { get; set; }
    [JsonProperty("answer")]

    public string Answer { get; set; }
}

public class QuestionWrapper
{
    [JsonProperty("Question")]
    public List<Question> Questions { get; set; }
}

public static class QuestionLoader
{



    public static List<Question> LoadQuestions(int numberOfQuestions, List<string> topics)
    {
        string jsonFilePath = Path.Combine(Application.StartupPath, "questions.json");

        string json = File.ReadAllText(jsonFilePath);

        // Declare questionWrapper outside the try block
        QuestionWrapper questionWrapper = null;

        try
        {
            // Deserialize the JSON into the QuestionWrapper class
            questionWrapper = JsonConvert.DeserializeObject<QuestionWrapper>(json);
        }
        catch (Exception ex)
        {
            // Log or print the exception details
            Console.WriteLine($"Error deserializing JSON: {ex.Message}");
        }

        // Check if deserialization was successful before accessing the Questions property
        if (questionWrapper != null)
        {
            // Select the questions
            var allQuestions = questionWrapper.Questions;
            var selectedQuestions = SelectQuestions(allQuestions, numberOfQuestions, topics);
            return selectedQuestions;
        }

        // Return null or an empty list if deserialization fails
        return new List<Question>();
    }

    private static List<Question> SelectQuestions(List<Question> allQuestions, int numberOfQuestions, List<string> topics)
    {
        // Create a dictionary to store the count of questions for each subject
        Dictionary<string, int> subjectCounts = new Dictionary<string, int>();

        // Initialize the count for each subject to 0
        foreach (var topic in topics)
        {
            subjectCounts[topic] = 0;
        }

        // Filter questions based on topics
        var filteredQuestions = allQuestions.Where(q => topics.Contains(q.Topic)).ToList();
        //drop copy of questions
        filteredQuestions = filteredQuestions.Distinct().ToList();

        int targetQuestionsPerSubject = 0;

        // see if the number of questions is divisible by the number of topics
        if (numberOfQuestions % topics.Count == 0)
        {
             targetQuestionsPerSubject = (numberOfQuestions / topics.Count);
        }
        else
        {
             targetQuestionsPerSubject = (numberOfQuestions / topics.Count + 1);
        }

        // Iterate through the filtered questions and select questions evenly from each subject
        List<Question> selectedQuestions = new List<Question>();

        foreach (var question in filteredQuestions)
        {
            if (subjectCounts[question.Topic] < targetQuestionsPerSubject)
            {
                selectedQuestions.Add(question);
                subjectCounts[question.Topic]++;
            }
        }

        // Check if the selectedQuestions count is less than numberOfQuestions
        // If so, add more questions from the beginning of filteredQuestions
        while (selectedQuestions.Count < numberOfQuestions && filteredQuestions.Count > 0)
        {
            selectedQuestions.Add(filteredQuestions[0]);
            filteredQuestions.RemoveAt(0);
        }
        // if more then remove
        while (selectedQuestions.Count > numberOfQuestions)
        {
            selectedQuestions.RemoveAt(0);
        }

        return selectedQuestions;
    }


}
