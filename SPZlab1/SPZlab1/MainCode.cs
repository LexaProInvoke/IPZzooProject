using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
namespace SPZlab1
{
    public class Animal
    {
        private string name;
        private string type;
        private string sex;
        private string diet;
        private string status;
        private int    age;

        Animal()
        {
            name = "Null";
            type = "Null";
            sex = "Null";
            diet = "Null";
            status = "Null";
            age = 0;
        }
        Animal(string name, string type, string sex, string diet, string status, int age)
        {
            this.name = name;
            this.type = type;
            this.sex = sex;
            this.diet = diet;
            this.status = status;
            this.age = age;
        }
        string getInfo(Animal Anim)
        {

            return name+type+sex+diet+status+age.ToString();
        }
    }
    public class Cage
    {
        private int number;
        private int width;
        private int height;
        private int lenght;
        private int xCoord;
        private int yCoord;
        private string CageType;
        static private ArrayList animals = new ArrayList();

        //Cage()
        //{
        //    number = 0;
        //    width  = 0;
        //    height = 0;
        //    lenght = 0;
        //    xCoord = 0;
        //    yCoord = 0;

        //}
        public Cage(int number, int width, int height, int lenght, int xCoord, int yCoord, string CageType, ArrayList Animals)
        {
            this.number = number;
            this.width = width;
            this.height = height;
            this.lenght = lenght;
            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.CageType = CageType;
            animals = Animals;
        }
        public string GetInfo(Cage primerCage)
        {
            string result="";

            foreach (String obj in animals)
                result += obj;
            return number.ToString() + width.ToString()+height.ToString()+lenght.ToString()+xCoord.ToString()+yCoord.ToString()+CageType+ result;
        }
    }
    public class User
    {
        int id;     
        private ArrayList Task = new ArrayList();

        //private SqlCommand command;
        private SqlParameter param;
        private SqlDataReader sql_dr;
        public bool checkLogin(string login, string password, SqlConnection connect)
        {
            bool checkflag;//проверка на пароль и логин
            connect.Open();
            SqlCommand command = new SqlCommand("SELECT Password, Login FROM People where (Login) = @Login and (Password) = @Password", connect);//sql запрос на проверку логина и пароля из БД
            param = new SqlParameter//создание Sql параметра для проверки логина 
            {
                ParameterName = "@Login",
                Value = login,
                SqlDbType = SqlDbType.VarChar
            };
            command.Parameters.Add(param);//
            param = new SqlParameter//создание Sql параметра для проверки пароля 
            {
                ParameterName = "@Password",
                Value = password,
                SqlDbType = SqlDbType.VarChar
            };
            command.Parameters.Add(param);//

            sql_dr = command.ExecuteReader();

            // string checkreult = sql_dr.GetString(1) + sql_dr.GetString(0);
            if (sql_dr.FieldCount==0)
            {
                checkflag = false;
            }
            else
            {
                checkflag = true;
            }
            return checkflag;

        }

      
        public void getTask(int idWorker, SqlConnection connect, ArrayList List)
        {
            connect.Open();
            SqlCommand command = new SqlCommand("SELECT Description, DeadLine FROM Tasks where (idWorker) = @idWorker", connect);//sql запрос на чтение из БД
            param = new SqlParameter//создание Sql параметра для проверки логина 
            {
                ParameterName = "@idWorker",
                Value = idWorker,
                SqlDbType = SqlDbType.VarChar
            };
            command.Parameters.Add(param);//
            sql_dr = command.ExecuteReader();
            if (sql_dr.HasRows)//проверка на наличие даных
            {
                while (sql_dr.Read())
                {
                    List.Add(sql_dr.GetValue(0).ToString()+" "+ sql_dr.GetValue(1).ToString());
                }
                
            }
           
        }
        void getRules()
        {
        }
        void getInfoCage()
        {
        }
        void endTask()
        {
        }
        void report()
        {
        }
    }
    public class Database
    {
        SqlConnection connectVariable;//змінна підключення до бд

