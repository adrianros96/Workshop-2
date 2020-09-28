using Model;
using System;

namespace View
{
    class BoatView
    {

        MemberModel memberModel;
        BoatModel boatModel;
        DatabaseModel dbModel = new DatabaseModel();

        public void ManageBoats()
        {
            Console.Clear();

            Console.WriteLine("1: Add boat");
            Console.WriteLine("2: Edit boat");
            Console.WriteLine("3: Remove boat");
            Console.WriteLine("4: Exit");
             switch(Console.ReadLine())
                {
                    case "1":
                        AddBoat();
                        return;
                    case "2":
                        EditBoat();
                        break;
                    case "3":
                        RemoveBoat();
                        break;                        
                    case "4":
                        Environment.Exit(0);
                        break;                        
                }
        }

        public void AddBoat()
        {
            Console.Clear();

            string boatType;
            int length;
            int memberID;

            System.Console.WriteLine("Type of boat: Sailboat, Motorsailer, kayak/Canoe, Other");
            boatType = Console.ReadLine();
            System.Console.WriteLine("Enter the length in cm of your boat");
            length = Int32.Parse(Console.ReadLine());
            System.Console.WriteLine("Type member ID to assign boat to");
            memberID = Int32.Parse(Console.ReadLine());
            
            // if(boatType.Length > 0 && length > 89999)
            // {
                boatModel = new BoatModel(boatType, length);

                dbModel.AddBoatToJSON(boatModel, memberID);
        }

        public void EditBoat()
        {

        }

        public void RemoveBoat()
        {

        }
    }
}