using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
namespace SPZlab1
{
    class Test
    {
        
      
        
        public void testing()
        {   string login = "andrey";
            string password= "andrey";
            string Newlogin;
            string Newpassword;
            string NewFIO;
            string NewPosition;
            int AdminFlag = 1;
            ArrayList list = new ArrayList();
            User adad = new User();
             Database newData = new Database();
            adminTools newUser = new adminTools();
            ZoneController newzone = new ZoneController();
            TaskController tscontrol = new TaskController();
            bool result;//переменная для проверки результатов проверки login and password
            SqlConnection sqlConnectionMain = newData.connect();//вызов функции получения соединения
           
            newData.Disconnect(sqlConnectionMain);//отключение от бд

            Console.WriteLine("login: ");
            Newlogin = Console.ReadLine();
            Console.WriteLine("password: ");
            Newpassword = Console.ReadLine();
            Console.WriteLine("FIO");
            NewFIO = Console.ReadLine();
            Console.WriteLine("Position");
            NewPosition = Console.ReadLine();
            newUser.addUser(Newlogin, Newpassword, NewFIO, NewPosition, AdminFlag, sqlConnectionMain);
            Console.WriteLine("User created");



            newData.Disconnect(sqlConnectionMain);
            Console.WriteLine("Enter login and password \n");
            Console.WriteLine("login: ");
            Newlogin = Console.ReadLine();
            Console.WriteLine("password: ");
            Newpassword = Console.ReadLine();

            result = adad.checkLogin(login, password, sqlConnectionMain);//вывод результата проверки
            Console.WriteLine("результат проверки"+ result.ToString());
            




            //newData.Disconnect(sqlConnectionMain);
            //newzone.addZone();//Добавить зону в БД
            //newData.Disconnect(sqlConnectionMain);
            //newUser.addAnimals();//добавить животное в БД
            //newData.Disconnect(sqlConnectionMain);
            //newUser.addCage();//добавить клетку в БД
            //newData.Disconnect(sqlConnectionMain);
            // tscontrol.addTask(1,"clear cage", "18may", sqlConnectionMain);//добавить задание в БД
            newData.Disconnect(sqlConnectionMain);
            Console.WriteLine("список пользователей ");
            newData.outputPeopleDB(list, sqlConnectionMain);//вывод в консоль бд People
            newData.Disconnect(sqlConnectionMain);
            foreach (object o in list)
            {
                Console.WriteLine(o);
            }
            newData.Disconnect(sqlConnectionMain);

            Console.WriteLine("введите айди пользователя для удаения ");
            Newlogin = Console.ReadLine();
            Convert.ToInt32(Newlogin);
            newUser.deleteUser(Convert.ToInt32(Newlogin), sqlConnectionMain);
            Console.WriteLine("пользовател удален ");
            newData.Disconnect(sqlConnectionMain);



            //  newData.outputCageDB(list, sqlConnectionMain);//вывод в консоль бд Cage

            newData.Disconnect(sqlConnectionMain);
            // newData.outputAnimalsDB(list, sqlConnectionMain);//вывод в консоль бд Animals

            newData.Disconnect(sqlConnectionMain);
            // newData.outputTasksDB(list, sqlConnectionMain);//вывод в консоль бд Tasks

            newData.Disconnect(sqlConnectionMain);
            // newData.outputZoonDB(list, sqlConnectionMain);//вывод в консоль бд Zoon

          

            //newzone.DeleteZone(5, sqlConnectionMain);//удаление строки из БД Zone
            newData.Disconnect(sqlConnectionMain);

            //newUser.deleteAnimal(9,sqlConnectionMain);
            newData.Disconnect(sqlConnectionMain);
              //newUser.addUser(Newlogin, Newpassword, NewFIO, NewPosition, AdminFlag, sqlConnectionMain);//Добавить пользователя в БД
            newData.Disconnect(sqlConnectionMain);
            //tscontrol.deleteTask(9, sqlConnectionMain);
            newData.Disconnect(sqlConnectionMain);
            
            newData.Disconnect(sqlConnectionMain);
            //newUser.editAnimal(10, "zebra", "da", "24", sqlConnectionMain);
            newData.Disconnect(sqlConnectionMain);
           // newUser.deleteCage(9, sqlConnectionMain);
            newData.Disconnect(sqlConnectionMain);
            //newUser.editCage(10, "клітка", "123", "222", sqlConnectionMain);
            newData.Disconnect(sqlConnectionMain);

            //newUser.editUser(43,"admin1","admin","admin","admin",1, sqlConnectionMain);
            newData.Disconnect(sqlConnectionMain);

           // newzone.EditZone(6,10,10,10,10,10,10,10,10,"primatov","red",sqlConnectionMain);
          //  newData.Disconnect(sqlConnectionMain);

           // tscontrol.editTask(10,3,"wq","sad", sqlConnectionMain);
            newData.Disconnect(sqlConnectionMain);

            ArrayList lehas = new ArrayList();
           // lehas.Add("qwerty");
            //lehas.Add("admin");
            Cage lehak = new Cage(1, 1, 1, 1, 1, 1, "1", lehas);

           // adad.getTask(3, sqlConnectionMain, lehas);
           // foreach(string obj in lehas)
           //     Console.WriteLine(obj);

            //  Console.WriteLine(result);
            // Console.WriteLine(lehak.GetInfo(lehak));

            Console.ReadKey();





        }
    }

}
