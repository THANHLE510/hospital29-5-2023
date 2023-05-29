using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital._2
{
   class DoctorTable
    {
        public Hashtable objDoctorDetails= new Hashtable();
        public void AcceptDetails()
        {
            string name;
            String address;
            char choice = 'Y';
            try
            {
                do
                {
                    Console.Write("Enter the doctor`s name : ");
                    name = Console.ReadLine();
                    Console.Write("Enter the address : ");
                    address = Console.ReadLine();
                    objDoctorDetails.Add(name, address);
                    Console.Write("Do you want to add more records? [Y/N] ");
                    choice = Convert.ToChar(Console.ReadLine());
                } while (choice == 'Y' || choice == 'y');
            }
            catch   (Exception objEx )
            {
                Console.WriteLine("Error : {0}", objEx.Message);
            }
        }
        public void DisplayDetail() 
        {
            ICollection objCollection = objDoctorDetails.Keys;

            Console.WriteLine("\nDetails of doctors :");
            Console.WriteLine("Doctor's Name \t Address");
            Console.WriteLine("--------------\t -------");
             
            foreach(string details in objCollection) 
            {
                Console.WriteLine(details + "\t\t" + objDoctorDetails[details]);
            }
            Console.WriteLine("Total number of doctors : " + objDoctorDetails.Count);
        }
        public bool Remove()
        {
            string choice;
            Console.Write("Enter the name of the doctor : ");
            choice = Console.ReadLine();
            if(objDoctorDetails.ContainsKey(choice)) 
            {
                objDoctorDetails.Remove(choice);
                return true;
            }
            else return false;
        }
        public void Search()
        {
            string choice;
            Console.Write("Enter the name of doctor : ");
            choice = Console.ReadLine();    
            if (choice != "")
            {
                if (objDoctorDetails.ContainsKey(choice))
                {
                    Console.WriteLine("Record Found!");
                    Console.WriteLine("Doctor's Name : {0}", choice);
                    Console.WriteLine("Address : {0}", objDoctorDetails[choice]);
                }
                else
                    Console.WriteLine("Record Not Found!");
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DoctorTable objDoctorsTable = new DoctorTable();

                objDoctorsTable.AcceptDetails();

                objDoctorsTable.DisplayDetail();

                char input = 'Y';
                do
                {
                    int choice;
                    Console.WriteLine("\nSelect one of the following options :");
                    Console.WriteLine(" 1.Remove\n 2.Remove All\n 3.Search\n 4.Exits");
                    Console.Write("Enter your choice : ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            if (objDoctorsTable.Remove())
                            {
                                Console.WriteLine("\n-----After Removing-----");
                                objDoctorsTable.DisplayDetail();
                            }
                            else Console.WriteLine("Doctor with this name does not exist");
                            break;
                        case 2:
                            objDoctorsTable.objDoctorDetails.Clear();
                            Console.WriteLine("\n------After removing all the doctors------");
                            Console.WriteLine("Total number of doctors : " + objDoctorsTable.objDoctorDetails.Count);
                            return;
                        case 3:
                            objDoctorsTable.Search();
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("Invalid Data Entry!");
                            break;
                    }
                } while (input == 'Y' || input == 'y');
            }
            catch (Exception objEx)
            {
                Console.WriteLine("Error : {0}", objEx.Message);
            }
        }
    }
}
