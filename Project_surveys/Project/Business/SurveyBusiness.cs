using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;
using Project.Interface;
using Project.Business.DAL;

namespace Project.Business
{
    class SurveyBusiness
    {
        private IUser userDAL;
        private ISurvey surveyDAL;
        private IQuestion questionDAL;
        private ITextAnswers textAswersDAL;
        private IOptionChoice optionChoiceDAL;
        private IAnswers answerDAL;
        private IInputType inputTypeDAL;

        //UserDAL
        public void AddUser(users user)
        {
            userDAL.AddUser(user);
        }
        public void DeleteUserByName(string userName)
        {
            userDAL.DeleteUserByName(userName);
        }
        public List<users> GetAllUsers()
        {
            return userDAL.GetAllUsers();
        }
        public users GetUserByName(string username)
        {
            return userDAL.GetUserByName(username);
        }
        public void UpdateUserPassword(string userName, string newPassword)
        {
            users user = userDAL.GetUserByName(userName);
            userDAL.UpdateUser(user, newPassword);
        }
        //SurveyDAL
        public void AddSurvey(surveys survey)
        {
            surveyDAL.AddSurvey(survey);
        }
        public void DeleteSurvey(string surveyCode)
        {
            surveys survey = surveyDAL.GetSurveyBySurveyCode(surveyCode);
            List<questions> questions = questionDAL.GetQuestionsBySurveyId(survey.Id).ToList();
            foreach (var question in questions)
            {
                if (inputTypeDAL.GetInputTypeName(question) == "text")
                {
                    List<text_answers> texts = textAswersDAL.GetTextAnswers(question);
                    foreach (var text in texts)
                    {
                        textAswersDAL.DeleteTextAnswer(text);
                    }
                    questionDAL.DeleteQuestion(question);
                }
                else
                {
                    List<option_choices> options = optionChoiceDAL.GetOptionsChoices(question);
                    foreach (var option in options)
                    {
                        List<answers> answers = answerDAL.GetAnswers(option.Id);
                        foreach (var answer in answers)
                        {
                            answerDAL.DeleteAnswer(answer);
                        }
                        optionChoiceDAL.DeleteOptionChoice(option);
                    }
                    questionDAL.DeleteQuestion(question);
                }
            }
            surveyDAL.DeleteSurvey(survey);
        }
        public List<surveys> GetAllSurveys()
        {
            return surveyDAL.GetAllSurveys();
        }
        public List<surveys> GetAllSurveysByUserName(string userName)
        {
            return surveyDAL.GetAllSurveysByUserName(userName);
        }
        public surveys GetSurveyBySurveyCode(string surveyCode)
        {
            return surveyDAL.GetSurveyBySurveyCode(surveyCode);
        }
        public int GetSurveyIdBySurveyCode(string surveyCode)
        {
            return surveyDAL.GetSurveyIdBySurveyCode(surveyCode);
        }
        public void UpdateSurveyName(string surveyCode, string newSurveyName)
        {
            surveys survey = surveyDAL.GetSurveyBySurveyCode(surveyCode);
            surveyDAL.UpdateSurvey(survey, newSurveyName);
        }
        //QuestionDAL
        public void AddQuestion(questions question)
        {
            questionDAL.AddQuestion(question);
        }
        public void DeleteQuestion(questions question)
        {
            if (inputTypeDAL.GetInputTypeName(question) == "text")
            {
                List<text_answers> texts = textAswersDAL.GetTextAnswers(question);
                foreach (var text in texts)
                {
                    textAswersDAL.DeleteTextAnswer(text);
                }
                questionDAL.DeleteQuestion(question);
            }
            else
            {
                List<option_choices> options = optionChoiceDAL.GetOptionsChoices(question);
                foreach (var option in options)
                {
                    List<answers> answers = answerDAL.GetAnswers(option.Id);
                    foreach (var answer in answers)
                    {
                        answerDAL.DeleteAnswer(answer);
                    }
                    optionChoiceDAL.DeleteOptionChoice(option);
                }
                questionDAL.DeleteQuestion(question);
            }
        }
        public questions GetQuestion(string questionName, string surveyCode)
        {
            int surveyId = surveyDAL.GetSurveyIdBySurveyCode(surveyCode);
            int questionId = questionDAL.GetQuestionId(surveyId, questionName);
            return questionDAL.GetQuestion(questionId);
        }
        public int GetQuestionId(int surveyId, string questionName)
        {
            return questionDAL.GetQuestionId(surveyId, questionName);
        }
        public List<questions> GetQuestionsBySurveyCode(string surveyCode)
        {
            int surveyId = surveyDAL.GetSurveyIdBySurveyCode(surveyCode);
            return questionDAL.GetQuestionsBySurveyId(surveyId);
        }
        public void UpdateQuestionName(questions question, string newQuestionName)
        {
            questionDAL.UpdateQuestion(question, newQuestionName);
        }
        //InputTypesDAL
        public string GetInputTypeName(questions question)
        {
            return inputTypeDAL.GetInputTypeName(question);
        }
        //TextAnswerDAL
        public void AddTextAnswer(text_answers answer)
        {
            textAswersDAL.AddTextAnswer(answer);
        }
        public List<text_answers> GetTextAnswers(questions question)
        {
            return textAswersDAL.GetTextAnswers(question);
        }
        public void DeleteTextAnswer(text_answers answer)
        {
            textAswersDAL.DeleteTextAnswer(answer);
        }
        //OptionChoicesDAL
        public void AddOptionChoice(option_choices option)
        {
            optionChoiceDAL.AddOptionChoice(option);
        }
        public List<option_choices> GetOptionsChoices(questions question)
        {
            return optionChoiceDAL.GetOptionsChoices(question);
        }
        public void UpdateOptionChoiceName(option_choices option, string newOptionChoiceName)
        {
            optionChoiceDAL.UpdateOptionsChoice(option, newOptionChoiceName);
        }
        //AnswersDAL
        public void AddAnswer(answers answer)
        {
            answerDAL.AddAnswer(answer);
        }
        public List<answers> GetAnswers(int optionId)
        {
            return answerDAL.GetAnswers(optionId);
        }
        public void DeleteAnswer(answers answer)
        {
            answerDAL.DeleteAnswer(answer);
        }

        /// <summary>
        /// Generate a unique survey code for a survey which consists of 10 random chars
        /// </summary>
        public string GenerateRandomSurveyCode()
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

        //Constructor
        public SurveyBusiness(IUser userDAL, ISurvey surveyDAL, IQuestion questionDAL, ITextAnswers textAnswerDAL, IOptionChoice optionChoiceDAL, IAnswers answerDAL, IInputType inputTypeDAL)
        {
            this.userDAL = userDAL;
            this.surveyDAL = surveyDAL;
            this.questionDAL = questionDAL;
            this.textAswersDAL = textAnswerDAL;
            this.optionChoiceDAL = optionChoiceDAL;
            this.answerDAL = answerDAL;
            this.inputTypeDAL = inputTypeDAL;
        }
    }
}