        private SqlDataReader sql_dr;
        public SqlConnection connect()
        {

            SqlConnection sqlConnectionFunk;//подключение к БД
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Алексей\source\repos\SPZlab1\SPZlab1\ZooDatabase.mdf; Integrated Security = True";
            sqlConnectionFunk = new SqlConnection(connectionString);
            try
            {
               // sqlConnectionFunk.Open();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Connection error:{0}", se.Message);
                
            }
            return sqlConnectionFunk;

        }
        public void outputPeopleDB(ArrayList PeopleList, SqlConnection connect )
        {
         
            
            connect.Open();
            SqlCommand command = new SqlCommand("SELECT Id, Password, Login, FIO, Position, isAdmin FROM People", connect);//sql запрос на чтение из БД
            sql_dr = command.ExecuteReader();
            if (sql_dr.HasRows)//проверка на наличие даных
            {
                while (sql_dr.Read())
                {
                    PeopleList.Add(sql_dr.GetValue(0).ToString() + sql_dr.GetValue(1).ToString() + sql_dr.GetValue(2).ToString() + sql_dr.GetValue(3).ToString() + sql_dr.GetValue(4).ToString() + sql_dr.GetValue(5).ToString());
                }
            }
        }
        public void outputCageDB(ArrayList PeopleList, SqlConnection connect)
        {
            
          
            connect.Open();
            SqlCommand command = new SqlCommand("SELECT Id, type, koordX, koordY FROM Cage", connect);//sql запрос на чтение из БД
            sql_dr = command.ExecuteReader();
            if (sql_dr.HasRows)//проверка на наличие даных
            {
                while (sql_dr.Read())
                {
                    PeopleList.Add(sql_dr.GetValue(0).ToString() +"  "+ sql_dr.GetValue(1).ToString() + sql_dr.GetValue(2).ToString() + "   " + sql_dr.GetValue(3).ToString());
                }
            }
        }

        public void outputAnimalsDB(ArrayList PeopleList, SqlConnection connect)
        {


            connect.Open();
            SqlCommand command = new SqlCommand("SELECT Id, name, type, cage FROM Animals", connect);//sql запрос на чтение из БД
            sql_dr = command.ExecuteReader();
            if (sql_dr.HasRows)//проверка на наличие даных
            {
                while (sql_dr.Read())
                {
                    PeopleList.Add(sql_dr.GetValue(0).ToString() + "  " + sql_dr.GetValue(1).ToString() + sql_dr.GetValue(2).ToString() + "   " + sql_dr.GetValue(3).ToString());
                }
            }
        }

        public void outputTasksDB(ArrayList PeopleList, SqlConnection connect)
        {


            connect.Open();
            SqlCommand command = new SqlCommand("SELECT Id, IdWorker, Description, DeadLine FROM Tasks", connect);//sql запрос на чтение из БД
            sql_dr = command.ExecuteReader();
            if (sql_dr.HasRows)//проверка на наличие даных
            {
                
                while (sql_dr.Read())
                {
                    PeopleList.Add(sql_dr.GetValue(0).ToString() + "  " + sql_dr.GetValue(1).ToString() + "  " + sql_dr.GetValue(2).ToString() + "   " + sql_dr.GetValue(3).ToString());
                }
            }
        }

        public void outputZoonDB(ArrayList PeopleList, SqlConnection connect)
        {


            connect.Open();
            SqlCommand command = new SqlCommand("SELECT Id, x1Coord, y1Coord, x2Coord, y2Coord, x3Coord, y3Coord, x4Coord, y4Coord, Type, Color FROM Zone", connect);//sql запрос на чтение из БД
            sql_dr = command.ExecuteReader();
            if (sql_dr.HasRows)//проверка на наличие даных
            {
                while (sql_dr.Read())
                {
                    PeopleList.Add(sql_dr.GetValue(0).ToString() + "  " + sql_dr.GetValue(1).ToString() + "  " + sql_dr.GetValue(2).ToString() + "   " + sql_dr.GetValue(3).ToString() + " " + sql_dr.GetValue(4).ToString() + " " + sql_dr.GetValue(5).ToString() + " " + sql_dr.GetValue(6).ToString() + " " + sql_dr.GetValue(7).ToString() + " " + sql_dr.GetValue(8).ToString() + " " + sql_dr.GetValue(9).ToString() +" "+ sql_dr.GetValue(10).ToString());
                }
            }
        }
        public void Disconnect(SqlConnection connectVariable)
        {
            if (connectVariable != null && connectVariable.State != ConnectionState.Closed)
                connectVariable.Close();
        }

