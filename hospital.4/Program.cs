using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital._4
{
    class Suppliers
    {
        public Dictionary<int, string> objSupplierDetails = new Dictionary<int, string>();

        public void AcceptDetails()
        {
            int id;
            string name;
            char choice = 'Y';

            try
            {
                do
                {
                    Console.Write("Enter the supplier ID : ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the name : ");
                    name = Console.ReadLine();
                    objSupplierDetails.Add(id, name);
                    Console.Write("Do you want to add more records? [Y/N} : ");
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
            ICollection objCollection = objSupplierDetails.Keys;

            Console.WriteLine("Details of Suppliers : ");
            Console.WriteLine("Supplier ID \t Name");
            foreach (int details in objCollection)
            {
                Console.WriteLine(details + "\t\t" + objSupplierDetails[details]);
            }
            Console.WriteLine("Total number if suppliers : " + objSupplierDetails.Count);
        }
        public bool Modify()
        {
            int id;
            string name;
            Console.Write("Enter the supplier ID to change the name : ");
            id = Convert.ToInt32(Console.ReadLine());
            if (id == 0 && objSupplierDetails.ContainsKey(id))
            {
                Console.Write("Enter new name of the supplier : ");
                name = Console.ReadLine();

                objSupplierDetails[id] = name;
                return true;

            }
            else
                return false;
        }
        public bool Remove()
        {
            int input;
            Console.Write("Enter the supplier ID : ");
            input = Convert.ToInt32(Console.ReadLine());
            if (input > 0 && objSupplierDetails.ContainsKey(input))
            {
                objSupplierDetails.Remove(input);
                return true;
            }
            else
                return false;
        }
        public void Seach()
        {
            int choice;
            Console.Write("Enter the supplier ID : ");
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice > 0)
            {
                if (objSupplierDetails.ContainsKey(choice))
                {
                    Console.WriteLine("Record Found!");
                    Console.WriteLine("Supplier ID : {0}", choice);
                    Console.WriteLine("Name : {0}", objSupplierDetails[choice]);
                }
                else
                    Console.WriteLine("Record Nor Found!");
            }
            else { Console.WriteLine("Invalid Input!"); }
        }

    }
    class SuppliersTest
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Suppliers objSuppliers = new Suppliers();
                    objSuppliers.AcceptDetails();
                    objSuppliers.DisplayDetails();
                    char input = 'Y';
                    do
                    {
                        int choice;
                        Console.WriteLine("\nSelect one of the following options:");
                        Console.WriteLine(" 1.Modify\n 2.Remove\n 3.Remove All\n 4. Search\n 5.Exit");
                        Console.Write("Enter your choice : ");
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                if (objSuppliers.Modify())
                                {
                                    Console.WriteLine("\n-----After Modiflying-----");
                                    objSuppliers.DisplayDetails();
                                }
                                else
                                    Console.WriteLine("Supplier with this name does not exist");
                                break;
                            case 2:
                                if (objSuppliers.Remove())
                                {
                                    Console.WriteLine("\n-----After Removing-----");
                                    objSuppliers.DisplayDetails();
                                }
                                else
                                    Console.WriteLine("Supplier with this name does not exist");
                                break;
                            case 3:
                                objSuppliers.objSupplierDetails.Clear();
                                Console.WriteLine("\n-----After removing all the supplier-----");
                                Console.WriteLine("Total number of suppliers :" + objSuppliers.objSupplierDetails.Count);
                                return;
                            case 4:
                                objSuppliers.Seach();
                                break;
                            case 5:
                                return;

                            default:
                                Console.WriteLine("Invalid Data Entry!");
                                break;
                        }
                    } while (input == 'Y' || input == 'y');

                }
                catch(Exception objEx) { Console.WriteLine("Error : {0}", objEx.Message); }
            }
        }
    }
}
