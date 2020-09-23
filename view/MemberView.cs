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
            System.Console.WriteLine("Hello world");
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
            System.Console.WriteLine("Hello world");
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