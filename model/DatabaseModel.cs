using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Model
{
    class DatabaseModel
    {

        MemberModel memberModel;
        public void AddToJSON(MemberModel memberModel)
        {
            var memberList = ReadMemberListFile();

            if(memberList.Count() == 0) 
            {
                memberModel.MemberID = 1;
            }
            else 
            {
                var item = memberList.LastOrDefault();
                memberModel.MemberID = item.MemberID + 1;
            }
            memberList.Add(memberModel);

            WriteMemberListFile(memberList);
        }

        public void RemoveMember(int memberID) 
        {
            var memberList = ReadMemberListFile();

            memberList.RemoveAll(r => r.MemberID == memberID);
            WriteMemberListFile(memberList);
        }

        public void ShowMember(int memberID)
        {
            var memberList = ReadMemberListFile();

            foreach (var item in memberList)
            {
                if(memberID == item.MemberID)
                {
                    System.Console.WriteLine(item);                             
                }
            }
        }

        public string ShowVerboseList()
        {
            var memberList = ReadMemberListFile();

            string verboseList = "";

            foreach (var member in memberList)
            {
                verboseList += "Full name: " + member.FullName + "\n" +
                                            "Social Security Number: " + member.SocialSecurityNumber + "\n" +
                                            "Member ID Number: " + member.MemberID + "\n" + "Boats and information:\n";
                foreach (var boat in member.Boats)
                {
                    verboseList += "BOAT: ID - " + boat.BoatID + ", Type - " + boat.BoatType + ", Length - " + boat.BoatLength + " Meters\n\n";
                }
            }
            return verboseList;
        }

        public string ShowCompactList()
        {
            var memberList = ReadMemberListFile();

            string compactList = "";

            foreach (var item in memberList)
            {
                compactList += "Full name: " + item.FullName + "\n" + 
                                            "Member ID: " + item.MemberID + "\n" +
                                            "Number of boats: " + item.Boats.Count() + "\n\n";
            }
            return compactList;
        }

        public void EditMemberName(int memberID)
        {
            var memberList = ReadMemberListFile();

            foreach (var member in memberList)
            {
                if(memberID == member.MemberID)
                {
                    member.FullName = Console.ReadLine();
                }
            }
            WriteMemberListFile(memberList);
        }

        public string ShowMemberName(int memberID)
        {
            var memberList = ReadMemberListFile();

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

        public void EditMemberSSN(int memberID)
        {
            var memberList = ReadMemberListFile();

            foreach (var item in memberList)
            {
                if(memberID == item.MemberID)
                {
                    item.SocialSecurityNumber = Int32.Parse(Console.ReadLine());  
                }
            }
            WriteMemberListFile(memberList);
        }

        public string ShowMemberSSN(int memberID)
        {
            var memberList = ReadMemberListFile();

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

        public string AddBoatToJSON(BoatModel boatModel, int memberID)
        {
            var memberList = ReadMemberListFile();

            string addBoatList = "";

            foreach (var member in memberList)
            {
                if(memberID == member.MemberID)
                {
                        if(member.Boats.Count() == 0) 
                        {
                            boatModel.BoatID = 1;
                        } 
                        else 
                        {
                            var item = member.Boats.LastOrDefault();
                            boatModel.BoatID = item.BoatID + 1;
                        }

                        member.Boats.Add(boatModel);
                        addBoatList = boatModel.BoatType + " added to " + member.FullName;

                }

            }
            WriteMemberListFile(memberList);

            return addBoatList;          
        }


        public void WriteMemberListFile(List<MemberModel> memberList)
        {
            var jsonData = JsonConvert.SerializeObject(memberList);
            System.IO.File.WriteAllText("MemberData/Members.json", jsonData);
        }

        public List<MemberModel> ReadMemberListFile()
        {
            var jsonData = System.IO.File.ReadAllText("MemberData/Members.json");
            var memberList = JsonConvert.DeserializeObject<List<MemberModel>>(jsonData) 
                                                                ?? new List<MemberModel>();
            return memberList;
        }

        public bool CheckIfMemberExists(int memberID) 
        {
            var memberList = ReadMemberListFile();

            bool memberExists = false;
            

            foreach (var member in memberList)
            {
                if(memberID == member.MemberID)
                {
                    memberExists = true;                      
                }
            }
            return memberExists;
        }

         public string ShowMemberBoats(int memberID) 
        {
            var memberList = ReadMemberListFile();

            string specificBoat = "";
            

            foreach (var member in memberList)
            {
                if(memberID == member.MemberID)
                {
                    foreach (var boat in member.Boats)
                    {
                        specificBoat += "BOAT: ID - " + boat.BoatID + ", Type - " + boat.BoatType + ", Length - " + boat.BoatLength + " Meters\n";
                    }                         
                }
            }
            return specificBoat;
        }  

        public void RemoveBoat(int memberID, int boatID) 
        {
            var memberList = ReadMemberListFile();

            foreach (var member in memberList)
            {
                if(memberID == member.MemberID)
                {
                    member.Boats.RemoveAll(r => r.BoatID == boatID);
                }
            }                                                   
            WriteMemberListFile(memberList);
        }

        public void BoatType(int memberID, int boatID)
        {
            var memberList = ReadMemberListFile();


            foreach (var member in memberList)
            {
                if(memberID == member.MemberID)
                {
                    foreach (var boat in member.Boats)
                    {
                        if(boatID == boat.BoatID)
                        {
                            boat.BoatType = Console.ReadLine();
                        }
                    }     
                }
            }
            WriteMemberListFile(memberList);   
        }

        public void EditBoatLength(int memberID, int boatID)
        {
           var memberList = ReadMemberListFile();

            foreach (var member in memberList)
            {
                if(memberID == member.MemberID)
                {
                    foreach (var boat in member.Boats)
                    {
                        if(boatID == boat.BoatID)
                        {
                            boat.BoatLength = Int32.Parse(Console.ReadLine());
                        }
                    }     
                }
            }
            WriteMemberListFile(memberList);
        }
    }
}