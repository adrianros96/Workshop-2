using Model;
using System;

namespace View
{
    class BoatView
    {

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
                    break;                        
            }
        }

        public void AddBoat()
        {
            Console.Clear();

            try 
            {
                string boatType;
                int length;
                int memberID;

                System.Console.WriteLine("Type of boat: Sailboat, Motorsailer, kayak/Canoe, Other");
                boatType = Console.ReadLine();
                System.Console.WriteLine("Enter the length in meters of your boat");
                length = Int32.Parse(Console.ReadLine());
                System.Console.WriteLine("Type member ID to assign boat to");
                memberID = Int32.Parse(Console.ReadLine());

                boatModel = new BoatModel(boatType, length);

                dbModel.AddBoatToJSON(boatModel, memberID);
            }
            catch (Exception)
            {     
                throw new Exception("Not a valid input");
            }
        }

        public void RemoveBoat()
        {
            Console.Clear();

            try
            {
                int memberID;
                int boatID;

                System.Console.WriteLine("Enter your Member ID:");
                memberID = Int32.Parse(Console.ReadLine());
                bool result = dbModel.CheckIfMemberExists(memberID);
                if (result)
                {
                    this.ShowSpecificBoat(memberID);
                    System.Console.WriteLine("Select the boat ID:");
                    boatID = Int32.Parse(Console.ReadLine());
                    dbModel.RemoveBoat(memberID, boatID);
                }
            }
            catch (Exception)
            {     
                throw new Exception("Not a valid number");
            }
        }

        private void ShowSpecificBoat(int memberID)
        {
            System.Console.WriteLine(dbModel.ShowMemberBoats(memberID));
        }

        public void EditBoat()
        {
            Console.Clear();

            Console.WriteLine("1: Edit Boat Type");
            Console.WriteLine("2: Edit Boat Length");
            Console.WriteLine("Any key: Exit");
            switch(Console.ReadLine())
            {
                case "1":
                    EditBoatType();
                    break;
                case "2":
                    EditBoatLength();
                    break;
                case "3":
                    break;                        
            }
        }

        public void EditBoatType()
        {
            Console.Clear();

            try 
            {
                int memberID;
                int boatID;

                System.Console.WriteLine("Enter the Member ID:");
                memberID = Int32.Parse(Console.ReadLine());
                bool result = dbModel.CheckIfMemberExists(memberID);
                if (result)
                {
                    System.Console.WriteLine("Select the boat ID:");
                    boatID = Int32.Parse(Console.ReadLine());
                    System.Console.WriteLine("Enter new type: ");
                    dbModel.BoatType(memberID, boatID);
                }
            }
            catch (Exception)
            {     
                throw new Exception("Not a valid number");
            }
        }

        public void EditBoatLength()
        {
            Console.Clear();

            try 
            {
                int memberID;
                int boatID;

                System.Console.WriteLine("Enter the Member ID:");
                memberID = Int32.Parse(Console.ReadLine());
                bool result = dbModel.CheckIfMemberExists(memberID);
                if (result)
                {
                    System.Console.WriteLine("Select the boat ID:");
                    boatID = Int32.Parse(Console.ReadLine());
                    System.Console.WriteLine("Enter new length: ");
                    dbModel.EditBoatLength(memberID, boatID);
                }
            }
            catch (Exception)
            {     
                throw new Exception("Not a valid number");
            }
        }
    }
}