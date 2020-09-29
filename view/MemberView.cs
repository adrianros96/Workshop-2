using Model;
using System;

namespace View
{
    class Memberview
    {
        MemberModel memberModel;
        DatabaseModel dbModel = new DatabaseModel();

        public void AddMember()
        {
            Console.Clear();

            string name;
            int ssn;

            System.Console.WriteLine("Enter your full name");
            name = Console.ReadLine();
            System.Console.WriteLine("Enter you social security number");
            ssn = Int32.Parse(Console.ReadLine());
            
            if(name.Length > 0 && ssn > 89999)
            {
            memberModel = new MemberModel(name, ssn);
            dbModel.AddToJSON(memberModel);
            System.Console.WriteLine(memberModel.ToString());
            }
            ExitToMainMenu();
        }

        public void EditMember()
        {
            Console.Clear();

            Console.WriteLine("1: Edit name");
            Console.WriteLine("2: Change SSN");
            Console.WriteLine("3: Exit");
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
            int ID; 
            Console.Clear();
            System.Console.WriteLine("Edit user full name by entering ID");
            ID = Int32.Parse(Console.ReadLine());
            dbModel.editMemberName(ID);
            ExitToMainMenu();
        }

        public void EditSSN()
        {
            int ID; 
            Console.Clear();
            System.Console.WriteLine("Change user SSN by entering ID");
            ID = Int32.Parse(Console.ReadLine());
            dbModel.editMemberSSN(ID);
            ExitToMainMenu();
        }

        public void RemoveMember()
        {
            int ID; 
            Console.Clear();
            System.Console.WriteLine("Remove user by entering ID");
            ID = Int32.Parse(Console.ReadLine());
            dbModel.removeMember(ID);
            ExitToMainMenu();
        }

        public void ShowMember()
        {
            System.Console.WriteLine("Please enter member ID:");
            int memberID = Int32.Parse(Console.ReadLine());

            dbModel.showMember(memberID);
            ExitToMainMenu();
        }

        public void VerboseMemberList()
        {
            System.Console.WriteLine("Verbose List:");
            dbModel.showVerboseList();
            ExitToMainMenu();
        }

        public void CompactMemberList()
        {
            System.Console.WriteLine("Compact List:");
            dbModel.showCompactList();
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