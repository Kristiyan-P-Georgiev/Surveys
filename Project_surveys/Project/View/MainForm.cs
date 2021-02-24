using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.Data;
using Project.Business;
using Project.Business.DAL;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project
{
    public partial class MainForm : Form
    {
        private bool isUserPanelOpen = false;
        private bool isFillSurveyPanelOpen = false;

        private int question_text_counter = 0;
        private int question_option_counter = 0;

        private UserDAL usd = new UserDAL();
        private SurveyDAL sd = new SurveyDAL();
        private QuestionDAL qd = new QuestionDAL();
        private TextAnswerDAL tad = new TextAnswerDAL();
        private OptionChoicesDAL opd = new OptionChoicesDAL();
        private AnswersDAL ad = new AnswersDAL();
        private InputTypesDAL ipd = new InputTypesDAL();
        private SurveyBusiness b;

        private surveys survey;

        List<questions> questionsSending = new List<questions>();

        public MainForm()
        {
            b = new SurveyBusiness(usd, sd, qd, tad, opd, ad, ipd);
            InitializeComponent();
        }
        /// <summary>
        /// Show the create survey panel and hide all the others
        /// </summary>
        private void buttonShowCreateSurveyPanel_Click(object sender, EventArgs e)
        {
            //Hide the user panel
            timerUserPanel.Start();
            panelCreateSurvey.AutoScrollMinSize = new Size(0, 300);
            //Hide all the other panels
            ShowPanel(panelCreateSurvey);
        }
        /// <summary>
        /// Create a text answer question
        /// </summary>
        private void buttonText_Click(object sender, EventArgs e)
        {
            //Check if the previous question or title has the correct inputs
            if (CheckInputs()) return;

            //All the buttons are moved 60px lower
            buttonText.SetBounds(buttonText.Location.X, buttonText.Location.Y + 60, buttonText.Width, buttonText.Height);
            buttonOptionChoice.SetBounds(buttonOptionChoice.Location.X, buttonOptionChoice.Location.Y + 60, buttonOptionChoice.Width, buttonOptionChoice.Height);
            buttonCreateSurvey.SetBounds(buttonCreateSurvey.Location.X, buttonCreateSurvey.Location.Y + 60, buttonCreateSurvey.Width, buttonCreateSurvey.Height);

            //Create the question
            CreateQuestionTitle("text");
            question_text_counter++;
        }
        /// <summary>
        /// Create a option choice question and all its options
        /// </summary>
        private void buttonOptionChoice_Click(object sender, EventArgs e)
        {
            //Check if the previous question or title has the correct inputs
            if (CheckInputs()) return;

            //All the buttons are moved 150px lower
            buttonText.SetBounds(buttonText.Location.X, buttonText.Location.Y + 150, buttonText.Width, buttonText.Height);
            buttonOptionChoice.SetBounds(buttonOptionChoice.Location.X, buttonOptionChoice.Location.Y + 150, buttonOptionChoice.Width, buttonOptionChoice.Height);
            buttonCreateSurvey.SetBounds(buttonCreateSurvey.Location.X, buttonCreateSurvey.Location.Y + 150, buttonCreateSurvey.Width, buttonCreateSurvey.Height);

            //Create the question and the option choices for it
            CreateQuestionTitle("option");
            CreateOptionChoices();
            question_option_counter++;
        }
        /// <summary>
        /// Take all the questions created by the user and add the survey to the database
        /// </summary>
        private void buttonCreateSurvey_Click(object sender, EventArgs e)
        {
            //Check if the previous question or title has the correct inputs
            if (CheckInputs()) return;
            //If there are 0 questions the survey won't be created
            if (question_text_counter + question_option_counter == 0)
            {
                MessageBox.Show("Please create atleast one question.");
                return;
            }
            //Create the survey and add it to the database
            CreateSurvey();
            b.AddSurvey(survey);
            //For each question, the 'for'cycle adds it to the database
            for (int i = 1; i < question_text_counter + question_option_counter + 1; i++)
            {
                questions question = new questions();
                TextBox title = panelCreateSurvey.Controls.Find(i + "title", false).First() as TextBox;
                //If the question is a text answer, add it to the database
                if (title.Tag.ToString() == "text")
                {
                    question.Surveys_id = b.GetSurveyIdBySurveyCode(survey.Survey_code);
                    question.Question_name = title.Text;
                    question.Input_type_id = 1;
                    b.AddQuestion(question);
                }
                //If the question is a option choice, add it to the database along with its options
                else
                {
                    question.Surveys_id = b.GetSurveyIdBySurveyCode(survey.Survey_code);
                    question.Question_name = title.Text;
                    question.Input_type_id = 2;
                    b.AddQuestion(question);
                    //Add the options to the database
                    for (int j = 1; j < 4; j++)
                    {
                        option_choices option = new option_choices();
                        TextBox optionChoice = panelCreateSurvey.Controls.Find(i + "option" + j, false).First() as TextBox;
                        option.Question_id = question.Id;
                        option.Option_choices_name = optionChoice.Text;
                        b.AddOptionChoice(option);
                    }
                }
            }
            MessageBox.Show("Survey succesfully created!");
            //Clear the panel
            ClearPanelCreateSurvey();
        }
        /// <summary>
        /// Checks if the inputs of the current question are correct
        /// </summary>
        private bool CheckInputs()
        {
            //If the survey doesn't have a title the inputs are incorrect
            if (string.IsNullOrWhiteSpace(textBoxSurveyTitle.Text))
            {
                MessageBox.Show("Please choose a title for your survey.");
                return true;
            }
            try
            {
                //If the question doesn't have a title the inputs are incorrect
                TextBox title = panelCreateSurvey.Controls.Find(question_text_counter + question_option_counter + "title", false).First() as TextBox;
                if (string.IsNullOrWhiteSpace(title.Text))
                {
                    MessageBox.Show("Please choose a title for your question.");
                    return true;
                }
                //If any of the options doesn't have a name the inputs are incorrect
                for (int i = 1; i < 4; i++)
                {
                    TextBox option = panelCreateSurvey.Controls.Find(question_text_counter + question_option_counter + "option" + i, false).First() as TextBox;
                    if (string.IsNullOrWhiteSpace(option.Text))
                    {
                        MessageBox.Show("Not all options have a name!");
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }
        /// <summary>
        /// Create an instance of a survey
        /// </summary>
        private void CreateSurvey()
        {
            survey = new surveys();
            survey.Name = textBoxSurveyTitle.Text;
            survey.Survey_code = b.GenerateRandomSurveyCode();
            survey.User_name = SignUpForm.LoggedUser.User_name;
        }
        /// <summary>
        /// Create and return a label with a given location and text
        /// </summary>
        private Label CreateLabel(Point location, string text)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.SetBounds(location.X, location.Y, 0, 0);
            label.Text = text;
            label.Font = new Font("Century", 12);
            label.ForeColor = System.Drawing.Color.FromArgb(238, 26, 74);
            return label;
        }
        /// <summary>
        /// Create and return a textbox with a given name, location, size and maxLength of the characters
        /// </summary>
        private TextBox CreateTextBox(string name, Point location, Size size, int maxLength)
        {
            TextBox txt = new TextBox();
            txt.Name = name;
            txt.SetBounds(location.X, location.Y, size.Width, size.Height);
            txt.MaxLength = maxLength;
            txt.Font = new Font("Century", 12);
            txt.ForeColor = System.Drawing.Color.FromArgb(238, 26, 74);
            return txt;
        }
        /// <summary>
        /// Create and return a button with a given location, size and text
        /// </summary>
        private Button CreateButton(Point location, Size size, string text)
        {
            Button button = new Button();
            button.SetBounds(location.X, location.Y, size.Width, size.Height);
            button.FlatStyle = FlatStyle.Flat;
            button.Text = text;
            button.Cursor = Cursors.Hand;
            button.ForeColor = Color.White;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Century", 12);
            return button;
        }
        /// <summary>
        /// Create the label and textbox for the title of the question
        /// </summary>
        private void CreateQuestionTitle(string type)
        {
            panelCreateSurvey.Controls.Add(CreateLabel(new Point(70, 70 + question_text_counter * 60 + question_option_counter * 150 - panelCreateSurvey.VerticalScroll.Value)
                , question_text_counter + 1 + question_option_counter + ". QuestionTitle"));

            TextBox questionTitle = CreateTextBox(question_text_counter + 1 + question_option_counter + "title"
                , new Point(70, 90 + question_text_counter * 60 + question_option_counter * 150 - panelCreateSurvey.VerticalScroll.Value), new Size(607, 27), 50);
            questionTitle.Tag = "text";
            panelCreateSurvey.Controls.Add(questionTitle);

            //Button for cancelling the creation of the survey
            Button buttonCancel = CreateButton(new Point(690, 5 - panelCreateSurvey.VerticalScroll.Value), new Size(32, 32), "");
            buttonCancel.BackgroundImage = Image.FromFile(@"icons\cancel_25px.png");
            buttonCancel.Click += (s, ee) =>
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to discard this survey?", "Canceling", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ClearPanelCreateSurvey();
                }
            };
            panelCreateSurvey.Controls.Add(buttonCancel);
        }
        /// <summary>
        /// Create the labels and textbox for the option choices of the question
        /// </summary>
        private void CreateOptionChoices()
        {
            for (int i = 1; i < 4; i++)
            {
                Label optionChoiceLetter = CreateLabel(new Point(120, 70 + question_text_counter * 60 + 50 + ((i - 1) * 30) + question_option_counter * 150 - panelCreateSurvey.VerticalScroll.Value), "");
                if (i == 1) optionChoiceLetter.Text = "a)";
                else if (i == 2) optionChoiceLetter.Text = "b)";
                else if (i == 3) optionChoiceLetter.Text = "c)";
                panelCreateSurvey.Controls.Add(optionChoiceLetter);

                TextBox txt = CreateTextBox(question_text_counter + 1 + question_option_counter + "option" + i, new Point(150, 70 + question_text_counter * 60 + 50 + (i - 1) * 30 + question_option_counter * 150 - panelCreateSurvey.VerticalScroll.Value), new Size(527, 42), 80);
                panelCreateSurvey.Controls.Add(txt);
            }

        }
        /// <summary>
        /// Clear the create survey panel and reset its original components to their original locations
        /// </summary>
        public void ClearPanelCreateSurvey()
        {
            panelCreateSurvey.Visible = false;
            textBoxSurveyTitle.Text = "";
            panelCreateSurvey.Controls.Clear();
            panelCreateSurvey.Controls.Add(textBoxSurveyTitle);
            panelCreateSurvey.Controls.Add(labelSurveyTitle);
            panelCreateSurvey.Controls.Add(buttonText);
            panelCreateSurvey.Controls.Add(buttonOptionChoice);
            panelCreateSurvey.Controls.Add(buttonCreateSurvey);

            labelSurveyTitle.Location = new Point(70, 8);
            textBoxSurveyTitle.Location = new Point(70, 34);
            buttonText.Location = new Point(170, 68);
            buttonOptionChoice.Location = new Point(407, 68);
            buttonCreateSurvey.Location = new Point(70, 139);

            question_text_counter = 0;
            question_option_counter = 0;

            survey = null;
        }
        /// <summary>
        /// Clear the fill survey panel and reset its original components to their original locations
        /// </summary>
        public void ClearPanelFillSurvey()
        {
            panelFillSurvey.Visible = false;
            textBoxSurveyCode.Text = "";
            panelFillSurvey.Controls.Clear();
            panelFillSurvey.Controls.Add(textBoxSurveyCode);
            panelFillSurvey.Controls.Add(labelSurveyCode);
            panelFillSurvey.Controls.Add(buttonConfirmSurveyCode);
            textBoxSurveyCode.Visible = true;
            labelSurveyCode.Visible = true;
            buttonConfirmSurveyCode.Visible = true;

            textBoxSurveyCode.Location = new Point(173, 8);
            labelSurveyCode.Location = new Point(0, 8);
            buttonConfirmSurveyCode.Location = new Point(4, 41);

            questionsSending = null;
        }
        /// <summary>
        /// Create a list of all the user's surveys and shows their survey code
        /// It also gives the option to delete them, edit them and check their answers from other users
        /// </summary>
        private void buttonMySurveys_Click(object sender, EventArgs e)
        {
            if (isUserPanelOpen) timerUserPanel.Start();
            panelMySurveys.AutoScrollMinSize = new Size(0, 300);
            ShowPanel(panelMySurveys);
            var mySurveys = b.GetAllSurveysByUserName(buttonUser.Text);
            //If there are none, only a label will be created saying that the user doesn't have any surveys created
            if (mySurveys.Count == 0)
            {
                Label label = CreateLabel(new Point(150, 50), "You don't have any surveys created!");
                label.Font = new Font("Century", 15, FontStyle.Bold);
                panelMySurveys.Controls.Add(label);
                return;
            }
            for (int i = 0; i < mySurveys.Count; i++)
            {
                Label label = CreateLabel(new Point(20, 50 + i * 50), i + 1 + ".   " + mySurveys.ElementAt(i).Name);
                if (label.Text.Length > 30)
                {
                    label.Text = label.Text.Substring(0, 22) + "...";
                }
                panelMySurveys.Controls.Add(label);

                //Opens the check answers panel to see the survey's answers
                Button buttonCheckAnswers = CreateButton(new Point(200, 50 + i * 50), new Size(150, 30), "Check Answers");
                buttonCheckAnswers.Name = "" + i;
                buttonCheckAnswers.BackColor = System.Drawing.Color.FromArgb(238, 26, 74);
                buttonCheckAnswers.Click += (s, ee) =>
                {
                    checkAnswers(mySurveys.ElementAt(int.Parse(buttonCheckAnswers.Name)));
                    panelCheckAnswers.Visible = true;
                    panelMySurveys.Visible = false;
                };
                panelMySurveys.Controls.Add(buttonCheckAnswers);

                //Deletes the survey from the database
                Button buttonDeleteSurvey = CreateButton(new Point(400, 50 + i * 50), new Size(26, 26), "");
                buttonDeleteSurvey.Name = i + "";
                buttonDeleteSurvey.BackgroundImage = Image.FromFile(@"icons\delete_26px.png");
                buttonDeleteSurvey.Click += (s, ee) =>
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this survey?", "Deleting Survey", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        b.DeleteSurvey(mySurveys.ElementAt(int.Parse(buttonDeleteSurvey.Name)).Survey_code);
                        panelMySurveys.Controls.Clear();
                        buttonMySurveys.PerformClick();
                    }

                };
                panelMySurveys.Controls.Add(buttonDeleteSurvey);

                //Opens the edit survey panel to edit the survey
                Button buttonEditSurvey = CreateButton(new Point(360, 50 + i * 50), new Size(26, 26), "");
                buttonEditSurvey.Name = i + "";
                buttonEditSurvey.BackgroundImage = Image.FromFile(@"icons\edit_26px.png");
                buttonEditSurvey.Click += (s, ee) =>
                {
                    EditSurvey(mySurveys.ElementAt(int.Parse(buttonEditSurvey.Name)));
                };
                panelMySurveys.Controls.Add(buttonEditSurvey);

                TextBox surveyCodeTextBox = CreateTextBox("surveyCodeTextBox", new Point(440, 55 + i * 50), new Size(120, 20), 11);
                surveyCodeTextBox.Text = mySurveys.ElementAt(i).Survey_code;
                surveyCodeTextBox.ReadOnly = true;
                surveyCodeTextBox.BorderStyle = 0;
                surveyCodeTextBox.BackColor = this.BackColor;
                panelMySurveys.Controls.Add(surveyCodeTextBox);
            }

            Label surveyCode = CreateLabel(new Point(440, 10), "Survey Code");
            panelMySurveys.Controls.Add(surveyCode);


        }
        /// <summary>
        /// Creates the survey with all its questions and gives you the opportunity to edit them
        /// </summary>
        private void EditSurvey(surveys survey)
        {
            panelEditSurvey.AutoScrollMinSize = new Size(0, 300);
            ShowPanel(panelEditSurvey);
            List<questions> oldQuestions = b.GetQuestionsBySurveyCode(survey.Survey_code);

            //Cancel the edit and go back to the my surveys panel
            Button buttonGoBack = CreateButton(new Point(680, 20), new Size(32, 32), "");
            buttonGoBack.BackgroundImage = Image.FromFile(@"icons\return_32px.png");
            buttonGoBack.Click += (s, ee) =>
            {
                ShowPanel(panelMySurveys);
                buttonMySurveys.PerformClick();
            };
            panelEditSurvey.Controls.Add(buttonGoBack);

            Label title = CreateLabel(new Point(5, 30), "Title");
            panelEditSurvey.Controls.Add(title);

            TextBox titleTextBox = CreateTextBox("titleTextBox", new Point(60, 30), new Size(600, 30), 50);
            titleTextBox.Multiline = true;
            titleTextBox.Text = survey.Name;
            panelEditSurvey.Controls.Add(titleTextBox);

            int YCounter = 0;
            int i;
            for (i = 0; i < oldQuestions.Count; i++)
            {
                Label questionNumber = CreateLabel(new Point(5, 70 + YCounter * 120 + i * 50), (i + 1) + ".");
                panelEditSurvey.Controls.Add(questionNumber);

                TextBox questionText = CreateTextBox(i + 1 + "textBox", new Point(40, 70 + YCounter * 120 + i * 50), new Size(600, 30), 80);
                questionText.Multiline = true;
                questionText.Text = oldQuestions.ElementAt(i).Question_name;
                panelEditSurvey.Controls.Add(questionText);

                if (b.GetInputTypeName(oldQuestions.ElementAt(i)) == "option")
                {
                    for (int j = 1; j < 4; j++)
                    {
                        TextBox option = CreateTextBox(j + "option" + i, new Point(60, 70 + YCounter * 120 + j * 40 + i * 50), new Size(600, 30), 80);
                        option.Multiline = true;
                        var choices = b.GetOptionsChoices(oldQuestions.ElementAt(i));
                        var text = choices.ElementAt(j - 1);
                        option.Text = text.Option_choices_name;
                        panelEditSurvey.Controls.Add(option);
                    }
                    YCounter++;
                }
            }
            //Confirms the edit and update the questions in the database
            //Also it deletes all the current answers to the questions in the survey
            Button buttonConfirmEdit = CreateButton(new Point(110, 70 + YCounter * 120 + i * 50), new Size(200, 30), "Confirm Edit");
            buttonConfirmEdit.BackColor = System.Drawing.Color.FromArgb(238, 26, 74);
            buttonConfirmEdit.Click += (s, ee) =>
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to edit this survey? Note that it will delete all it's current answers.", "Editting survey", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    for (int j = 0; j < oldQuestions.Count; j++)
                    {
                        if (b.GetInputTypeName(oldQuestions.ElementAt(j)) == "option")
                        {
                            for (int z = 1; z < 4; z++)
                            {
                                TextBox newOption = panelEditSurvey.Controls.Find(z + "option" + j, false).First() as TextBox;
                                b.UpdateOptionChoiceName(oldQuestions.ElementAt(j).option_choices.ElementAt(z - 1), newOption.Text);
                            }
                        }
                        TextBox newName = panelEditSurvey.Controls.Find(j + 1 + "textBox", false).First() as TextBox;
                        b.UpdateQuestionName(oldQuestions.ElementAt(j), newName.Text);
                        if (b.GetInputTypeName(oldQuestions.ElementAt(j)) == "text")
                        {
                            foreach (var answer in b.GetTextAnswers(oldQuestions.ElementAt(j)))
                            {
                                b.DeleteTextAnswer(answer);
                            }
                        }
                        else
                        {
                            foreach (var option in b.GetOptionsChoices(oldQuestions.ElementAt(j)))
                            {
                                foreach (var answer in b.GetAnswers(option.Id))
                                {
                                    b.DeleteAnswer(answer);
                                }
                            }
                        }
                    }
                    TextBox newTitle = panelEditSurvey.Controls.Find("titleTextBox", false).First() as TextBox;
                    b.UpdateSurveyName(survey.Survey_code, newTitle.Text);
                    MessageBox.Show("Survey edited succesfully!", "Success!");
                    buttonHome.PerformClick();
                }
            };
            panelEditSurvey.Controls.Add(buttonConfirmEdit);
        }
        /// <summary>
        /// Opens the check answers panel and shows all the answers for each question
        /// </summary>
        private void checkAnswers(surveys survey)
        {
            panelCheckAnswers.AutoScrollMinSize = new Size(0, 300);
            ShowPanel(panelCheckAnswers);
            List<questions> questions = b.GetQuestionsBySurveyCode(survey.Survey_code);

            //Button to go back to the my surveys panel
            Button buttonGoBack = CreateButton(new Point(600, 40), new Size(32, 32), "");
            buttonGoBack.BackgroundImage = Image.FromFile(@"icons\return_32px.png");
            buttonGoBack.Click += (s, ee) =>
            {
                ShowPanel(panelMySurveys);
                buttonMySurveys.PerformClick();
            };
            panelCheckAnswers.Controls.Add(buttonGoBack);

            //If the survey hasn't got any answers yet, only a label will be shown telling the user that they are no answers to that survey
            if (!HasAnswers(survey))
            {
                Label label = CreateLabel(new Point(100, 50), "You don't have any answers to this survey!");
                label.Font = new Font("Century", 15, FontStyle.Bold);
                panelCheckAnswers.Controls.Add(label);
                return;
            }

            int Ycounter = 0;
            for (int i = 0; i < questions.Count; i++)
            {
                Label questionTitle = CreateLabel(new Point(20, 40 + Ycounter * 120 + i * 150), (i + 1) + "." + questions.ElementAt(i).Question_name);
                questionTitle.Font = new Font("Century", 12, FontStyle.Bold);

                //If the question is an option choice type, a bar chart will be shown with all the options and their answers
                if (b.GetInputTypeName(questions.ElementAt(i)) == "option")
                {
                    Chart answerChart = new Chart();
                    answerChart.SetBounds(20, 60 + Ycounter * 120 + i * 150, 500, 200);
                    answerChart.Series.Add(questions.ElementAt(i).Question_name);
                    answerChart.Series[questions.ElementAt(i).Question_name].Color = System.Drawing.Color.FromArgb(238, 26, 74);
                    List<option_choices> options = b.GetOptionsChoices(questions.ElementAt(i));
                    answerChart.ChartAreas.Add(new ChartArea());
                    answerChart.ChartAreas.First().AxisX.LabelStyle.Font = new Font("Century", 10);
                    answerChart.ChartAreas.First().AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(238, 26, 74);
                    answerChart.ChartAreas.First().AxisY.LabelStyle.Font = new Font("Century", 10);
                    answerChart.ChartAreas.First().AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(238, 26, 74);
                    foreach (var option in options)
                    {
                        answerChart.Series[questions.ElementAt(i).Question_name].Points.AddXY(option.Option_choices_name, b.GetAnswers(option.Id).Count);
                    }
                    panelCheckAnswers.Controls.Add(answerChart);
                    Ycounter++;
                }
                //If the question is a text answer type, a list of all the answers will be shown
                else
                {
                    List<text_answers> texts = b.GetTextAnswers(questions.ElementAt(i));
                    ListBox listBox = new ListBox();
                    listBox.SetBounds(30, 60 + Ycounter * 120 + i * 150, 550, 130);
                    listBox.Font = new Font("Century", 12);
                    listBox.ForeColor = System.Drawing.Color.FromArgb(238, 26, 74);
                    listBox.BorderStyle = BorderStyle.None;
                    listBox.HorizontalScrollbar = true;
                    for (int j = 0; j < texts.Count; j++)
                    {
                        listBox.Items.Add(texts.ElementAt(j).Answer);
                    }
                    panelCheckAnswers.Controls.Add(listBox);
                }
                panelCheckAnswers.Controls.Add(questionTitle);
            }
        }
        /// <summary>
        /// Check if a survey has any answers to it
        /// </summary>
        private bool HasAnswers(surveys survey)
        {
            var questions = b.GetQuestionsBySurveyCode(survey.Survey_code);
            bool hasTextAnswers = true;
            bool hasOptionAnswers = true;
            foreach (var question in questions)
            {
                if (b.GetInputTypeName(question) == "text")
                {
                    if (b.GetTextAnswers(question).Count == 0)
                    {
                        hasTextAnswers = false;
                    }
                }
                else
                {
                    List<option_choices> options = b.GetOptionsChoices(question);
                    if (options.ElementAt(0).answers.Count == 0 && options.ElementAt(1).answers.Count == 0 && options.ElementAt(2).answers.Count == 0)
                    {
                        hasOptionAnswers = false;
                    }
                }
            }
            if (hasTextAnswers && hasOptionAnswers) return true;
            else return false;
        }
        /// <summary>
        /// Shows the take survey panel and all its buttons
        /// </summary>
        private void buttonTakeSurvey_Click(object sender, EventArgs e)
        {
            timerFillSurveyPanel.Start();
            if (isUserPanelOpen) timerUserPanel.Start();
        }
        /// <summary>
        /// Generate a survey with a given survey code
        /// </summary>
        private void buttonConfirmSurveyCode_Click(object sender, EventArgs e)
        {
            //If a survey with the given survey code doesn't exist, a warning will be shown
            if (b.GetSurveyBySurveyCode(textBoxSurveyCode.Text) == null)
            {
                MessageBox.Show("A survey with that code doesn't exist.");
            }
            //Else generate all the questions from the given survey
            else
            {
                surveys currSurvey = b.GetSurveyBySurveyCode(textBoxSurveyCode.Text);
                questionsSending = b.GetQuestionsBySurveyCode(textBoxSurveyCode.Text);
                panelFillSurvey.Controls.Clear();
                GenerateQuestions(questionsSending, currSurvey);
            }
        }
        /// <summary>
        /// Generate all the questions from a given survey
        /// </summary>
        private void GenerateQuestions(List<questions> questions, surveys currSurvey)
        {
            TextBox title = CreateTextBox("", new Point(20, 10), new Size(550, 20), 200);
            title.Text = currSurvey.Name;
            title.ReadOnly = true;
            title.BorderStyle = 0;
            title.BackColor = this.BackColor;
            panelFillSurvey.Controls.Add(title);

            for (int i = 0; i < questions.Count; i++)
            {
                Label label1 = CreateLabel(new Point(20, 40 + i * 80), (i + 1) + "." + questions.ElementAt(i).Question_name);
                panelFillSurvey.Controls.Add(label1);

                if (b.GetInputTypeName(questions.ElementAt(i)) == "text")
                {
                    TextBox txt1 = CreateTextBox(i + 1 + "textBox", new Point(20, 60 + i * 80), new Size(600, 50), 500);
                    txt1.Multiline = true;
                    panelFillSurvey.Controls.Add(txt1);
                }
                else if (b.GetInputTypeName(questions.ElementAt(i)) == "option")
                {
                    List<option_choices> questionChoices = b.GetOptionsChoices(questions.ElementAt(i));
                    CheckBox box;
                    for (int j = 1; j < 4; j++)
                    {
                        box = new CheckBox();
                        box.Text = questionChoices.ElementAt(j - 1).Option_choices_name;
                        box.AutoSize = true;
                        box.Name = i + 1 + "option" + j;
                        box.Font = new Font("Century", 12);
                        box.ForeColor = System.Drawing.Color.FromArgb(238, 26, 74);
                        box.Location = new Point(30, 40 + i * 80 + j * 20);
                        panelFillSurvey.Controls.Add(box);
                    }
                }
            }
            //Button to send the answers to the database
            Button buttonSendSurvey = CreateButton(new Point(20, 50 + questions.Count * 80), new Size(200, 50), "Send Survey");
            buttonSendSurvey.BackColor = System.Drawing.Color.FromArgb(238, 26, 74);
            buttonSendSurvey.Click += (sender, e) =>
            {
                sendSurvey();
            };
            panelFillSurvey.Controls.Add(buttonSendSurvey);
            //Button to cancel filling the survey
            Button buttonCancel = CreateButton(new Point(600, 10), new Size(32, 32), "");
            buttonCancel.BackgroundImage = Image.FromFile(@"icons\cancel_25px.png");
            buttonCancel.Click += (s, ee) =>
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit filling this survey?", "Canceling", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ClearPanelFillSurvey();
                }
            };
            panelFillSurvey.Controls.Add(buttonCancel);
        }
        /// <summary>
        /// Take all the answers from the textboxs in the fill survey panel and add them to the database
        /// </summary>
        private void sendSurvey()
        {
            int questionCount = 1;
            List<text_answers> tAnswersSending = new List<text_answers>();
            List<answers> optAnswers = new List<answers>();
            foreach (var question in questionsSending)
            {
                if (b.GetInputTypeName(question) == "text")
                {
                    text_answers tAnswer = new text_answers();
                    tAnswer.User_name = SignUpForm.LoggedUser.User_name;
                    tAnswer.Question_id = question.Id;
                    TextBox answer = panelFillSurvey.Controls.Find(questionCount + "textBox", false).First() as TextBox;
                    tAnswer.Answer = answer.Text;
                    tAnswersSending.Add(tAnswer);
                }
                else if (b.GetInputTypeName(question) == "option")
                {
                    for (int i = 0; i < 3; i++)
                    {
                        answers optAnswer = new answers();
                        optAnswer.User_name = SignUpForm.LoggedUser.User_name;
                        CheckBox option = panelFillSurvey.Controls.Find(questionCount + "option" + (i + 1), false).First() as CheckBox;
                        if (option.Checked == true)
                        {
                            optAnswer.Question_option_id = b.GetOptionsChoices(question).ElementAt(i).Id;
                        }
                        optAnswers.Add(optAnswer);
                    }
                }
                questionCount++;
            }
            //If any of the textbox haven't got an answer a warning will be shown
            foreach (var text in tAnswersSending)
            {
                if (string.IsNullOrWhiteSpace(text.Answer))
                {
                    MessageBox.Show("Not all questions have an answer!", "Error");
                    return;
                }
            }
            //If any of the option choices haven't got an answer a warning will be shown
            foreach (var question in questionsSending)
            {
                if (b.GetInputTypeName(question) == "option")
                {
                    if (!HasAnswer(question, optAnswers))
                    {
                        MessageBox.Show("Not all questions have an answer!", "Error");
                        return;
                    }
                }
            }
            //Add all the answers to the database
            foreach (var text in tAnswersSending)
            {
                b.AddTextAnswer(text);
            }
            foreach (var option in optAnswers)
            {
                if (option.Question_option_id != 0) b.AddAnswer(option);
            }
            MessageBox.Show("Survey succesfully sent!");
            ClearPanelFillSurvey();

        }
        /// <summary>
        /// Checks if an option choice question has got any answers
        /// </summary>
        private bool HasAnswer(questions question, List<answers> answers)
        {
            List<option_choices> options = b.GetOptionsChoices(question);
            //If any of the answers has the same question option id as the questions options, that means that there is an answer
            foreach (var answer in answers)
            {
                if (answer.Question_option_id == options.ElementAt(0).Id || answer.Question_option_id == options.ElementAt(1).Id
                    || answer.Question_option_id == options.ElementAt(2).Id)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// A method that is executed when the form loads
        /// </summary>
        private void Form2_Load(object sender, EventArgs e)
        {
            //The buttonUser text is now the signed user's username
            //buttonUser.Text = SignUpForm.LoggedUser.User_name;
        }
        /// <summary>
        /// Shows the button user panel and all its buttons
        /// </summary>
        private void buttonUser_Click(object sender, EventArgs e)
        {
            timerUserPanel.Start();
            if (isFillSurveyPanelOpen) timerFillSurveyPanel.Start();
        }
        /// <summary>
        /// The timer is used to show and hide the user panel
        /// </summary>
        private void timerUserPanel_Tick(object sender, EventArgs e)
        {
            if (isUserPanelOpen)
            {
                panelUser.Height -= 20;
                if (panelUser.Height == 0)
                {
                    timerUserPanel.Stop();
                    isUserPanelOpen = false;
                }
            }
            else
            {
                panelUser.Height += 20;
                if (panelUser.Height >= 120)
                {
                    timerUserPanel.Stop();
                    isUserPanelOpen = true;
                }

            }
        }
        /// <summary>
        /// Clear all the panels and shows the home screen
        /// </summary>
        private void buttonHome_Click(object sender, EventArgs e)
        {
            ShowPanel(panelHeader);
            panelEditSurvey.Controls.Clear();
        }
        /// <summary>
        /// If the user name is bigger or smaller than the button, its size will be changed accordingly
        /// </summary>
        private void buttonUser_SizeChanged(object sender, EventArgs e)
        {
            Graphics g = buttonUser.CreateGraphics();
            var width = g.MeasureString(buttonUser.Text, buttonUser.Font).Width;
            var totalWidth = width * buttonUser.Text.Length;
            if (totalWidth < width * 5)
            {
                buttonUser.Font = new Font(buttonUser.Font.Name, 13f);
            }
            else if (totalWidth < width * 10)
            {
                buttonUser.Font = new Font(buttonUser.Font.Name, 11f);
            }
            else if (totalWidth < width * 20)
            {
                buttonUser.Font = new Font(buttonUser.Font.Name, 10f);
            }
            else if (totalWidth < width * 30)
            {
                buttonUser.Font = new Font(buttonUser.Font.Name, 9f);
            }

        }
        /// <summary>
        /// Closes the main form and goes back to the sign in form
        /// </summary>
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to sign out?", "Signing out", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SignUpForm form = new SignUpForm();
                form.Show();
                form.SetBounds(this.Location.X, this.Location.Y, form.Width, form.Height);
                form.FormClosing += (obj, args) => { this.Close(); };
                this.Hide();
            }
        }
        /// <summary>
        /// The timer is used to show and hide the fill survey panel
        /// </summary>
        private void timerFillSurveyPanel_Tick(object sender, EventArgs e)
        {
            if (isFillSurveyPanelOpen)
            {
                panelFillSurveyDropdown.Height -= 20;
                if (panelFillSurveyDropdown.Height == 0)
                {
                    timerFillSurveyPanel.Stop();
                    isFillSurveyPanelOpen = false;
                }
            }
            else
            {
                panelFillSurveyDropdown.Height += 20;
                if (panelFillSurveyDropdown.Height >= 80)
                {
                    timerFillSurveyPanel.Stop();
                    isFillSurveyPanelOpen = true;
                }

            }
        }
        /// <summary>
        /// Shows the fill survey panel and hides all the others
        /// </summary>
        private void buttonFillSurveyByCode_Click(object sender, EventArgs e)
        {
            panelFillSurvey.AutoScrollMinSize = new Size(0, 300);
            ShowPanel(panelFillSurvey);
            timerFillSurveyPanel.Start();
        }
        /// <summary>
        /// Hides all panels except the given one and some panels that should be hidden
        /// For some panels the method not only hides them but also clears their components
        /// </summary>
        private void ShowPanel(Panel panel)
        {
            foreach (var pnl in this.Controls.OfType<Panel>())
            {
                if (pnl.Name != "panelHeader" && pnl.Name != "panelEditSurvey"
                    && pnl.Name != "panelCheckAnswers" && pnl.Name != "panelMySurveys"
                    && pnl.Name != "panelEverySurvey" && pnl.Name != "panelUser"
                    && pnl.Name != "panelFillSurveyDropdown")
                {
                    pnl.Visible = false;
                }
                else if (pnl.Name != "panelHeader" && pnl.Name != "panelUser" && pnl.Name != "panelFillSurveyDropdown")
                {
                    pnl.Controls.Clear();
                    pnl.Visible = false;
                }
            }
            panel.Visible = true;
        }
        /// <summary>
        /// Create a list of all users' surveys and shows their survey code, title and username
        /// It also gives the option fill them
        /// </summary>
        private void buttonCheckEverySurvey_Click(object sender, EventArgs e)
        {
            panelEverySurvey.AutoScrollMinSize = new Size(0, 300);
            ShowPanel(panelEverySurvey);
            timerFillSurveyPanel.Start();

            var allSurveys = b.GetAllSurveys();
            //If there are no surveys created yet, only a label will be shown saying that there are no surveys created
            if (allSurveys.Count == 0)
            {
                Label label = CreateLabel(new Point(150, 50), "There is currently no surveys created!");
                panelEverySurvey.Controls.Add(label);
                return;
            }
            for (int i = 0; i < allSurveys.Count; i++)
            {
                Label label = CreateLabel(new Point(20, 50 + i * 50), i + 1 + ".   " + allSurveys.ElementAt(i).Name);
                if (label.Text.Length > 19)
                {
                    label.Text = label.Text.Substring(0, 18) + "...";
                }
                panelEverySurvey.Controls.Add(label);

                Label userName = CreateLabel(new Point(200, 50 + i * 50), allSurveys.ElementAt(i).users.User_name);
                if (userName.Text.Length > 16)
                {
                    userName.Text = userName.Text.Substring(0, 15) + "...";
                }
                panelEverySurvey.Controls.Add(userName);

                //Button that will open the fill survey panel and generate the questions for the selected survey
                Button buttonFillSurvey = CreateButton(new Point(350, 50 + i * 50), new Size(150, 30), "Fill Survey");
                buttonFillSurvey.Name = allSurveys.ElementAt(i).Survey_code;
                buttonFillSurvey.BackColor = System.Drawing.Color.FromArgb(238, 26, 74);
                buttonFillSurvey.Click += (s, ee) =>
                {
                    surveys currSurvey = b.GetSurveyBySurveyCode(buttonFillSurvey.Name);
                    questionsSending = b.GetQuestionsBySurveyCode(buttonFillSurvey.Name);

                    panelFillSurvey.Controls.Clear();
                    panelFillSurvey.AutoScrollMinSize = new Size(0, 300);
                    ShowPanel(panelFillSurvey);
                    GenerateQuestions(questionsSending, currSurvey);
                };
                panelEverySurvey.Controls.Add(buttonFillSurvey);

                TextBox surveyCodeTextBox = CreateTextBox("", new Point(540, 55 + i * 50), new Size(120,20), 300);
                surveyCodeTextBox.Text = allSurveys.ElementAt(i).Survey_code;
                surveyCodeTextBox.ReadOnly = true;
                surveyCodeTextBox.BorderStyle = 0;
                surveyCodeTextBox.BackColor = this.BackColor;
                panelEverySurvey.Controls.Add(surveyCodeTextBox);
            }

            Label surveyCode = CreateLabel(new Point(540, 10), "Survey Code");
            surveyCode.Font = new Font("Century", 12, FontStyle.Bold);
            panelEverySurvey.Controls.Add(surveyCode);

            Label user = CreateLabel(new Point(200,10), "User");
            user.Font = new Font("Century", 12, FontStyle.Bold);
            panelEverySurvey.Controls.Add(user);
        }
    }
}
