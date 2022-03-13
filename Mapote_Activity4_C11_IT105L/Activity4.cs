using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Mapote_Activity4_C11_IT105L
{
    /* 
    * FullName: Jayvee N. Mapote
    * Section: C11
    * Course: IT105L
    * Laboratory: Activity 4
    */
    public partial class Activity4 : Form
    {
        const int Weightedgrades = 5;
        double[] WeightedGrades = new double[Weightedgrades];

        string[] name = new string[3];
        string[] date = new string[3];
        int[] Units = new int[2];

        public Activity4()
        {
            InitializeComponent();
        }

        private void NameBox1_TextChanged(object sender, EventArgs e)
        {
            string name = (String)NameBox1.Text;
            if (name == "exit" || name == "Exit" || name == "EXIT")
            {
                Application.Exit();
            }
        }

        private void AssignmentBox_ValueChanged(object sender, EventArgs e)
        {
            WeightedGrades[0] = Convert.ToDouble(AssignmentBox.Value) * 0.1;
        }

        private void QuizBox_ValueChanged(object sender, EventArgs e)
        {
            WeightedGrades[1] = Convert.ToDouble(QuizBox.Value) * 0.3;
        }

        private void PrelimBox_ValueChanged(object sender, EventArgs e)
        {
            WeightedGrades[2] = Convert.ToDouble(PrelimBox.Value) * 0.2;
        }

        private void MidtermBox_ValueChanged(object sender, EventArgs e)
        {
            WeightedGrades[3] = Convert.ToDouble(MidtermBox.Value) * 0.2;
        }

        private void FinalExamBox_ValueChanged(object sender, EventArgs e)
        {
            WeightedGrades[4] = Convert.ToDouble(FinalExamBox.Value) * 0.2;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            NameBox1.Clear();
            NameBox1.Focus();
            AssignmentBox.ResetText();
            QuizBox.ResetText();
            PrelimBox.ResetText();
            MidtermBox.ResetText();
            FinalExamBox.ResetText();
        }

        private void ClearBtn2_Click(object sender, EventArgs e)
        {
            FirstNameBox.Clear();
            MiddleNameBox.Clear();
            LastNameBox.Clear();
            CourseProgramBox.Clear();
            FirstNameBox.Focus();
            BirthmonthBox.ResetText();
            BirthdayBox.ResetText();
            BirthyearBox.ResetText();
            UnitTakenBox.ResetText();
        }

        private void SumbitBtn_Click(object sender, EventArgs e)
        {
            GradeClass user_info = new GradeClass(WeightedGrades);
            ResultName.Text = ($"{NameBox1.Text.ToUpper()}");
            ResultAssignmentScore.Text = ($"{user_info.InputWeightedGrades[0]}%");
            ResultQuiz.Text = ($"{user_info.InputWeightedGrades[1]}%");
            PCAresult.Text = ($"{user_info.InputWeightedGrades[2]}%");
            MCAresult.Text = ($"{user_info.InputWeightedGrades[3]}%");
            FCAresult.Text = ($"{user_info.InputWeightedGrades[4]}%");
            FinalGradeResult.Text = ($"{user_info.TotalGrades[0]}%");
            EquivalentGradeResult.Text = ($"{user_info.TotalGrades[1]}");

            if (user_info.TotalGrades[1] <= 3.00)
            {
                if (MessageBox.Show("Status: Student Passed", "Results", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    tabControl2.SelectedIndex = 1;
                }
                else
                {
                    tabControl2.SelectedIndex = 0;
                }
            }
            else if (user_info.TotalGrades[1] >= 3.00)
            {
                if (MessageBox.Show("Status: Student Failed", "Results", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    tabControl2.SelectedIndex = 1;
                }
                else
                {
                    tabControl2.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("Wrong input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl2.SelectedIndex = 0;
            }
            try 
            {
                string filepath = @"C:\Users\admin\Desktop\IT105L\Activity 4\Mapote_Activity4_C11_IT105L"+"\\Problem1Txt\\"+ResultName.Text+".txt";
                StreamWriter writer = new StreamWriter(filepath);
                using (writer)
                {
                    writer.WriteLine("Student Information \n");
                    writer.WriteLine("Student Name: " + ResultName.Text);
                    writer.WriteLine("Assignment Score: " + ResultAssignmentScore.Text);
                    writer.WriteLine("Quiz Score: " + ResultQuiz.Text);
                    writer.WriteLine("PCA: " + PCAresult.Text);
                    writer.WriteLine("MCA: " + MCAresult.Text);
                    writer.WriteLine("FCA: " + FCAresult.Text);
                    writer.WriteLine("Final Grade: " + FinalGradeResult.Text);
                    writer.WriteLine("Equivalent Grade: " + EquivalentGradeResult.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error has occured!", "Directory not found!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SubmitBtn2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Results: Do you want to see the result?", "Submitted", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                tabControl3.SelectedIndex = 1;
            }
            else
            {
                tabControl3.SelectedIndex = 0;
            }

            name[0] = FirstNameBox.Text;
            name[1] = MiddleNameBox.Text;
            name[2] = LastNameBox.Text;

            date[0] = Convert.ToString(BirthmonthBox.Value);
            date[1] = Convert.ToString(BirthdayBox.Value);
            date[2] = Convert.ToString(BirthyearBox.Value);

            Units[0] = Convert.ToInt32(UnitTakenBox.Text);
            Units[1] = 250 - Units[0];

            UnitClass student = new UnitClass(name, date, Units);

            FullnameResult1.Text = student.Results[0].ToUpper();
            FullnameResult2.Text = student.Results[1].ToUpper();
            BirthdateResult.Text = student.Results[2];
            AgeResult.Text = student.Results[3];
            CurrentyearLevelResult.Text = student.Results[4];

            try
            {
                string filepath = @"C:\Users\admin\Desktop\IT105L\Activity 4\Mapote_Activity4_C11_IT105L" + "\\Problem2Txt\\" + FullnameResult1.Text + ".txt";
                StreamWriter writer = new StreamWriter(filepath);
                using (writer)
                {
                    writer.WriteLine("Student Information \n");
                    writer.WriteLine("Student Name: " + FullnameResult1.Text);
                    writer.WriteLine("BirthDate: " + BirthdateResult.Text);
                    writer.WriteLine("Age: " + AgeResult.Text);
                    writer.WriteLine("YearLevel: " + CurrentyearLevelResult.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error has occured!", "Directory not found!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
