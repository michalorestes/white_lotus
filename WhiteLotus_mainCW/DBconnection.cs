 ///////     *SUMMARY*   ////////
// DATABASE CONNECTION CLASS  //
// inclused db connection     //
// string and methods for     //
// reading and writting to db //
////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data; 
using System.Linq;
using System.Web;



namespace WhiteLotus_mainCW
{
    public static class DBconnection
    {

        //email validation missing. check for duplicate emails 

        static OleDbConnection connection;
        static OleDbCommand command;


        //insert data in to DB for a new user (Admin type needs to be specyfied while instantiating new object)
        public static void addUser(User u)
        {
            connectTo();
            try
            {
                command.CommandText = "INSERT INTO Client (UserName, DOB, YogaExperience, HealthIssues, Email, TelNo, UserPassword, Admin, Anusara, Bikram, Hatha )" + 
                                      "VALUES('" + u.Name + "', '"+ u.DateOfBirth +"', '"+ u.Experience +"', '"+ u.Health +"', '"+ u.Email +"', '"+ u.TelNo +"', '"+ u.Password +"','" + u.Admin + "', " + u.Anusara +", " + u.Bikram + ", "+ u.Hatha +")";         //SQL Querry (Uses AutoNumber!) 
                
                command.CommandType = CommandType.Text;         //command type 
                connection.Open();                              //open DB Connection 
                command.ExecuteNonQuery();                      //Execute Querry 
                 
            }
            catch (OleDbException ex)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('This email address has been " +
                    "registered with another account. Please use different email address or contact the administrator to reset your password.')</script>");                
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();                       //close DB connection
                }
            }
        }//end of insert() 

        //Get user's password based on provided email address
        public static string getPassword(string email)

        {
            connectTo();
            try
            {
                command.CommandText = "SELECT UserPassword FROM Client WHERE Email='" + email + "'";
                command.CommandType = CommandType.Text;
                connection.Open();
                OleDbDataReader read = command.ExecuteReader();
                string userPassword=null;
                while (read.Read())
                {
                    userPassword = read["UserPassword"].ToString();
                }

                return userPassword;
                //WARRNING: if email does not exists in the database, this function will return an empty string. Needs to be handled where this method is being used. 
            }
            catch (OleDbException ex)
            {
                /* HANDLE EXCEPTION HERE */

                System.Web.HttpContext.Current.Response.Write("<script>alert('Account does not exist. Please register.')</script>");
                return null;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close(); 
                }    
            }
            
        }//end of getPassword()

        //get user details based on provided email
        public static User getUser(string email)
        {
            connectTo();
            User u = new User();
            try
            {
                command.CommandText = "SELECT * FROM Client WHERE Email='" + email + " '";
                command.CommandType = CommandType.Text;
                connection.Open();
                OleDbDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    u.Id = (int)read["ID"];
                    u.Name = read["UserName"].ToString();
                    u.DateOfBirth = read["DOB"].ToString();
                    u.Experience = read["YogaExperience"].ToString();
                    u.Health = read["HealthIssues"].ToString();
                    u.Email = read["Email"].ToString();
                    u.TelNo = long.Parse(read["TelNo"].ToString());
                    u.Password = read["UserPassword"].ToString();
                    u.Admin = read["Admin"].ToString();
                    u.Anusara = (bool)read["Anusara"];
                    u.Bikram = (bool)read["Bikram"];
                    u.Hatha = (bool)read["Hatha"];
                }
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('"+ ex.Message +"')</script>");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return u;
        }

        //get instructors details in DataTable type
        public static DataTable getInstructorsDetailsDT()
        {
            connectTo();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[12]
            {
                new DataColumn("ID", typeof(int)), 
                new DataColumn("Name", typeof(string)),
                new DataColumn("DOB", typeof(string)),
                new DataColumn("Yoga Experience", typeof(string)),
                new DataColumn("Health Issues", typeof(string)),
                new DataColumn("E-mail", typeof(string)), 
                new DataColumn("Telephone", typeof(long)),
                new DataColumn("Password", typeof(string)),
                new DataColumn("Type", typeof(string)), 
                new DataColumn("Anusara", typeof(bool)),
                new DataColumn("Bikram", typeof(bool)),
                new DataColumn("Hatha", typeof(bool))

            });


            command.CommandText = "SELECT * FROM Client Where Admin='Instructor'";
            command.CommandType = CommandType.Text;
            connection.Open();

            OleDbDataReader read = command.ExecuteReader();

            try
            {
                while (read.Read())
                {
                    int id = (int)read["ID"];
                    string name = read["UserName"].ToString();
                    string dateOfBirth = read["DOB"].ToString();
                    string experience = read["YogaExperience"].ToString();
                    string health = read["HealthIssues"].ToString();
                    string email = read["Email"].ToString();
                    long telNo = long.Parse(read["TelNo"].ToString());
                    string password = read["UserPassword"].ToString();
                    string admin = read["Admin"].ToString();
                    bool anusara = (bool)read["Anusara"];
                    bool bikram = (bool)read["Bikram"];
                    bool hatha = (bool)read["Hatha"];

                    dt.Rows.Add(
                        id,
                        name,
                        dateOfBirth,
                        experience,
                        health,
                        email,
                        telNo,
                        password,
                        admin,
                        anusara,
                        bikram,
                        hatha
                        );
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

            return dt; 
        }

        //get instructors details inside a list 
        public static List<User> getInstructorsList()
        {
            connectTo();
            List<User> instructors = new List<User>();


            command.CommandText = "SELECT * FROM Client Where Admin='Instructor'";
            command.CommandType = CommandType.Text;
            connection.Open();

            OleDbDataReader read = command.ExecuteReader();

            try
            {
                while (read.Read())
                {
                    User i = new User();
                    i.Id = (int)read["ID"];
                    i.Name = read["UserName"].ToString();
                    i.DateOfBirth = read["DOB"].ToString();
                    i.Experience = read["YogaExperience"].ToString();
                    i.Health = read["HealthIssues"].ToString();
                    i.Email = read["Email"].ToString();
                    i.TelNo = long.Parse(read["TelNo"].ToString());
                    i.Password = read["UserPassword"].ToString();
                    i.Admin = read["Admin"].ToString();
                    i.Anusara = (bool)read["Anusara"];
                    i.Bikram = (bool)read["Bikram"];
                    i.Hatha = (bool)read["Hatha"];

                    instructors.Add(i);
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }



            return instructors;
        }

        //get user based on his ID number
        public static User getUser(int ID)
        {
            connectTo();
            User u = new User();

            try
            {
                command.CommandText = "SELECT * FROM Client WHERE ID=" + ID;
                command.CommandType = CommandType.Text;
                connection.Open();
                OleDbDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    u.Id = (int)read["ID"];
                    u.Name = read["UserName"].ToString();
                    u.DateOfBirth = read["DOB"].ToString();
                    u.Experience = read["YogaExperience"].ToString();
                    u.Health = read["HealthIssues"].ToString();
                    u.Email = read["Email"].ToString();
                    u.TelNo = long.Parse(read["TelNo"].ToString());
                    u.Password = read["UserPassword"].ToString();
                    u.Admin = read["Admin"].ToString();
                    u.Anusara = (bool)read["Anusara"];
                    u.Bikram = (bool)read["Bikram"];
                    u.Hatha = (bool)read["Hatha"];
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                connection.Close(); 
            }




            return u; 
        }

        


        //add a yoga session
        public static void addWorkshop(Workshop s)
        {
            connectTo();
            try
            {
                //Add session details to a database 
                command.CommandText = "INSERT INTO Workshop (Title, Description, Style, SessionLevel, StartDate, Reservations, StartTime, Duration, Capacity, Room, fkInstructorID, Status) " +
                                      " VALUES('"+ s.Title +"', '"+ s.Description +"', '" + s.Style +"', '" + s.Level +"', '" + 
                                      s.StartDate.ToShortDateString() +"', "+ s.Reservations +", '"+ s.Time.ToString() +"', "+ s.Duration +", "+ s.Capacity +",'" +
                                      s.Room +"', " + s.InstructorID + ",'Active')";         //SQL Querry (Uses AutoNumber!) 


                command.CommandType = CommandType.Text;         //command type 
                connection.Open();                              //open DB Connection 
                command.ExecuteNonQuery();                      //Execute Querry 
                
            }
            catch (OleDbException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('" + command.CommandText.ToString() + "')</script>");               
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();                       //close DB connection
                }
            }

               
        }

        public static void addClass(Class s)
        {
            connectTo();
            try
            {
                connection.Open();                              //open DB Connection 
                for (int i = 0; i < s.Schedules.Count; i++)
                {
                    //Add session details to a database 
                    command.CommandText = "INSERT INTO Class (Title, Description, Style, SessionLevel, StartDate, Reservations, StartTime, Duration, Capacity, Room, fkInstructorID, Status) " +
                                          " VALUES('" + s.Title + "', '" + s.Description + "', '" + s.Style + "', '" + s.Level + "', '" +
                                          s.Schedules[i].ToShortDateString() + "', " + s.Reservations + ", '" + s.Time.ToString() + "', " + s.Duration + ", " + s.Capacity + ",'" +
                                          s.Room + "', " + s.InstructorID + ",'Active')";         //SQL Querry (Uses AutoNumber!) 


                    command.CommandType = CommandType.Text;         //command type 
                    
                    command.ExecuteNonQuery();                      //Execute Querry 
                }


               

            }
            catch (OleDbException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('" + command.CommandText.ToString() + "')</script>");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();                       //close DB connection
                }
            }


        }

        //get the most recent record from a table 
        public static int lastPK(string column, string table)
        {
            connectTo();
            int max = 0;

            try
            {
                command.CommandText = "SELECT MAX(" + column + ") FROM "+ table +";";         //SQL Querry (Uses AutoNumber!) 


                command.CommandType = CommandType.Text;         //command type 
                connection.Open(); 
                max = (int)command.ExecuteScalar(); 

            }
            catch (OleDbException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            
            return max; 
        }
        //Get Class or workshop details for admin panel 
        public static DataTable getSessionsAdmin(string type)
        {
            connectTo();
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[] {
                    new DataColumn("SessionID", typeof(int)),
                    new DataColumn("Title", typeof(string)),
                    new DataColumn("Description", typeof(string)),
                    new DataColumn("Style", typeof(string)),
                    new DataColumn("Level", typeof(string)),
                    new DataColumn("Session Date", typeof(string)),
                    new DataColumn("Time", typeof(string)),
                    new DataColumn("Duration", typeof(int)),
                    new DataColumn("Capacity", typeof(int)),
                    new DataColumn("Reservations", typeof(int)),
                    new DataColumn("Room", typeof(string)),
                    new DataColumn("Instructors", typeof(int)),
                    new DataColumn("Status", typeof(string))
                });


            try
            {
                command.CommandText = "SELECT * FROM " + type + " ORDER BY StartDate ASC";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader read = command.ExecuteReader();
               
                //compare choosen date with session's date
                //RETURN VALUES MEANING
                // less than 0 = t1 is earlier than t2
                //zero = t1 is same as t2
                // more than zero = t1 is later than t2 
                //source: https://msdn.microsoft.com/en-us/library/system.datetime.compare(v=vs.110).aspx 
                
                //display all sessions from today onwards 
                while (read.Read())
                {
                    DateTime scheduleTime = DateTime.Parse(read["StartDate"].ToString());
                    int results = DateTime.Compare(scheduleTime.Date, DateTime.Now);
                    if (results > 0 || results == 0 )
                    {
                        dt.Rows.Add(
                                (int)read["ID"],
                                (string)read["Title"],
                                (string)read["Description"],
                                (string)read["Style"],
                                (string)read["SessionLevel"],
                                DateTime.Parse(read["StartDate"].ToString()).ToShortDateString(),
                                (string)read["StartTime"],
                                (int)read["Duration"],
                                (int)read["Capacity"],
                                (int)read["Reservations"],
                                (string)read["Room"],
                                (int)read["fkInstructorID"],
                                (string)read["Status"]
                                );
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return dt; 
        }
        //Delete session record. and reservation 
        public static void deleteRecord(string table, int id, string column)
        {
            connectTo();
            try
            {
                command.CommandText = "DELETE FROM " + table + " WHERE "+ column +"=" + id;
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();



            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        //get status (flag) of a particular session (class or workshop)
        public static string getStatus(string id, string table)
        {
            connectTo();
            string status = "";

            try
            {
                command.CommandText = "SELECT Status FROM " + table + " WHERE ID=" + id;
                command.CommandType = CommandType.Text;
                connection.Open();
                OleDbDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    status = read["Status"].ToString();
                }
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return status;
        }
        //set status of a particular session (either class or workshop)
        public static void changeStatus(string table, string status, string id)
        {
            connectTo();
            try
            {
                command.CommandText = "Update " + table + " SET Status='" + status
                                      + "' WHERE ID =" + id ;
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                System.Web.HttpContext.Current.Response.Write("<script>" + command.CommandText.ToString() + "</script>");
            }
            
            finally
            {
                connection.Close();
            }





        }
        //return a List that contains details about all classess/workshops
        //IT WILL NOT RETURN SESSIONS FROM BEFORE CURRENT DATE!
        public static List<Class> getClasses(bool condition, DateTime date)
        {
            connectTo();
            //CONDITION PARAMETER:
            //if TRUE -  store all future sessions in sessions List
            //if FALSE - store only sessions that occur on same date as provided in DateTime date

            List<Class> sessions = new List<Class>();
            

            try
            {
                command.CommandText = "SELECT * FROM Class ORDER BY StartDate ASC";
                command.CommandType = CommandType.Text;
                connection.Open();
                OleDbDataReader read = command.ExecuteReader();
                
                while (read.Read())
                {
                    Class s = new Class(
                        DateTime.Parse(read["StartDate"].ToString()), 
                        TimeSpan.Parse(read["StartTime"].ToString()),
                        read["Style"].ToString(), 
                        read["SessionLevel"].ToString(), 
                        (int)read["fkInstructorID"], 
                        (int)read["Duration"], 
                        (int)read["Capacity"], 
                        read["Title"].ToString(), 
                        read["Description"].ToString(),
                        read["Room"].ToString(), 
                        (int)read["Reservations"],
                        0  
                        );
                    s.Id = (int)read["ID"];
                    s.Status = read["Status"].ToString();

                    //get sessions date and store it in DateTime variable 
                    DateTime scheduleTime = new DateTime(s.StartDate.Year, s.StartDate.Month, s.StartDate.Day);

                    //compare choosen date with session's date
                    //RETURN VALUES MEANING
                    // less than 0 = t1 is earlier than t2
                    //zero = t1 is same as t2
                    // more than zero = t1 is later than t2 
                    //source: https://msdn.microsoft.com/en-us/library/system.datetime.compare(v=vs.110).aspx 
                    int results = DateTime.Compare(scheduleTime.Date, date.Date);

                    //display all sessions from today onwards 
                    if (condition)
                    {
                        
                        if (results > 0 || results == 0)
                        {
                            sessions.Add(s);
                        }
                    }
                    //display sessions on a choosen date 
                    else if (!condition)
                    {
                        int oldCheck = DateTime.Compare(scheduleTime.Date, DateTime.Now.Date);
                        if (results == 0 && oldCheck >= 0)
                        {
                            sessions.Add(s);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
            
            
            return sessions; 
        }

        public static List<Workshop> getWorkshops(bool condition, DateTime date)
        {
            connectTo();
            //CONDITION PARAMETER:
            //if TRUE -  store all future sessions in sessions List
            //if FALSE - store only sessions that occur on same date as provided in DateTime date

            List<Workshop> sessions = new List<Workshop>();


            try
            {
                command.CommandText = "SELECT * FROM Workshop ORDER BY StartDate ASC";
                command.CommandType = CommandType.Text;
                connection.Open();
                OleDbDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    Workshop s = new Workshop(
                        DateTime.Parse(read["StartDate"].ToString()),
                        TimeSpan.Parse(read["StartTime"].ToString()),
                        read["Style"].ToString(),
                        read["SessionLevel"].ToString(),
                        (int)read["fkInstructorID"],
                        (int)read["Duration"],
                        (int)read["Capacity"],
                        read["Title"].ToString(),
                        read["Description"].ToString(),
                        read["Room"].ToString(),
                        (int)read["Reservations"]
                        
                        );
                    s.Id = (int)read["ID"];
                    s.Status = read["Status"].ToString();

                    //get sessions date and store it in DateTime variable 
                    DateTime scheduleTime = new DateTime(s.StartDate.Year, s.StartDate.Month, s.StartDate.Day);

                    //compare choosen date with session's date
                    //RETURN VALUES MEANING
                    // less than 0 = t1 is earlier than t2
                    //zero = t1 is same as t2
                    // more than zero = t1 is later than t2 
                    //source: https://msdn.microsoft.com/en-us/library/system.datetime.compare(v=vs.110).aspx 
                    int results = DateTime.Compare(scheduleTime.Date, date.Date);

                    //display all sessions from today onwards 
                    if (condition)
                    {

                        if (results > 0 || results == 0)
                        {
                            sessions.Add(s);
                        }
                    }
                    //display sessions on a choosen date 
                    else if (!condition)
                    {
                        int oldCheck = DateTime.Compare(scheduleTime.Date, DateTime.Now.Date);
                        if (results == 0 && oldCheck >= 0)
                        {
                            sessions.Add(s);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }


            return sessions;
        }
        //returns a single class 
        public static Class getClass(int id)
        {
            connectTo();
            Class c = null; 
            try
            {
                command.CommandText = "SELECT * FROM Class WHERE ID=" + id;
                command.CommandType = CommandType.Text;
                connection.Open();
                OleDbDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    c = new Class(
                        DateTime.Parse(read["StartDate"].ToString()),
                        TimeSpan.Parse(read["StartTime"].ToString()),
                        read["Style"].ToString(),
                        read["SessionLevel"].ToString(),
                        (int)read["fkInstructorID"],
                        (int)read["Duration"],
                        (int)read["Capacity"],
                        read["Title"].ToString(),
                        read["Description"].ToString(),
                        read["Room"].ToString(),
                        (int)read["Reservations"],
                        0
                        );
                    c.Id = (int)read["ID"]; 

                }

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                connection.Close();
            }

            return c; 
            
        }

        //get a single workshop
        public static Workshop getWorkshop(int id)
        {
            connectTo();
            Workshop c = null;
            try
            {
                command.CommandText = "SELECT * FROM Workshop WHERE ID=" + id;
                command.CommandType = CommandType.Text;
                connection.Open();
                OleDbDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    c = new Workshop(
                        DateTime.Parse(read["StartDate"].ToString()),
                        TimeSpan.Parse(read["StartTime"].ToString()),
                        read["Style"].ToString(),
                        read["SessionLevel"].ToString(),
                        (int)read["fkInstructorID"],
                        (int)read["Duration"],
                        (int)read["Capacity"],
                        read["Title"].ToString(),
                        read["Description"].ToString(),
                        read["Room"].ToString(),
                        (int)read["Reservations"]
                        
                        );
                    c.Id = (int)read["ID"];

                }

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                connection.Close();
            }

            return c;

        }
        //update session's reservations  
        public static void updateSessionReservation(string type, int reservations, Reservation r)
        {
            connectTo();
            try
            {
                command.CommandText = "UPDATE " + type +" SET Reservations=" + reservations + " WHERE ID=" + r.SessionID;
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery(); 
            }
            catch (Exception)
            {

                throw;
            } 
            finally
            {
                connection.Close(); 
            }
        }

        //reserve a session 
        public static void reserveSession(Reservation r, string type)
        {
            connectTo();
            try
            {
                command.CommandText = "INSERT INTO Reservation (" + type + "ID, ReservationDate, UserID) VALUES (" + 
                                        r.SessionID + ",'" + r.ReservationDate + "'," + r.UserID + ")";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery(); 

            }
            catch (Exception)
            {

                HttpContext.Current.Response.Write("<script>alert('" + command.CommandText.ToString() + "')</script>");
            } 
            finally
            {
                connection.Close();
            }
        }

        //returns all class reservation details for a particular user 
        public static List<Reservation> getClassReservations(int userID, string type)
        {
            connectTo();
            List<Reservation> reservations = new List<Reservation>();
            string mySql = "";
            try
            {
                command.CommandText = "SELECT Reservation.ID, Reservation." + type + "ID," + type + ".StartTime, Reservation.ReservationDate," + type + ".Title," + type + ".StartDate," + type+".Status  From "+ type +
                                        " INNER JOIN Reservation ON "+ type + ".ID = Reservation." +type +"ID WHERE UserID =" + userID;
                command.CommandType = CommandType.Text;
                connection.Open();
                OleDbDataReader read = command.ExecuteReader();

                mySql = command.CommandText.ToString();

                while (read.Read())
                {
                    Reservation r = new Reservation(
                        (int) read["ID"],
                        (int)read[type+"ID"],
                        (DateTime) read["StartDate"],
                        (DateTime) read["ReservationDate"],
                        (string) read["Title"],
                        (string) read["Status"],
                        type
                        );
                    r.Time = TimeSpan.Parse(read["StartTime"].ToString());
                    reservations.Add(r);

                }


            }
            catch (Exception ex)
            {

                System.Web.HttpContext.Current.Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

            finally
            {
                connection.Close();
                
            }


            return reservations; 

        }
        //returns a single reservation based on ID and type 
        public static Reservation getReservation(int id, string type)
        {
            connectTo();
            Reservation reservations = null;
            string mySql = "";
            try
            {
                command.CommandText = "SELECT ID, " + type + "ID, ReservationDate,  UserID FROM Reservation WHERE ID="+id;
                command.CommandType = CommandType.Text;
                connection.Open();
                OleDbDataReader read = command.ExecuteReader();

                mySql = command.CommandText.ToString();

                while (read.Read())
                {
                    reservations = new Reservation(
                        (int)read["ID"],
                        (int)read[type + "ID"],
                        (DateTime)read["ReservationDate"],
                        (int)read["UserID"],
                        
                        type
                        );

                   

                }


            }
            catch (Exception ex)
            {

                System.Web.HttpContext.Current.Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

            finally
            {
                connection.Close();

            }


            return reservations;

        }

        public static void addToQueue(int userID, int sessionID, string sessionType)
        {
            connectTo();
            try
            {
                command.CommandText = "INSERT INTO Queue (SessionID, QDate, UserID, SessionType) VALUES (" + sessionID + ", '" + DateTime.Now +"', "+ userID +", '"+ sessionType +"') ";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery(); 

            }
            catch (Exception)
            {

               HttpContext.Current.Response.Write("<script>alert('Unable to add to the queue')</script>");
            }
            finally
            {
                connection.Close();
            }

        }


        //QUEUE FUNCTIONALITY

        //return a list of all ques assigned to a specyfic user 
        public static List<Queue> viewUserQueues(int userID)
        {
            connectTo();
            List<Queue> queues = new List<Queue>();
             


            try
            {
                command.CommandText = "SELECT * FROM Queue Where UserID=" + userID;
                command.CommandType = CommandType.Text;
                connection.Open();
                OleDbDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                   Queue q = new Queue(
                        (int) read["ID"],
                        (int) read["SessionID"],
                        (int) read["UserID"],
                        (string) read["SessionType"], 
                        (DateTime)read["QDate"]
                        );
                    queues.Add(q);
                }
                
            }
            catch (Exception)
            {
                HttpContext.Current.Response.Write("<script>alert('Unable to read from the queue')</script>");
                return null; 
            }
            finally
            {
                connection.Close();
            }

            return queues; 
           
        }
        //returns a list of all quques assigned to a particular session 
        public static List<Queue> viewSessionQueue(int sessionID, string type)
        {
            List<Queue> sessionQ = new List<Queue>();

            try
            {
                command.CommandText = "SELECT " + type + ".Title, " + type + ".StartDate, Queue.ID, Queue.SessionID, Queue.UserID, Queue.SessionType, Queue.QDate" + 
                                      " FROM Queue INNER JOIN " + type + " ON Queue.SessionID=" + type + ".ID ORDER BY QDate ASC";
                command.CommandType = CommandType.Text;
                connection.Open();
                OleDbDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    Queue q = new Queue(
                         (int)read["ID"],
                         (int)read["SessionID"],
                         (int)read["UserID"],
                         (string)read["SessionType"],
                         (DateTime)read["QDate"]
                         );
                    q.ReservationDate = DateTime.Parse(read["StartDate"].ToString());
                    q.SessionTitle = (string)read["Title"];
                    sessionQ.Add(q);
                }

            }
            catch (Exception)
            {

                return null;
            }

            finally
            {
                connection.Close(); 
            }


            return sessionQ; 

        }       // to be completed 

        //removes a queue based on its id number 
        public static void removeQueue(int qID, string column)
        {
            connectTo(); 

            try
            {
                command.CommandText = "DELETE FROM Queue WHERE " + column +"=" + qID;
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery(); 
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close(); 



                 
            }
        }

        //FORUM FUNCTIONALITY 
        public static void addForumCategory(string title, string description)
        {
            connectTo();
            try
            {
                command.CommandText = "INSERT INTO ForumCategories (FCategoryTitle, FCategoryDescription) VALUES('" + title + "', '" + description + "')";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                HttpContext.Current.Response.Write("<script>alert('Could not add the category')</script>");
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<Forum> getForumCategories()
        {
            connectTo();
            List<Forum> categories = new List<Forum>();
            Forum f;


            try
            {
                command.CommandText = "SELECT * FROM ForumCategories";
                command.CommandType = CommandType.Text;
                connection.Open();
                OleDbDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    f = new Forum(); 

                    f.CategoryID = Int32.Parse(read["ID"].ToString());
                    f.Title = read["FCategoryTitle"].ToString();
                    f.Text = read["FCategoryDescription"].ToString();

                    categories.Add(f);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
            return categories;
        } 

        public static void addForumNewPost(Forum f)
        {
            connectTo();
            try
            {
                command.CommandText = "INSERT INTO ForumPosts (CategoryID_FK, PostTitle, PostDate, UserID_FK) VALUES('" + f.CategoryID + "', '" + f.Title + "','"+ f.Date + "',"+ f.UserID +" )";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                HttpContext.Current.Response.Write("<script>alert('Could not add the post')</script>");
            }
            finally
            {
                connection.Close();
            }
        }

        
        public static List<Forum> getForumPosts(int categoryID)
        {
            connectTo();
            List<Forum> posts = new List<Forum>();
            Forum f;


            try
            {
                command.CommandText = "SELECT * FROM ForumPosts WHERE CategoryID_FK=" + categoryID;
                command.CommandType = CommandType.Text;
                connection.Open();
                OleDbDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    f = new Forum();

                    f.CategoryID = Int32.Parse(read["CategoryID_FK"].ToString());
                    f.PostID = Int32.Parse(read["ID"].ToString());
                    f.Title = read["PostTitle"].ToString();
                    f.Date = DateTime.Parse(read["PostDate"].ToString());
                    f.UserID = (int)read["UserID_FK"];

                    posts.Add(f);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
            return posts;
        }

        public static void addForumMessage(Forum f)
        {
            connectTo();
            try
            {
                command.CommandText = "INSERT INTO ForumMessages (CategoryID_FK, PostID_FK, UserID_FK, MessageDate, MessageContent) VALUES (" + f.CategoryID + ", " + f.PostID + "," + f.UserID + ",'" +
                                        f.Date +"','" + f.Text + "')";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                HttpContext.Current.Response.Write("<script>alert('"+ command.CommandText +"')</script>");
            }
            finally
            {
                connection.Close();
            }
        }


        public static List<Forum> getForumMessages(int postID)
        {
            List<Forum> messages = new List<Forum>();

            connectTo();
            
            Forum f;


            try
            {
                command.CommandText = "SELECT * FROM ForumMessages WHERE PostID_FK=" + postID;
                command.CommandType = CommandType.Text;
                connection.Open();
                OleDbDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    f = new Forum();

                    f.CategoryID = Int32.Parse(read["CategoryID_FK"].ToString());
                    f.MessageID = Int32.Parse(read["ID"].ToString());
                    f.Date = DateTime.Parse(read["MessageDate"].ToString());
                    f.UserID = (int)read["UserID_FK"];
                    f.Text = read["MessageContent"].ToString();

                    messages.Add(f);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
           


            return messages; 

        }



        public static void deleteForumCategory(int catID)
        {
            try
            {
                connection.Open();
                command.CommandText = "DELETE FROM ForumCategories WHERE ID=" + catID;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                command.CommandText = "DELETE FROM ForumPosts WHERE CategoryID_FK=" + catID;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                command.CommandText = "DELETE FROM ForumMessages WHERE CategoryID_FK=" + catID;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery(); 

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                connection.Close();
            }
        }


        public static int getNumberOfRecords(string column, int id)
        {

            int numberOfRecords =0;

            try
            {
                command.CommandText = "SELECT COUNT(ID) AS numberOfRecords FROM ForumMessages WHERE " + column + "=" + id;
                command.CommandType = CommandType.Text;
                connection.Open();
                numberOfRecords = (int)command.ExecuteScalar(); 
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

            return numberOfRecords; 
        }

        public static int getNumberOfRecords(string table, string column, int id)
        {

            int numberOfRecords = 0;

            try
            {
                command.CommandText = "SELECT COUNT(ID) AS numberOfRecords FROM " + table + " WHERE " + column + "=" + id;
                command.CommandType = CommandType.Text;
                connection.Open();
                numberOfRecords = (int)command.ExecuteScalar();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

            return numberOfRecords;
        }


        //Connection string and command
        private static void connectTo()
        {
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Jeremi\Google Drive\Uni\Application & Web Development\Coursework\WhiteLotus_mainCW\WhiteLotus_mainCW\databse.accdb;Persist Security Info=False");
            command = connection.CreateCommand();

            

        }
    }
}