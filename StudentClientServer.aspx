<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentClientServer.aspx.cs" Inherits="serverside.StudentClientServer" %>  

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"> 
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    Seatno :
                </td>
                 <td>
                    <input type="text" id ="SeatNo"/>
                </td>
            </tr>
              <tr>
                <td>
                    Name :
                </td>
                 <td>
                    <input type="text" id ="Name"/>
                </td>
            </tr>
            <tr>
                <td>
                    FatherName :
                </td>
                 <td>
                    <input type="text" id ="fathername"/>
                </td>
            </tr>
            <tr>
                <td>
                    Address :
                </td>
                 <td>
                    <input type="text" id ="address"/>
                </td>
            </tr>
             <tr>
                <td>
                   <button onclick="addStudent()"> Submit </button>
                </td>
               
            </tr>
       
    </table>
        <br /> <br />
       
        <p id="data">     </p>
    
    </div>
    </form>
     <script>

    
                  // This FUNCTION will execte when we click Submit button.
        function addStudent() {        
              
            var student = new Object();     // initialize an object of Student.

            var Seatno = $('#SeatNo').val();          // taking SeatNo of student
            var Name = $('#Name').val();                // taking Name of student
            var FatherName = $('#fathername').val();    // taking fathername of student
            var Address = $('#address').val();          // taking address of student

              student.Seatno = Seatno;          // storing in student object
              student.Name = Name;
              student.FatherName = FatherName;
              student.Address = Address;            // storing in student object

                    // converting Student object to Json formatted String
              var studentstr = JSON.stringify(student);      

          
                        // making an Ajax call for sending data to server side and further to Database. 
                $.ajax({
                    
                    type: "GET",
                    url: "StudentClientServer.aspx/insertStudent", // hitting (insertStudent) METHOD in StudentClientServer Class
                    contentType: "application/Json",
                    data:
                        {
                         request:studentstr     // data in the JSON formatted string sent to server side.
                        },
                    
                });

                $.ajax({

                    type: "GET",
                    url: "StudentClientServer.aspx/CallStudents",
                    contentType: "application/Json",
                    success: function(result)
                    {
                        var myresult = result;
                        $('#data').text(myresult);

                    },

                });         
          
        }
   
        

    </script>
 </body>
   
</html>
