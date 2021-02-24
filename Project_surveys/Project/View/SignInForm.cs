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

namespace Project
{
    public partial class SignUpForm : Form
    {
        public static users LoggedUser;

        private UserDAL usd = new UserDAL();
        private SurveyDAL sd = new SurveyDAL();
        private QuestionDAL qd = new QuestionDAL();
        private TextAnswerDAL tad = new TextAnswerDAL();
        private OptionChoicesDAL opd = new OptionChoicesDAL();
        private AnswersDAL ad = new AnswersDAL();
        private InputTypesDAL ipd = new InputTypesDAL();

        SurveyBusiness b;

        bool isPanelInfoLeft = false;

        public SignUpForm()
        {
            InitializeComponent();
            LoggedUser = null;
            b = new SurveyBusiness(usd, sd, qd, tad, opd, ad, ipd);
        }

        /// <summary>
        /// Signs in the user in the MainForm
        /// </summary>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            try
            {
                //If the user in the database has the same password as the inputted one, the user is logged in the program
                if (b.GetUserByName(username).User_password == password)
                {
                    MessageBox.Show("Successful login.", "Welcome");
                    LoggedUser = b.GetUserByName(username);
                }
                //Else the user receive a message saying that the username or password is incorrect and the method stops
                else
                {
                    MessageBox.Show("Username or password is not correct.");
                    return;
                }

                //The user is logged in and the new form appears
                MainForm form = new MainForm();
                form.Show();
                form.SetBounds(this.Location.X, this.Location.Y, form.Width, form.Height);
                form.FormClosing += (obj, args) => { this.Close(); };
                this.Hide();
            }
            catch
            {
                //If the username inputted by the client is not in the database the catch method will show a message saying that the username or password is incorrect 
                MessageBox.Show("Username or password is not correct.");
            }

        }
        /// <summary>
        /// Goes to the register panel
        /// </summary>
        private void buttonGoToRegisterPanel_Click(object sender, EventArgs e)
        {
            //Slide to the register panel
            timerSlider.Start();
        }
        /// <summary>
        /// Registers the user in the DataBase
        /// </summary>
        private void buttonConfirmReg_Click(object sender, EventArgs e)
        {
            users user = new users();
            //If the username inputted by the user is null or contains white space the user receives a warning message
            if (string.IsNullOrWhiteSpace(textBoxUsernameReg.Text))
            {
                MessageBox.Show("Please enter an username.", "Warning");
                return;
            }
            //If the password inputted by the user is null or contains white space the user receives a warning message
            else if (string.IsNullOrWhiteSpace(textBoxPasswordConfirm.Text))
            {
                MessageBox.Show("Please enter a password.", "Warning");
                return;
            }
            //If we user1 isn't null means that the user already exist in the database
            users user1 = b.GetUserByName(textBoxUsernameReg.Text);
            if (user1 != null)
            {
                MessageBox.Show("Username already exists.", "Warning");
                return;
            }
            //If the two textbox with passwords are the same the user is registered
            //Else the user receive a warning message
            user.User_name = textBoxUsernameReg.Text;
            if (textBoxPasswordConfirm.Text == textBoxPasswordReg.Text)
            {
                user.User_password = textBoxPasswordConfirm.Text;
            }
            else
            {
                MessageBox.Show("Passwords doesn't match.", "Warning");
                return;
            }

            //The user is added to the database
            b.AddUser(user);
            MessageBox.Show("Successfull register!");
            timerSlider.Start();
            //Clear the register panel
            textBoxUsernameReg.Text = "";
            textBoxPasswordConfirm.Text = "";
            textBoxPasswordReg.Text = "";
        }
        /// <summary>
        /// The timer is used to slide the InfoPanel left and right
        /// </summary>
        private void timerSlider_Tick(object sender, EventArgs e)
        {
            //Panel Info is slided left and right, depending on the bool 'isPanelInfoLeft'
            if (!isPanelInfoLeft)
            {
                panelInfo.SetBounds(panelInfo.Location.X - 20, panelInfo.Location.Y, 400, 438);
                if (panelInfo.Location.X == 0)
                {
                    timerSlider.Stop();
                    isPanelInfoLeft = !isPanelInfoLeft;
                }
            }
            else
            {
                panelInfo.SetBounds(panelInfo.Location.X + 20, panelInfo.Location.Y, 400, 438);
                if (panelInfo.Location.X >= 400)
                {
                    timerSlider.Stop();
                    isPanelInfoLeft = !isPanelInfoLeft;
                }

            }
        }
        /// <summary>
        /// Goes back to the login panel
        /// </summary>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            //Slide back to the login panel
            timerSlider.Start();
        }
    }
}
