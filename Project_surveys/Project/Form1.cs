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

namespace Project
{
    public partial class Form1 : Form
    {
        SurveyBusiness b = new SurveyBusiness();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //surveys surveys = b.GetSurveyById(int.Parse(textBox1.Text));
           
              //  textBox3.Text += surveys.Name;
              //  textBox3.Text += Environment.NewLine;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // users user = new users();
            // user.User_name = textBox1.Text;
            // user.User_password = textBox2.Text;
            // b.AddUser(user);
            surveys survey = new surveys();
            survey.Name = "text8";
            survey.User_name = textBox1.Text;
            survey.Survey_code = "kji";
            b.AddSurvey(survey);
        }
    }
}
