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
        }

        public void EditMember()
        {
            // Console.WriteLine("1: Edit name");
            // Console.WriteLine("2: Change SSN");
            // Console.WriteLine("3: Exit");
            //  switch(Console.ReadLine())
            //     {
            //         case "1":
            //             Environment.Exit(0);
            //             break;
            //         case "2":
            //             memberView.AddMember();
            //             return;
            //         case "3":
            //             memberView.EditMember();
            //             break;
            //         case MenuOptions.ManageBoats:
            //             boatView.ManageBoats();
            //             break;
            //     }
        }

        public void RemoveMember()
        {
            int ID; 
            Console.Clear();
            System.Console.WriteLine("Remove user by entering ID");
            ID = Int32.Parse(Console.ReadLine());
            dbModel.removeMember(ID);
            System.Console.WriteLine("Hello world");
        }

        public void ShowMember()
        {
            System.Console.WriteLine("Please enter member ID:");
            int memberID = Int32.Parse(Console.ReadLine());

            dbModel.showMember(memberID);
        }

        public void VerboseMemberList()
        {
            System.Console.WriteLine("Hello world");
        }

        public void CompactMemberList()
        {
            
        }
    }
}