<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="project1.aspx.cs" Inherits="Project1.project1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        body{
            background-color: navajowhite;
        }

        #border {
            margin: auto;
            border: 5px solid red;
            padding: 10px;

        }

        h1 {
            border-color: burlywood;
            border-style: dotted;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="frmStudentFeedback" runat="server">
                <div id ="border">
            <h1> Student Feedback Form</h1>

            <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblID" runat="server" Text="Student ID:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblCourse" runat="server" Text="Course:"></asp:Label>
            <br />
            <hr/>
            <br />
            <br />
            <asp:Label ID="lblResults" runat="server" Text="Course Rating Results:" Font-Bold="True"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQ1" runat="server" Text="Question 1:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQ2" runat="server" Text="Question 2:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQ3" runat="server" Text="Question 3:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQ4" runat="server" Text="Question 4:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQ5" runat="server" Text="Question 5:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQ6" runat="server" Text="Question 6:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQ7" runat="server" Text="Question 7:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQ8" runat="server" Text="Question 8:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQ9" runat="server" Text="Question 9:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQ10" runat="server" Text="Question 10:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQ11" runat="server" Text="Question 11:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQ12" runat="server" Text="Question 12:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblAC" runat="server" Text="Average for course:"></asp:Label>
            <br />
            <br />
            <hr/>
            <br />
            <br />
            <asp:Label ID="Label14" runat="server" Text="Professor Rating Results:" Font-Bold="True"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQS1" runat="server" Text="Question 1:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQS2" runat="server" Text="Question 2:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQS3" runat="server" Text="Question 3:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQS4" runat="server" Text="Question 4:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQS5" runat="server" Text="Question 5:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQS6" runat="server" Text="Question 6:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQS7" runat="server" Text="Question 7:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQS8" runat="server" Text="Question 8:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblAP" runat="server" Text="Average for professor:"></asp:Label>
            <br />
            <br />
            <hr/>
            <br />
            <br />
            <asp:Label ID="lblTotal" runat="server" Text="Total Average:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label24" runat="server" Text="Letter Grade:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblLetter" runat="server" Text="Letter"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
