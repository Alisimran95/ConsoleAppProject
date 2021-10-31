using System;
using System.Collections.Generic;
using PharmacyProject.Models;
using PharmacyProject.Utils;

namespace PharmacyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pharmacy> pharmacies = new List<Pharmacy>();

            while (true)
            {
            beginning:
                Easy.Print("1 - Create Pharmacy , 2 - Add drug to Pharmacy , 3 - Information of Drug , 4 - Show drug items in Pharmacy , 5 - SaleDrug ,6 - Exit", ConsoleColor.Yellow);

                string result = Console.ReadLine();
                bool isInt = int.TryParse(result, out int menu);
                if (isInt && (menu >= 1 && menu <= 6))
                {
                    if (menu == 6)
                        break;
                    switch (menu)
                    {
                        case 1:
                            Easy.Print("Create pharmacy and enter title: ", ConsoleColor.Yellow);
                            string PharmacyName = Console.ReadLine();

                            if (pharmacies.Count > 0 && pharmacies.Exists(x => x.Name.Trim().ToLower() == PharmacyName.Trim().ToLower()))
                            {
                                Easy.Print($"{PharmacyName} pharmacy is already created , create new pharmacy name", ConsoleColor.Red);
                                goto beginning;
                            }
                            else
                            {
                                Pharmacy pharmacy = new Pharmacy(PharmacyName);
                                pharmacies.Add(pharmacy);
                                Easy.Print($"{PharmacyName} pharmacy is created", ConsoleColor.Green);
                            }
                            break;

                        case 2:
                            if (pharmacies.Count == 0)
                            {
                                Easy.Print("There are't pharmacies in here ,now", ConsoleColor.Red);
                                goto case 1;
                            }

                        inputDrugType:
                            Easy.Print("Enter  drugtype and add to pharmacy : ", ConsoleColor.Yellow);
                            string drugType = Console.ReadLine();
                            isInt = int.TryParse(drugType,out int drugtype);
                            if (isInt)
                            {
                                Easy.Print("Enter drugtype's name with string",ConsoleColor.Red);
                                goto inputDrugType;
                            }
                            DrugType drugTypeForConstructor = new DrugType(drugType);

                        inputDrugName:
                            Easy.Print("Enter name of drug: ", ConsoleColor.Yellow);
                            string drugName = Console.ReadLine();
                            isInt = int.TryParse(drugName, out int drugname);
                            if (isInt)
                            {
                                Easy.Print("Enter correct Drugname",ConsoleColor.Red);
                                goto inputDrugName;
                            }
                            Easy.Print("Enter price of drug: ", ConsoleColor.Yellow);

                        inputDrugPrice:
                            string drugPrice = Console.ReadLine();
                            bool isDouble = Double.TryParse(drugPrice, out double Price);
                            if (!isDouble)
                            {
                                Easy.Print("enter correctly price of drug", ConsoleColor.Red);
                                goto inputDrugPrice;
                            }

                        inputDrugCount:
                            Easy.Print("Enter count of drug: ", ConsoleColor.Yellow);
                            string drugCount = Console.ReadLine();
                            isInt = int.TryParse(drugCount, out int Count);
                            if (!isInt)
                            {
                                Easy.Print("enter correctly count of drug", ConsoleColor.Red);
                                goto inputDrugCount;
                            }

                        inputPharmacyName:
                            Easy.Print("Pharmacies' list", ConsoleColor.Green);
                            foreach (var item in pharmacies)
                            {
                                Easy.Print(item.ToString(), ConsoleColor.Green);
                            }
                            Easy.Print("Please to confirm Pharmacy's name", ConsoleColor.Green);
                            PharmacyName = Console.ReadLine();
                            Pharmacy existPharmacy = pharmacies.Find(x => x.Name.Trim().ToLower() == PharmacyName.Trim().ToLower());
                            if (existPharmacy == null)
                            {
                                Easy.Print("Select created pharmacies", ConsoleColor.Red);
                                goto inputPharmacyName;
                            }
                            Drug drug = new Drug(drugName, Price, Count, drugTypeForConstructor);

                            if (!existPharmacy.AddDrug(drug))
                            {
                                Easy.Print("This drug already created", ConsoleColor.Red);
                                goto inputPharmacyName;
                            }
                            if (!existPharmacy.AddType(drugTypeForConstructor))
                            {
                                Easy.Print("This drugType already created", ConsoleColor.Red);
                            }

                            Easy.Print($"{drug}  added to {existPharmacy} Pharmacy", ConsoleColor.Green);
                            break;

                        case 3:
                            if (pharmacies.Count == 0)
                            {
                                Easy.Print("you didn't add pharmacy yet", ConsoleColor.Red);
                                goto beginning;
                            }

                            Easy.Print("Pharmacies", ConsoleColor.Yellow);
                            foreach (var item in pharmacies)
                            {
                                Easy.Print(item.ToString(), ConsoleColor.Green);
                            }

                            Easy.Print("enter pharmacy name", ConsoleColor.Green);
                            PharmacyName = Console.ReadLine();
                            existPharmacy = pharmacies.Find(x => x.Name.ToLower() == PharmacyName.ToLower());
                            if (existPharmacy == null)
                            {
                                Easy.Print("the drug is not created pharmacy", ConsoleColor.Red);
                                goto beginning;
                            }

                            Easy.Print("Enter drug's name : ", ConsoleColor.Green);
                            string nameOfDrug = Console.ReadLine();
                            existPharmacy.InfoDrug(nameOfDrug);
                            break;

                        case 4:
                            if (pharmacies.Count == 0)
                            {
                                Easy.Print("There are't pharmacies in here ,now", ConsoleColor.Red);
                                goto case 1;
                            }
                        pharmaciesList:
                            Easy.Print("Pharmacies' list", ConsoleColor.Green);
                            foreach (var item in pharmacies)
                            {
                                Easy.Print(item.ToString(), ConsoleColor.Green);
                            }
                            Easy.Print("Enter Pharmacy name: ", ConsoleColor.Green);
                            PharmacyName = Console.ReadLine();
                            Pharmacy existPharmacy2 = pharmacies.Find(x => x.Name.Trim().ToLower() == PharmacyName.Trim().ToLower());
                            if (existPharmacy2 == null)
                            {
                                Easy.Print("Select created pharmacies", ConsoleColor.Red);
                                goto pharmaciesList;
                            }
                            existPharmacy2.ShowDrugItems();
                            break;

                        case 5:
                            if (pharmacies.Count == 0)
                            {
                                Easy.Print("There are't pharmacies in here ,now", ConsoleColor.Red);
                                goto case 1;
                            }
                            Easy.Print("Choose the pharmacy you want to buy , Pharmacies is below :  ", ConsoleColor.Yellow);
                            foreach (var item in pharmacies)
                            {
                                Easy.Print(item.ToString(), ConsoleColor.Green);
                            }

                            Easy.Print("enter pharmacy name: ", ConsoleColor.Green);
                            PharmacyName = Console.ReadLine();
                            existPharmacy = pharmacies.Find(x => x.Name.ToLower() == PharmacyName.ToLower());

                            if (existPharmacy == null)
                            {
                                Easy.Print("the drug is not created pharmacy", ConsoleColor.Red);
                                goto case 2;
                            }
                        inputDrugType2:
                            Easy.Print("Enter wanted drugtype : ", ConsoleColor.Green);
                            string drugType2 = Console.ReadLine();
                            isInt = int.TryParse(drugType2, out int drugtype2);
                            if (isInt)
                            {
                                Easy.Print("Enter drugtype's name with string", ConsoleColor.Red);
                                goto inputDrugType2;
                            }

                        inputDrugName2:
                            Easy.Print("Enter drug's name", ConsoleColor.Green);
                            string name = Console.ReadLine();
                            isInt = int.TryParse(name,out int mainName);
                            if (isInt)
                            {
                                Easy.Print("Enter correct drugname..",ConsoleColor.Red);
                                goto inputDrugName2;
                            }
                        inputMoney:
                            Easy.Print("Enter your money :", ConsoleColor.Green);
                            string money = Console.ReadLine();
                            bool isDouble2 = Double.TryParse(money, out double mainMoney);
                            if (!isDouble2)
                            {
                                Easy.Print("enter correctly price of drug", ConsoleColor.Red);
                                goto inputMoney;
                            }
                        inputCount2:
                            Easy.Print("Enter wanted drug's count: ", ConsoleColor.Green);
                            string count2 = Console.ReadLine();
                            isInt = int.TryParse(count2, out int Count2);
                            if (!isInt)
                            {
                                Easy.Print("enter correctly count of drug ", ConsoleColor.Red);
                                goto inputCount2;
                            }

                            existPharmacy.SaleDrug(name, mainMoney, Count2, drugType2);
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    Easy.Print("Choose number from given numbers ", ConsoleColor.Red);
                }
            }

        }

    }
}




