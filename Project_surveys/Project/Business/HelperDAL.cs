using Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.DAL
{
    public static class HelperDAL
    {
        private static surveysdbEntities1 surveysdb = Database.GetConnection();
        private static SurveyDAL surveyDal = new SurveyDAL();
        private static QuestionDAL questionDAL = new QuestionDAL();
        private static TextAnswerDAL txtan = new TextAnswerDAL();
        private static OptionChoicesDAL optionChoicesDAL = new OptionChoicesDAL();
        private static AnswersDAL answersDAL = new AnswersDAL();
        public static int GetNumberOfUsers()
        {
            return surveysdb.users.Count();

        }
        public static void DeleteUser(string userName)
        {
            users user = surveysdb.users.Where(x => x.User_name == userName).FirstOrDefault();
            surveysdb.users.Remove(user);
            surveysdb.SaveChanges();
        }
        public static void AddUser(users user)
        {
            surveysdb.users.Add(user);
            surveysdb.SaveChanges();

        }
        public static string GenerateRandomSurveyCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[10];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
        public static void AddTestSurveysToDataBase(surveys survey)
        {

            for (int i = 1; i <= 3; i++)
            {
                survey.Name += i;
                surveyDal.AddSurvey(survey);
            }
        }
        public static void DeleteSurveysFromDataBase(string userName)
        {
            List<surveys> surveys = surveyDal.GetAllSurveysByUserName(userName);
            foreach (var survey in surveys)
            {
                surveyDal.DeleteSurvey(survey);
            }
        }
        public static void DeleteTestSurveys(string userName)
        {
            List<surveys> surveys = surveysdb.surveys.Where(x => x.User_name == userName).ToList();
            surveys.RemoveAll(x => x.User_name == userName);
        }
        public static void AddSurvey(surveys survey)
        {
            surveyDal.AddSurvey(survey);
        }
        public static void DeleteSurvey(surveys survey)
        {
            surveyDal.DeleteSurvey(survey);
        }
        public static void AddQuestionsToDataBase(questions question)
        {
            for (int i = 1; i <= 3; i++)
            {
                question.Question_name += i;
                questionDAL.AddQuestion(question);
            }
        }
        public static void DeleteQuestionsBySurveyId(int survey_id)
        {
            List<questions> questions = questionDAL.GetQuestionsBySurveyId(survey_id);
            foreach (var item in questions)
            {
                questionDAL.DeleteQuestion(item);
            }
        }
        public static void DeleteQuestion(questions question)
        {
            questionDAL.DeleteQuestion(question);
        }
        public static void AddTextAnswersToDataBase(text_answers text_Answers)
        {
            for (int i = 1; i <= 3; i++)
            {
                text_Answers.Answer += i;
                txtan.AddTextAnswer(text_Answers);
            }
        }
        public static void DeleteTextAnswersFromDataBase(questions question)
        {
            List<text_answers> text_Answers = txtan.GetTextAnswers(question);
            foreach (var item in text_Answers)
            {
                txtan.DeleteTextAnswer(item);
            }
        }
        public static void AddOptionChoicesToDataBase(option_choices optionChoice)
        {
            for (int i = 1; i <= 3; i++)
            {
                optionChoice.Option_choices_name += i;
                optionChoicesDAL.AddOptionChoice(optionChoice);
            }
        }
        public static void DeleteOptionChoicesFromDataBase(questions question)
        {
            List<option_choices> optionChoice = optionChoicesDAL.GetOptionsChoices(question);
            foreach (var item in optionChoice)
            {
                optionChoicesDAL.DeleteOptionChoice(item);
            }
        }
        public static void DeleteOptionChoice(option_choices optionChoices)
        {
            optionChoicesDAL.DeleteOptionChoice(optionChoices);
        }
        public static void AddAnswersToDataBase(answers answer)
        {
            for (int i = 1; i <= 3; i++)
            {
                answersDAL.AddAnswer(answer);
            }
        }
        public static void DeleteAnswersFromDataBase(int optionChoiceId)
        {
            List<answers> answers = surveysdb.answers.Where(x => x.Question_option_id == optionChoiceId).ToList();
            foreach (var answer in answers)
            {
                answersDAL.DeleteAnswer(answer);
            }
        }
        public static void AddQuestion(questions question)
        {
            questionDAL.AddQuestion(question);
        }
    }
}