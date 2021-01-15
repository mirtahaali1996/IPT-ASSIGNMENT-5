using Newtonsoft.Json;
using System;
using System.Web;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Script.Serialization;
using UBIT.sqldataProject1.ClassHelper;
using System.Collections.Generic;

namespace serverside
{
   
    public partial class StudentClientServer : System.Web.UI.Page
    {
       
        //              Initializes the Class object HERE for GLOBAL access.
        static StudentHelper studentHelper;  

        //              This METHOD WORKS just like your  Main Method.
        protected void Page_Load(object sender, EventArgs e)  
        {
            studentHelper = new StudentHelper();
        }


        [ScriptMethod(ResponseFormat = ResponseFormat.Json ,UseHttpGet = true)]
        [WebMethod]
                                                           //This METHOD insertStudent() will be executed when Ajax call occurs.
        public static void insertStudent()          
        {
            var Students = HttpContext.Current.Request["request"];

                                                                       // json formatted string will now be converted to Object and stored in newstdudent
            var newstdudent = JsonConvert.DeserializeObject<Studentserverclass>(Students);            

                                                                   // AddStudent Method will be called with help of StudentHelper Object.
            studentHelper.AddStudent(newstdudent.Seatno, newstdudent.Name, newstdudent.FatherName, newstdudent.Address);

                                    ///////////////////////////////////////////////////////////////////////


        }

            
             [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
             [WebMethod]
                                                      //  This Method 'CallStudents' is for retrieving Values of Student Table from DataBae.
              public static string CallStudents()       
             {
                                                        //  GetAllStudents() Method will be called here with help of studentHelper class.
                                                        //  Student Lists now be stored in studentlist variable.
                   var studentlist = studentHelper.GetAllStudents();

                                                                    //  List type Object is created here of variable name allRecords.
                   var allRecords = new List<Studentserverclass>();

                                                                //   each row of Student table will be extracted in 'r' from VARIABLE  'studentlist'
                    foreach(var r in studentlist) 
                    {
                                                                 //   Object of 'Studentserverclass' is initialized.
                        var s = new Studentserverclass(); 

                                                         //  each property of Student is initialize to 'Studentserverclass' Object.
                        s.Seatno = r.SeatNo;           
                        s.Name = r.Name;
                        s.FatherName = r.FatherName;
                        s.Address = r.Address;

                                                 //  each row of Student table formatted as object form will then be transfered to 'allRecords' 'List type Object'
                        allRecords.Add(s);     
                     }
                                                 //  'allRecords' List type Object will now be formatted as JSON string and will be stored in 'varStrrecord' variable.
                      var varStrrecord = JsonConvert.SerializeObject(allRecords);

                      return varStrrecord;

                }       


    }
             


        public class Studentserverclass
        {
            public string Seatno { get; set; }
            public string Name { get; set; }
            public string FatherName { get; set; }
            public string Address { get; set; }
        }
    
}