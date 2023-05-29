using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital._3
{
    class PatientList
    {
        public ArrayList objPatientName = new ArrayList();
        public void AcceptDetails()
        {
            char choice = 'Y';
            try
            {
                do
                {
                    Console.Write("Enter patien's name :");
                    objPatientName.Add(Console.ReadLine());
                    Console.Write("Do you want to add more name? [Y/N} : ");
                    choice = Convert.ToChar(Console.ReadLine());
                } while (choice == 'Y' || choice == 'y');
            }
            catch (Exception objEx)
            {
                Console.WriteLine("Error : {0}", objEx.Message);
            }
        }
        public void DisplayDetails()
        {
            Console.WriteLine("\nList of patients : ");
            for (int i = 0; i < objPatientName.Count; i++)
            {
                Console.WriteLine(objPatientName[i]);
            }
            Console.WriteLine("Total number of patients : " + objPatientName.Count);
        }
        public bool Remove()
        {
            string choice;
            Console.Write("Enter the name of the patient : ");
            choice = Console.ReadLine();
            if (objPatientName.Contains(choice))
            {
                objPatientName.Remove(choice);
                return true;
            }
            else
                return false;
        }
        public void Search()
        {
            string choice;
            Console.Write("Enter the name of the patient : ");
            choice = Console.ReadLine();
            if (choice != "")
            {
                if (objPatientName.Contains(choice))
                {
                    Console.WriteLine("Record Found!");
                    Console.WriteLine(objPatientName[objPatientName.IndexOf(choice)]);
                }
                else
                    Console.WriteLine("Record Not Found!");
            }
            else { Console.WriteLine("Invalid Input!"); }
        }
    }
    class PatientListTest
    {

        internal class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    PatientList objPatientList = new PatientList();

                    objPatientList.AcceptDetails();
                    objPatientList.DisplayDetails();
                    char input = 'Y';
                    do
                    {
                        int choice;
                        Console.WriteLine("\nSelect one of the following options:");
                        Console.WriteLine(" 1. Sort\n 2. Remove\n 3.Reverse\n 4.Seac\n 5.Exit");
                        Console.Write("Enter your choice : ");
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                objPatientList.objPatientName.Sort();
                                Console.Write("\n-----After Sorting-----");
                                objPatientList.DisplayDetails();
                                break;
                            case 2:
                                if (objPatientList.Remove())
                                {
                                    Console.Write("\n-----After Removing-----");
                                    objPatientList.DisplayDetails();
                                }
                                else
                                    Console.WriteLine("Patient with this name dose not exist");
                                break;
                            case 3:
                                objPatientList.objPatientName.Reverse();
                                Console.Write("\n-----After Reversing-----");
                                objPatientList.DisplayDetails();
                                break;
                            case 4:
                                objPatientList.Search();
                                break;
                            case 5:
                                return;
                            default:
                                Console.WriteLine("Invalid Data Entry!");
                                break;
                        }
                    } while (input == 'Y' || input == 'y');
                }
                catch(Exception objEx) 
                {
                    Console.WriteLine("Error : {0}", objEx.Message);
                }
            }
        }
    }
}
