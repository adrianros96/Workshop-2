using Model;
using System;

namespace View
{
    // This is the view regarding actions about members.
    class Memberview
    {
        MemberModel memberModel;
        DatabaseModel dbModel = new DatabaseModel();

        public void AddMember()
        {
            Console.Clear();

            try
            {
                string name;
                int ssn;

                System.Console.WriteLine("Enter your full name");
                name = Console.ReadLine();
                System.Console.WriteLine("Enter you social security number format: yymmdd");
                ssn = Int32.Parse(Console.ReadLine());
                
                if(name.Length > 1 && ssn > 1000 && ssn < Int32.MaxValue)
                {
                    memberModel = new MemberModel(name, ssn);
                    dbModel.AddToJSON(memberModel);
                    System.Console.WriteLine(memberModel.ToString());
                }
            }
            catch (Exception)
            {     
                throw new Exception("Not a valid input");
            }
            
            
        }

        // Gives options to edit specific parts of a member.
        public void EditMember()
        {
            Console.Clear();

            Console.WriteLine("1: Edit name");
            Console.WriteLine("2: Change SSN");
            Console.WriteLine("Any key: Exit");
            switch(Console.ReadLine())
            {
                case "1":
                    EditName();
                    break;
                case "2":
                    EditSSN();
                    break;
                case "3":
                    break;                        
            }
        }

        public void EditName()
        {
            try
            {
                int memberID; 
                Console.Clear();
                System.Console.WriteLine("Edit user full name by entering ID");
                memberID = Int32.Parse(Console.ReadLine());
                this.ShowMemberEdit(memberID);
                dbModel.EditMemberName(memberID);
            }
            catch (Exception)
            {     
                throw new Exception("Not a valid number");
            }
        }

        private void ShowMemberEdit(int memberID)
        {
            System.Console.WriteLine(dbModel.ShowMemberName(memberID));
        }

        public void EditSSN()
        {
            try
            {
                int ID; 
                Console.Clear();
                System.Console.WriteLine("Change user SSN by entering ID");
                ID = Int32.Parse(Console.ReadLine());
                this.ShowSpecificBoat(ID);
                dbModel.EditMemberSSN(ID);
            }
            catch (Exception)
            {     
                throw new Exception("Not a valid number");
            }
        }

        private void ShowSpecificBoat(int memberID)
        {
            System.Console.WriteLine(dbModel.ShowMemberSSN(memberID));
        }

        public void DeleteMember()
        {
            try
            {
                int ID; 
                Console.Clear();
                System.Console.WriteLine("Remove user by entering ID");
                ID = Int32.Parse(Console.ReadLine());
                dbModel.RemoveMember(ID);
            }
            catch (Exception)
            {     
                throw new Exception("Not a valid number");
            }
        }

        public void ShowMember()
        {
            try
            {
                System.Console.WriteLine("Please enter member ID:");
                int memberID = Int32.Parse(Console.ReadLine());

                dbModel.ShowMember(memberID);
            
            } 
            catch (Exception)
            {     
                throw new Exception("Not a valid number");
            }
        }

        public void VerboseMemberList()
        {
            System.Console.WriteLine("Verbose List:");

            string verboseList = dbModel.ShowVerboseList();
            System.Console.WriteLine(verboseList);

            ExitToMainMenu();
        }

        public void CompactMemberList()
        {
            System.Console.WriteLine("Compact List:");

            string compactList = dbModel.ShowCompactList();
            System.Console.WriteLine(compactList);
            
            ExitToMainMenu();
        }

        public void ExitToMainMenu()
        {
            System.Console.WriteLine("1: Back to main menu");
            switch(Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    break;
            }
        }
    }
}