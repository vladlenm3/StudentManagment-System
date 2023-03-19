using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_managment_system
{
    // base class for a person
    class Person
    {
        
        protected string fName, lName;
        protected int age;

        public virtual void setInfo() {
            Console.WriteLine("Enter first Name of a student: ");
            this.fName = Console.ReadLine();
            Console.WriteLine("Enter your last Name of a student: ");
            this.lName = Console.ReadLine();
            Console.WriteLine("Enter student age: ");
            age = Convert.ToInt32(Console.ReadLine());
        }
    }
    // student class 
    class Student: Person
    {
        private string sId;
        private double GPA;

        public override void setInfo()
        {
            base.setInfo();
            Console.WriteLine("Ente student id: ");
            this.sId = Console.ReadLine();
            Console.WriteLine("Enter student GPA: ");
            this.GPA = Convert.ToDouble(Console.ReadLine());

        }
        public void getInfo()
        {
            Console.WriteLine($"Student ID: {this.sId}");
            Console.WriteLine($"Student name: {this.fName} {this.lName}");
            Console.WriteLine($"Student GPA: {this.GPA}");
        }
        public void setGPA()
        {
            Console.WriteLine("Enter new GPA: ");
            this.GPA = Convert.ToDouble(Console.ReadLine());
        }
        public void changeInfo()
        {
            base.setInfo();
            this.setInfo();
        }
    }
    // class for professor
    class Professor: Person
    {
        private string username, password;
        private string checkU, checkP;
        private string pId;
        Student st = new Student();


        public override void setInfo()
        {
            base.setInfo();
            Console.WriteLine("Enter professor id: ");
            this.pId = Console.ReadLine();
        }
        public void manage()
        {
            // reads lines from a file
            string[] lines = File.ReadAllLines("login.txt");
            this.checkU = lines[0];
            this.checkP = lines[1];
            Console.WriteLine("Hello, to manage student info youneed to login.");
            Console.WriteLine("Enter Username: ");
            this.username = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            this.password = Console.ReadLine();
            // chack if the password is valid
            while (username != checkU || password != checkP)
            {
                Console.WriteLine("Username or Password is not correct! Try again! ");
                Console.WriteLine("Enter Username: ");
                this.username = Console.ReadLine();
                Console.WriteLine("Enter Password: ");
                this.password = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {this.fName} {this.lName}, you are loged in now! ");
            Console.WriteLine("Would you like to add a new student?(y/n)");
            char input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case 'y' :
                    {
                        st.setInfo();
                        break;
                    }
                case 'n':
                    Console.WriteLine("Godbye!");
                    break;
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Professor s1 = new Professor();
            s1.setInfo();
            s1.manage();
        }
    }
}
