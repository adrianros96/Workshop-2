using Model;
using System;
using System.Collections.Generic;
using System.Linq;

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
                var memberList = dbModel.GetMemberList();

                string showMember = this.ShowMemberEdit(memberID, memberList);
                System.Console.WriteLine(showMember);


                foreach (var member in memberList)
                {
                    if(memberID == member.MemberID)
                    {
                        member.FullName = Console.ReadLine();
                    }
                }
                dbModel.WriteMemberListFile(memberList);
            }
            catch (Exception)
            {     
                throw new Exception("Not a valid number");
            }
        }

        private string ShowMemberEdit(int memberID, List<MemberModel> memberList)
        {
            string editMemberText = "";

            foreach (var member in memberList)
            {
                if(memberID == member.MemberID)
                {
                    editMemberText = "Current name is: " + member.FullName + "\nInsert new name below:";
                }
            }
            return editMemberText;
        }

        public void EditSSN()
        {
            try
            {
                int memberID; 
                Console.Clear();
                System.Console.WriteLine("Change user SSN by entering ID");
                memberID = Int32.Parse(Console.ReadLine());
                var memberList = dbModel.GetMemberList();
                var memberSSN = this.ShowSpecificBoat(memberID, memberList);
                System.Console.WriteLine(memberSSN);

                foreach (var item in memberList)
                {
                    if(memberID == item.MemberID)
                    {
                        item.SocialSecurityNumber = Int32.Parse(Console.ReadLine());  
                    }
                }
                dbModel.WriteMemberListFile(memberList);
            }
            catch (Exception)
            {     
                throw new Exception("Not a valid number");
            }
        }

        private string ShowSpecificBoat(int memberID, List<MemberModel> memberList)
        {
            string memberSSN = "";

            foreach (var member in memberList)
            {
                if(memberID == member.MemberID)
                {
                    memberSSN = "Current SSN is: " + member.SocialSecurityNumber + "\nInsert new SSN below:"; 
                }
            }
            return memberSSN;
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

                var memberList = dbModel.GetMemberList();

                 foreach (var item in memberList)
                {
                    if(memberID == item.MemberID)
                    {
                        System.Console.WriteLine(item);                             
                    }
                }
            
            } 
            catch (Exception)
            {     
                throw new Exception("Not a valid number");
            }
        }

        public void VerboseMemberList()
        {
            System.Console.WriteLine("Verbose List:");

            var memberList = dbModel.GetMemberList();

            string verboseList = "";

            foreach (var member in memberList)
            {
                verboseList += "Full name: " + member.FullName + "\n" +
                                            "Social Security Number: " + member.SocialSecurityNumber + "\n" +
                                            "Member ID Number: " + member.MemberID + "\n" + "Boats and information:\n\n";
                foreach (var boat in member.Boats)
                {
                    verboseList += "BOAT: ID - " + boat.BoatID + ", Type - " + boat.BoatType + ", Length - " + boat.BoatLength + " Meters\n\n";
                }
            }
            System.Console.WriteLine(verboseList);

            ExitToMainMenu();
        }

        public void CompactMemberList()
        {
            System.Console.WriteLine("Compact List:");

            var memberList = dbModel.GetMemberList();

            string compactList = "";

            foreach (var item in memberList)
            {
                compactList += "Full name: " + item.FullName + "\n" + 
                                            "Member ID: " + item.MemberID + "\n" +
                                            "Number of boats: " + item.Boats.Count() + "\n\n";
            }
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