        void Query()//Запрос
        { 
        }
        void Request()//Запрос
        { 
        }

    }
    public class mapConteiner
    {
        private ArrayList cageList = new ArrayList();
        private ArrayList taskList = new ArrayList();
        private ArrayList zoneList = new ArrayList();
    }
    public class MapController
    {
        void addCage()
        { 
        }

        void addZone()
        { 
        }

        void addTask()
        { 
        }

        void deleteCage()
        { 
        }

        void deleteZone()
        { 
        }
        void deleteTask()
        { 
        }

        void setPosition()
        { 
        }


    }
    public class adminTools
    {
        
        private MapController con;

        SqlCommand comand;
        SqlParameter param;


        

        public void addCage(string type, string koordX, string koordY, SqlConnection sqlConnect)///
        {
            try
            {
                sqlConnect.Open();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Connection error:{0}", se.Message);
                return;
            }
            comand = new SqlCommand("Insert into Cage (type, koordX, koordY) Values (@1, @2, @3)", sqlConnect);
            param = new SqlParameter
            {
                ParameterName = "@1",
                Value = type,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@2",
                Value = koordX,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@3",
                Value = koordY,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);

           
           
            try
            {
                comand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Inserting error");
                return;
            }
        }
        public void editCage(int id, string newType, string newKoordX, string newKoordY, SqlConnection sqlConnect)
        {
            sqlConnect.Open();

            comand = new SqlCommand("Update Cage Set type = @newType, koordX = @newKoordX, koordY = @newKoordY  where Id = @ID", sqlConnect);
            param = new SqlParameter
            {
                ParameterName = "@ID",
                Value = id,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newType",
                Value = newType,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newKoordX",
                Value = newKoordX,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newKoordY",
                Value = newKoordY,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            comand.ExecuteNonQuery();
            try
            {
                comand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Inserting error");
                return;
            }
        }
        public void deleteCage(int id, SqlConnection sqlConnect)
        {

            sqlConnect.Open();
            SqlCommand command = new SqlCommand("Delete from [Cage] where (id) = @id", sqlConnect);

            param = new SqlParameter
            {
                ParameterName = "@id",
                Value = id,
                SqlDbType = SqlDbType.VarChar
            };
            command.Parameters.Add(param);
            command.ExecuteNonQuery();
        }

        public void editAnimal(int id, string newName, string newType, string newCage, SqlConnection sqlConnect)
        {
            sqlConnect.Open();

            comand = new SqlCommand("Update Animals Set name = @newName, type = @newType, cage = @newCage  where id = @ID", sqlConnect);
            param = new SqlParameter
            {
                ParameterName = "@ID",
                Value = id,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newName",
                Value = newName,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newType",
                Value = newType,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newCage",
                Value = newCage,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            comand.ExecuteNonQuery();
            try
            {
                comand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Inserting error");
                return;
            }
        }

       

        public void addAnimals(string name, string type, string cage, SqlConnection sqlConnect)
        {
            

            

            try
            {
                sqlConnect.Open();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Connection error:{0}", se.Message);
                return;
            }
            comand = new SqlCommand("Insert into Animals (name, type, cage) Values (@1, @2, @3)", sqlConnect);
            param = new SqlParameter
            {
                ParameterName = "@1",
                Value = name,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@2",
                Value = type,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@3",
                Value = cage,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);


            
            try
            {
                comand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Inserting error");
                return;
            }
        }
        public void deleteAnimal(int id, SqlConnection sqlConnect)
        {
            sqlConnect.Open();
            SqlCommand command = new SqlCommand("Delete from [Animals] where (id) = @id", sqlConnect);

            param = new SqlParameter
            {
                ParameterName = "@id",
                Value = id,
                SqlDbType = SqlDbType.VarChar
            };
            command.Parameters.Add(param);
            command.ExecuteNonQuery();
        }

        public void addUser(string login, string password, string FIO, string Position, int adminFlag, SqlConnection connect)
        {
            connect.Open();

            comand = new SqlCommand("Insert into People (Login, Password, FIO, Position, isAdmin) Values (@1, @2, @3, @4, @5)", connect);
            param = new SqlParameter
            {
                ParameterName = "@1",
                Value = login,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@2",
                Value = password,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@3",
                Value = FIO,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@4",
                Value = Position,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@5",
                Value = adminFlag,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            try
            {
                comand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Inserting error");
                return;
            }

        }

        public void deleteUser(int id, SqlConnection sqlConnect)
        {

            sqlConnect.Open();
            SqlCommand command = new SqlCommand("Delete from [People] where (id) = @id", sqlConnect);

            param = new SqlParameter
            {
                ParameterName = "@id",
                Value = id,
                SqlDbType = SqlDbType.VarChar
            };
            command.Parameters.Add(param);
            command.ExecuteNonQuery();
        }

        public void editUser(int id, string newLogin, string newPassword, string newFIO,string newPosition, int newisAdmin, SqlConnection sqlConnect)
        {
            sqlConnect.Open();

            comand = new SqlCommand("Update People Set login = @newLogin, password = @newPassword, FIO = @newFIO, Position = @newPosition, isAdmin = @newisAdmin  where Id = @ID", sqlConnect);
            param = new SqlParameter
            {
                ParameterName = "@ID",
                Value = id,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newLogin",
                Value = newLogin,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newPassword",
                Value = newPassword,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newFIO",
                Value = newFIO,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newPosition",
                Value = newPosition,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newisAdmin",
                Value = newisAdmin,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            
            try
            {
                comand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Inserting error");
                return;
            }
        }
        void addAdmin()
        {
        }
        void deleteAdmin()
        {
        }
        
    }

    public class Zone
    {
        int x1Coord;
        int y1Coord;
        int x2Coord;
        int y2Coord;
        int x3Coord;
        int y3Coord;
        int x4Coord;
        int y4Coord;
        string Type;
        string Color;


        Zone()
        {
            x1Coord = 0;
            y1Coord = 0;
            x2Coord = 0;
            y2Coord = 0;
            x3Coord = 0;
            y3Coord = 0;
            x4Coord = 0;
            y4Coord = 0;
             Type = "null";
             Color= "null";


        }

    }

    public class ZoneController
    {
        SqlCommand comand;
        SqlParameter param;
       
        public void addZone(int x1Coord,  int y1Coord, int x2Coord, int y2Coord, int x3Coord, int y3Coord, int x4Coord, int y4Coord, string Type, string Color, SqlConnection sqlConnect)
        {
           
            try
            {
                sqlConnect.Open();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Connection error:{0}", se.Message);
                return;
            }
            comand = new SqlCommand("Insert into Zone (Type, Color, x1Coord, y1Coord, x2Coord, y2Coord, x3Coord, y3Coord, x4Coord, y4Coord ) Values (@Type, @Color, @x1Coord, @y1Coord, @x2Coord, @y2Coord, @x3Coord, @y3Coord, @x4Coord, @y4Coord)", sqlConnect);
            param = new SqlParameter
            {
                ParameterName = "@Type",
                Value = Type,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@Color",
                Value = Color,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@x1Coord",
                Value = x1Coord,
                SqlDbType = SqlDbType.Int
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@y1Coord",
                Value = y1Coord,
                SqlDbType = SqlDbType.Int
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@x2Coord",
                Value = x2Coord,
                SqlDbType = SqlDbType.Int
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@y2Coord",
                Value = y2Coord,
                SqlDbType = SqlDbType.Int
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@x3Coord",
                Value = x3Coord,
                SqlDbType = SqlDbType.Int
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@y3Coord",
                Value = y3Coord,
                SqlDbType = SqlDbType.Int
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@x4Coord",
                Value = x4Coord,
                SqlDbType = SqlDbType.Int
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@y4Coord",
                Value = y4Coord,
                SqlDbType = SqlDbType.Int
            };
            comand.Parameters.Add(param);
            try
            {
                comand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Inserting error");
                return;
            }

            
        }

       public void DeleteZone(int id, SqlConnection sqlConnect)
        {

            sqlConnect.Open();
            SqlCommand command = new SqlCommand("Delete from [Zone] where (id) = @id", sqlConnect);
           
            param = new SqlParameter
            {
                ParameterName = "@id",
                Value = id,
                SqlDbType = SqlDbType.VarChar
            };
            command.Parameters.Add(param);
            command.ExecuteNonQuery();
        }

        public void EditZone(int id, int x1Coord, int y1Coord, int x2Coord, int y2Coord, int x3Coord, int y3Coord, int x4Coord, int y4Coord,string Type, string Color, SqlConnection sqlConnect)
        {
            sqlConnect.Open();

            comand = new SqlCommand("Update Zone Set x1Coord = @newX1Coord, y1Coord=@newY1Coord, x2Coord = @newX2Coord, y2Coord=@newY2Coord, x3Coord = @newX3Coord, y3Coord=@newY3Coord, x4Coord = @newX4Coord, y4Coord=@newY4Coord, Type = @newType, Color = @newColor where Id = @ID", sqlConnect);
            param = new SqlParameter
            {
                ParameterName = "@ID",
                Value = id,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newX1Coord",
                Value = x1Coord,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newY1Coord",
                Value = y1Coord,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newX2Coord",
                Value = x2Coord,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newY2Coord",
                Value = y2Coord,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newX3Coord",
                Value = x3Coord,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newY3Coord",
                Value = y3Coord,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newX4Coord",
                Value = x4Coord,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newY4Coord",
                Value = y4Coord,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newType",
                Value = Type,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@newColor",
                Value = Color,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            comand.ExecuteNonQuery();
            try
            {
                comand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Inserting error");
                return;
            }
        }

        

    }

    public class TaskController
    {
        SqlParameter param;
        SqlCommand comand;
        public void addTask(int idWorker, string Description, string DeadLine , SqlConnection sqlConnect)
        {
            

            try
            {
                sqlConnect.Open();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Connection error:{0}", se.Message);
                return;
            }
            comand = new SqlCommand("Insert into Tasks (IdWorker, Description, DeadLine) Values (@1, @2, @3)", sqlConnect);
            param = new SqlParameter
            {
                ParameterName = "@1",
                Value = idWorker,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@2",
                Value = Description,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);

            param = new SqlParameter
            {
                ParameterName = "@3",
                Value = DeadLine,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);



            try
            {
                comand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Inserting error");
                return;
            }
        }


        public void deleteTask(int id, SqlConnection sqlConnect)
        {
            sqlConnect.Open();
            SqlCommand command = new SqlCommand("Delete from [Tasks] where (id) = @id", sqlConnect);

            param = new SqlParameter
            {
                ParameterName = "@id",
                Value = id,
                SqlDbType = SqlDbType.VarChar
            };
            command.Parameters.Add(param);
            command.ExecuteNonQuery();
        }
       

        public void editTask(int id, int idWorker, string Description,string DeadLine, SqlConnection sqlConnect)
        {
            sqlConnect.Open();

            comand = new SqlCommand("Update Tasks Set idWorker = @idWorker, Description = @Description, DeadLine = @DeadLine where Id = @ID", sqlConnect);
            param = new SqlParameter
            {
                ParameterName = "@ID",
                Value = id,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@idWorker",
                Value = idWorker,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@Description",
                Value = Description,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            param = new SqlParameter
            {
                ParameterName = "@DeadLine",
                Value = DeadLine,
                SqlDbType = SqlDbType.VarChar
            };
            comand.Parameters.Add(param);
            
           
            try
            {
                comand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Inserting error");
                return;
            }
        }

        void setDeadLine()
        { 
        }
        void removeTask()
        {
        }
    }

    public class RulesController
    {
        void editWorkerRule()
        { 
        }

        void editZooRules()
        { 
        }

        void editSafertyEngineering()
        { 
        }

    }

    public class Task
    {
        string description;
        string deadLine;

        Task()
        {
            description = "null";
            deadLine = "null";
        }
    }
}