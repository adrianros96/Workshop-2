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

        public void RemoveBoat()
        {
            Console.Clear();
            int memberID;
            int boatID;

            System.Console.WriteLine("Enter your Member ID:");
            memberID = Int32.Parse(Console.ReadLine());
            bool result = dbModel.CheckIfMemberExists(memberID);
            if (result)
            {
                System.Console.WriteLine("Select the boat ID:");
                boatID = Int32.Parse(Console.ReadLine());
                dbModel.RemoveBoat(memberID, boatID);
            }
        }

        public void EditBoat()
        {
            Console.Clear();

            Console.WriteLine("1: Edit Boat Type");
            Console.WriteLine("2: Edit Boat Length");
            Console.WriteLine("3: Exit");
             switch(Console.ReadLine())
                {
                    case "1":
                        EditBoatType();
                        break;
                    case "2":
                        EditBoatLength();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;                        
                }
        }

        public void EditBoatType()
        {
            Console.Clear();
            int memberID;
            int boatID;

            System.Console.WriteLine("Enter the Member ID:");
            memberID = Int32.Parse(Console.ReadLine());
            bool result = dbModel.CheckIfMemberExists(memberID);
            if (result)
            {
                System.Console.WriteLine("Select the boat ID:");
                boatID = Int32.Parse(Console.ReadLine());
                dbModel.EditBoatType(memberID, boatID);
            }
        }

        public void EditBoatLength()
        {
            Console.Clear();
            int memberID;
            int boatID;

            System.Console.WriteLine("Enter the Member ID:");
            memberID = Int32.Parse(Console.ReadLine());
            bool result = dbModel.CheckIfMemberExists(memberID);
            if (result)
            {
                System.Console.WriteLine("Select the boat ID:");
                boatID = Int32.Parse(Console.ReadLine());
                dbModel.EditBoatLength(memberID, boatID);
            }
        }
    }
}