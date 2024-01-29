using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Question
{
    public string Topic { get; set; }
    public string QuestionText { get; set; }
    public List<string> Options { get; set; }
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
        // Implement your logic to filter questions based on topics and limit the number
        // This is just a basic example, modify it based on your requirements
        var filteredQuestions = allQuestions;

        if (topics != null && topics.Count > 0)
        {
            filteredQuestions = filteredQuestions.FindAll(q => topics.Contains(q.Topic));
        }

        if (numberOfQuestions > 0 && numberOfQuestions < filteredQuestions.Count)
        {
            filteredQuestions = filteredQuestions.GetRange(0, numberOfQuestions);
        }

        return filteredQuestions;
    }
}
