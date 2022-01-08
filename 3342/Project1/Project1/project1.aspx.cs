using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class project1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblName.Text = "Name: " + Request["txtName"] + "\n";
            
            lblID.Text = "Student ID: " + Request["txtID"] +  "\n";
            
            lblCourse.Text = "Course: " + Request["course"] + "\n";

            String Q1 = Request["Q1"];
            String Q2 = Request["Q2"];
            String Q3 = Request["Q3"];
            String Q4 = Request["Q4"];
            String Q5 = Request["Q5"];
            String Q6 = Request["Q6"];
            String Q7 = Request["Q7"];
            String Q8 = Request["Q8"];
            String Q9 = Request["Q9"];
            String Q10 = Request["Q10"];
            String Q11 = Request["Q11"];
            String Q12 = Request["Q12"];
            String QS1 = Request["QS1"];
            String QS2 = Request["QS2"];
            String QS3 = Request["QS3"];
            String QS4 = Request["QS4"];
            String QS5 = Request["QS5"];
            String QS6 = Request["QS6"];
            String QS7 = Request["QS7"];
            String QS8 = Request["QS8"];

            var SA = "Strongly agree";
            var A = "Agree";
            var N = "Neutral";
            var D = "Disagree";
            var S = "Strongly Disagree";

            List<string> Courses = new List<string>();

            Courses.Add(Q1);
            Courses.Add(Q2);
            Courses.Add(Q3);
            Courses.Add(Q4);
            Courses.Add(Q5);
            Courses.Add(Q6);
            Courses.Add(Q7);
            Courses.Add(Q8);
            Courses.Add(Q9);
            Courses.Add(Q10);
            Courses.Add(Q11);
            Courses.Add(Q12);








            double result = 0.0;
            double result2 = 0.0;


            if (Q1 == SA)
            {
                lblQ1.Text = "Question 1: " + "\n" + SA + "\t" + 5.ToString() ;
                result += 5.0;
            }
            else if (Q1 == A)
            {
                lblQ1.Text = "Question 1: " + "\n" + A + " " + 4.ToString();
                result += 4.0;
            }
            else if (Q1 == N)
            {
                lblQ1.Text = "Question 1: " + "\n" + N + " " + 3.ToString();
                result += 3.0;
            }
            else if (Q1 == D)
            {
                lblQ1.Text = "Question 1: " + "\n" + D + " " + 2.ToString();
                result += 2.0;
            }
            else if (Q1 == S)
            {
                lblQ1.Text = "Question 1: " + "\n" + S + " " + 1.ToString();
                result += 1.0;
            }



            if (Q2 == SA)
            {
                lblQ2.Text = "Question 2: " + "\n" + SA + " " + 5.ToString();
                result += 5.0;
            }
            else if (Q2 == A)
            {
                lblQ2.Text = "Question 2: " + "\n" + A + " " + 4.ToString();
                result += 4.0;
            }
            else if (Q2 == N)
            {
                lblQ2.Text = "Question 2: " + "\n" + N + " " + 3.ToString();
                result += 3.0;
            }
            else if (Q2 == D)
            {
                lblQ2.Text = "Question 2: " + "\n" + D + " " + 2.ToString();
                result += 2.0;
            }
            else if (Q2 == S)
            {
                lblQ2.Text = "Question 2: " + "\n" + S + " " + 1.ToString();
                result += 1.0;
            }


            if (Q3 == SA)
            {
                lblQ3.Text = "Question 3: " + "\n" + SA + " " + 5.ToString();
                result += 5.0;
            }
            else if (Q3 == A)
            {
                lblQ3.Text = "Question 3: " + "\n" + A + " " + 4.ToString();
                result += 4.0;
            }
            else if (Q3 == N)
            {
                lblQ3.Text = "Question 3: " + "\n" + N + " " + 3.ToString();
                result += 3.0;
            }
            else if (Q3 == D)
            {
                lblQ3.Text = "Question 3: " + "\n" + D + " " + 2.ToString();
                result += 2.0;
            }
            else if (Q3 == S)
            {
                lblQ3.Text = "Question 3: " + "\n" + S + " " + 1.ToString();
                result += 1.0;
            }


            if (Q4 == SA)
            {
                lblQ4.Text = "Question 4: " + "\n" + SA + " " + 5.ToString();
                result += 5.0;
            }
            else if (Q4 == A)
            {
                lblQ4.Text = "Question 4: " + "\n" + A + " " + 4.ToString();
                result += 4.0;
            }
            else if (Q4 == N)
            {
                lblQ4.Text = "Question 4: " + "\n" + N + " " + 3.ToString();
                result += 3.0;
            }
            else if (Q4 == D)
            {
                lblQ4.Text = "Question 4: " + "\n" + D + " " + 2.ToString();
                result += 2.0;
            }
            else if (Q4 == S)
            {
                lblQ4.Text = "Question 4: " + "\n" + S + " " + 1.ToString();
                result += 1.0;
            }


            if (Q5 == SA)
            {
                lblQ5.Text = "Question 5: " + "\n" + SA + " " + 5.ToString();
                result += 5.0;
            }
            else if (Q5 == A)
            {
                lblQ5.Text = "Question 5: " + "\n" + A + " " + 4.ToString();
                result += 4.0;
            }
            else if (Q5 == N)
            {
                lblQ5.Text = "Question 5: " + "\n" + N + " " + 3.ToString();
                result += 3.0;
            }
            else if (Q5 == D)
            {
                lblQ5.Text = "Question 5: " + "\n" + D + " " + 2.ToString();
                result += 2.0;
            }
            else if (Q5 == S)
            {
                lblQ5.Text = "Question 5: " + "\n" + S + " " + 1.ToString();
                result += 1.0;
            }


            if (Q6 == SA)
            {
                lblQ6.Text = "Question 6: " + "\n" + SA + " " + 5.ToString();
                result += 5.0;
            }
            else if (Q6 == A)
            {
                lblQ6.Text = "Question 6: " + "\n" + A + " " + 4.ToString();
                result += 4.0;
            }
            else if (Q1 == N)
            {
                lblQ6.Text = "Question 6: " + "\n" + N + " " + 3.ToString();
                result += 3.0;
            }
            else if (Q6 == D)
            {
                lblQ6.Text = "Question 6: " + "\n" + D + " " + 2.ToString();
                result += 2.0;
            }
            else if (Q6 == S)
            {
                lblQ6.Text = "Question 6: " + "\n" + S + " " + 1.ToString();
                result += 1.0;
            }


            if (Q7 == SA)
            {
                lblQ7.Text = "Question 7: " + "\n" + SA + " " + 5.ToString();
                result += 5.0;
            }
            else if (Q7 == A)
            {
                lblQ7.Text = "Question 7: " + "\n" + A + " " + 4.ToString();
                result += 4.0;
            }
            else if (Q7 == N)
            {
                lblQ7.Text = "Question 7: " + "\n" + N + " " + 3.ToString();
                result += 3.0;
            }
            else if (Q7 == D)
            {
                lblQ7.Text = "Question 7: " + "\n" + D + " " + 2.ToString();
                result += 2.0;
            }
            else if (Q7 == S)
            {
                lblQ7.Text = "Question 7: " + "\n" + S + " " + 1.ToString();
                result += 1.0;
            }

            if (Q8 == SA)
            {
                lblQ8.Text = "Question 8: " + "\n" + SA + " " + 5.ToString();
                result += 5.0;
            }
            else if (Q8 == A)
            {
                lblQ8.Text = "Question 8: " + "\n" + A + " " + 4.ToString();
                result += 4.0;
            }
            else if (Q8 == N)
            {
                lblQ8.Text = "Question 8: " + "\n" + N + " " + 3.ToString();
                result += 3.0;
            }
            else if (Q8 == D)
            {
                lblQ8.Text = "Question 8: " + "\n" + D + " " + 2.ToString();
                result += 2.0;
            }
            else if (Q8 == S)
            {
                lblQ8.Text = "Question 8: " + "\n" + S + " " + 1.ToString();
                result += 1.0;
            }


            if (Q9 == SA)
            {
                lblQ9.Text = "Question 9: " + "\n" + SA + " " + 5.ToString();
                result += 5.0;
            }
            else if (Q9 == A)
            {
                lblQ9.Text = "Question 9: " + "\n" + A + " " + 4.ToString();
                result += 4.0;
            }
            else if (Q9 == N)
            {
                lblQ9.Text = "Question 9: " + "\n" + N + " " + 3.ToString();
                result += 3.0;
            }
            else if (Q9 == D)
            {
                lblQ9.Text = "Question 9: " + "\n" + D + " " + 2.ToString();
                result += 2.0;
            }
            else if (Q9 == S)
            {
                lblQ9.Text = "Question 9: " + "\n" + S + " " + 1.ToString();
                result += 1.0;
            }


            if (Q10 == SA)
            {
                lblQ10.Text = "Question 10: " + "\n" + SA + " " + 5.ToString();
                result += 5.0;
            }
            else if (Q10 == A)
            {
                lblQ10.Text = "Question 10: " + "\n" + A + " " + 4.ToString();
                result += 4.0;
            }
            else if (Q10 == N)
            {
                lblQ10.Text = "Question 10: " + "\n" + N + " " + 3.ToString();
                result += 3.0;
            }
            else if (Q10 == D)
            {
                lblQ10.Text = "Question 10: " + "\n" + D + " " + 2.ToString();
                result += 2.0;
            }
            else if (Q10 == S)
            {
                lblQ10.Text = "Question 10: " + "\n" + S + " " + 1.ToString();
                result += 1.0;
            }

            if (Q11 == SA)
            {
                lblQ11.Text = "Question 11: " + "\n" + SA + " " + 5.ToString();
                result += 5.0;
            }
            else if (Q11 == A)
            {
                lblQ11.Text = "Question 11: " + "\n" + A + " " + 4.ToString();
                result += 4.0;
            }
            else if (Q11 == N)
            {
                lblQ11.Text = "Question 11: " + "\n" + N + " " + 3.ToString();
                result += 3.0;
            }
            else if (Q11 == D)
            {
                lblQ11.Text = "Question 11: " + "\n" + D + " " + 2.ToString();
                result += 2.0;
            }
            else if (Q11 == S)
            {
                lblQ11.Text = "Question 11: " + "\n" + S + " " + 1.ToString();
                result += 1.0;
            }


            if (Q12 == SA)
            {
                lblQ12.Text = "Question 12: " + "\n" + SA + " " + 5.ToString();
                result += 5.0;
            }
            else if (Q12 == A)
            {
                lblQ12.Text = "Question 12: " + "\n" + A + " " + 4.ToString();
                result += 4.0;
            }
            else if (Q12 == N)
            {
                lblQ12.Text = "Question 12: " + "\n" + N + " " + 3.ToString();
                result += 3.0;
            }
            else if (Q12 == D)
            {
                lblQ12.Text = "Question 12: " + "\n" + D + " " + 2.ToString();
                result += 2.0;
            }
            else if (Q12 == S)
            {
                lblQ12.Text = "Question 12: " + "\n" + S + " " + 1.ToString();
                result += 1.0;
            }

            if (QS1 == SA)
            {
                lblQS1.Text = "Question 1: " + "\n" + SA + " " + 5.ToString();
                result2 += 5.0;
            }
            else if (QS1 == A)
            {
                lblQS1.Text = "Question 1: " + "\n" + A + " " + 4.ToString();
                result2 += 4.0;
            }
            else if (QS1 == N)
            {
                lblQS1.Text = "Question 1: " + "\n" + N + " " + 3.ToString();
                result2 += 3.0;
            }
            else if (QS1 == D)
            {
                lblQS1.Text = "Question 1: " + "\n" + D + " " + 2.ToString();
                result2 += 2.0;
            }
            else if (QS1 == S)
            {
                lblQS1.Text = "Question 1: " + "\n" + S + " " + 1.ToString();
                result2 += 1.0;
            }


            if (QS2 == SA)
            {
                lblQS2.Text = "Question 2: " + "\n" + SA + " " + 5.ToString();
                result2 += 5.0;
            }
            else if (QS2 == A)
            {
                lblQS2.Text = "Question 2: " + "\n" + A + " " + 4.ToString();
                result2 += 4.0;
            }
            else if (QS2 == N)
            {
                lblQS2.Text = "Question 2: " + "\n" + N + " " + 3.ToString();
                result2 += 3.0;
            }
            else if (QS2 == D)
            {
                lblQS2.Text = "Question 2: " + "\n" + D + " " + 2.ToString();
                result2 += 2.0;
            }
            else if (QS2 == S)
            {
                lblQS2.Text = "Question 2: " + "\n" + S + " " + 1.ToString();
                result2 += 1.0;
            }


            if (QS3 == SA)
            {
                lblQS3.Text = "Question 3: " + "\n" + SA + " " + 5.ToString();
                result2 += 5.0;
            }
            else if (QS3 == A)
            {
                lblQS3.Text = "Question 3: " + "\n" + A + " " + 4.ToString();
                result2 += 4.0;
            }
            else if (QS3 == N)
            {
                lblQS3.Text = "Question 3: " + "\n" + N + " " + 3.ToString();
                result2+= 3.0;
            }
            else if (QS3 == D)
            {
                lblQS3.Text = "Question 3: " + "\n" + D + " " + 2.ToString();
                result2 += 2.0;
            }
            else if (QS3 == S)
            {
                lblQS3.Text = "Question 3: " + "\n" + S + " " + 1.ToString();
                result2 += 1.0;
            }





            if (QS4 == SA)
            {
                lblQS4.Text = "Question 4: " + "\n" + SA + " " + 5.ToString();
                result2 += 5.0;
            }
            else if (QS4 == A)
            {
                lblQS4.Text = "Question 4: " + "\n" + A + " " + 4.ToString();
                result2 += 4.0;
            }
            else if (QS4 == N)
            {
                lblQS4.Text = "Question 4: " + "\n" + N + " " + 3.ToString();
                result2 += 3.0;
            }
            else if (QS4 == D)
            {
                lblQS4.Text = "Question 4: " + "\n" + D + " " + 2.ToString();
                result2 += 2.0;
            }
            else if (QS4 == S)
            {
                lblQS4.Text = "Question 4: " + "\n" + S + " " + 1.ToString();
                result2 += 1.0;
            }


            if (QS5 == SA)
            {
                lblQS5.Text = "Question 5: " + "\n" + SA + " " + 5.ToString();
                result2 += 5.0;
            }
            else if (QS5 == A)
            {
                lblQS5.Text = "Question 5: " + "\n" + A + " " + 4.ToString();
                result2 += 4.0;
            }
            else if (QS5 == N)
            {
                lblQS5.Text = "Question 5: " + "\n" + N + " " + 3.ToString();
                result2 += 3.0;
            }
            else if (QS5 == D)
            {
                lblQS5.Text = "Question 5: " + "\n" + D + " " + 2.ToString();
                result2 += 2.0;
            }
            else if (QS5 == S)
            {
                lblQS5.Text = "Question 5: " + "\n" + S + " " + 1.ToString();
                result2 += 1.0;
            }


            if (QS6 == SA)
            {
                lblQS6.Text = "Question 6: " + "\n" + SA + " " + 5.ToString();
                result2 += 5.0;
            }
            else if (QS6 == A)
            {
                lblQS6.Text = "Question 6: " + "\n" + A + " " + 4.ToString();
                result2 += 4.0;
            }
            else if (QS6 == N)
            {
                lblQS6.Text = "Question 6: " + "\n" + N + " " + 3.ToString();
                result2 += 3.0;
            }
            else if (QS6 == D)
            {
                lblQS6.Text = "Question 6: " + "\n" + D + " " + 2.ToString();
                result2 += 2.0;
            }
            else if (QS6 == S)
            {
                lblQS6.Text = "Question 6: " + "\n" + S + " " + 1.ToString();
                result2 += 1.0;
            }


            if (QS7 == SA)
            {
                lblQS7.Text = "Question 7: " + "\n" + SA + " " + 5.ToString();
                result2 += 5.0;
            }
            else if (QS7 == A)
            {
                lblQS7.Text = "Question 7: " + "\n" + A + " " + 4.ToString();
                result2 += 4.0;
            }
            else if (QS7 == N)
            {
                lblQS7.Text = "Question 7: " + "\n" + N + " " + 3.ToString();
                result2 += 3.0;
            }
            else if (QS7 == D)
            {
                lblQS7.Text = "Question 7: " + "\n" + D + " " + 2.ToString();
                result2 += 2.0;
            }
            else if (QS7 == S)
            {
                lblQS7.Text = "Question 7: " + "\n" + S + " " + 1.ToString();
                result2 += 1.0;
            }

            if (QS8 == SA)
            {
                lblQS8.Text = "Question 8: " + "\n" + SA + " " + 5.ToString();
                result2 += 5.0;
            }
            else if (QS8 == A)
            {
                lblQS8.Text = "Question 8: " + "\n" + A + " " + 4.ToString();
                result2 += 4.0;
            }
            else if (QS8 == N)
            {
                lblQS8.Text = "Question 8: " + "\n" + N + " " + 3.ToString();
                result2 += 3.0;
            }
            else if (QS8 == D)
            {
                lblQS8.Text = "Question 8: " + "\n" + D + " " + 2.ToString();
                result2 += 2.0;
            }
            else if (QS8 == S)
            {
                lblQS8.Text = "Question 8: " + "\n" + S + " " + 1.ToString();
                result2 += 1.0;
            }

            decimal AverageCourse = Decimal.Parse((result / 12.0).ToString("0.0"));
            lblAC.Text = "Average for course: " + "\n" + AverageCourse;


            decimal AverageProfessor = Decimal.Parse((result2 / 8.0).ToString("0.0"));
            lblAP.Text = "Average for professor: " + "\n" + AverageProfessor;


            double totalResults = result + result2;
            decimal AverageTotal = Decimal.Parse((totalResults / 20.0).ToString("0.0"));
            lblTotal.Text = "The total average: " + AverageTotal;
            
            

            if (AverageTotal >= 4.5m)
            {
                lblLetter.Text = "A";
            }
            else if (AverageTotal >= 4.0m)
            {
                lblLetter.Text = "B";
            }
            else if (AverageTotal >= 3.5m)
            {
                lblLetter.Text = "C";
            }
            else if (AverageTotal >= 3.0m)
            {
                lblLetter.Text = "D";
            }
            else
                lblLetter.Text = "F";
            
        }
    }
}