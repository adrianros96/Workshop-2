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
        public void AddToJSON(MemberModel memberModel)
        {
            var memberList = ReadMemberListFile();

            if(memberList.Count() == 0) {
                memberModel.MemberID = 1;
                } else {
                var item = memberList.LastOrDefault();
                memberModel.MemberID = item.MemberID + 1;
                }

                memberList.Add(memberModel);

            WriteMemberListFile(memberList);
        }

        public void removeMember(int memberID) 
        {
            var memberList = ReadMemberListFile();

            memberList.RemoveAll(r => r.MemberID == memberID);
            WriteMemberListFile(memberList);
        }

        public void showMember(int memberID)
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

        public void showVerboseList()
        {
            var memberList = ReadMemberListFile();

            foreach (var member in memberList)
            {
                 System.Console.WriteLine("Full name: " + member.FullName + "\n" +
                                            "Social Security Number: " + member.SocialSecurityNumber + "\n" +
                                            "Member ID Number: " + member.MemberID + "\n" + "Boats and information: ");
                foreach (var boat in member.Boats)
                {
                    System.Console.WriteLine("BOAT: ID - " + boat.BoatID + ", Type - " + boat.BoatType + ", Length - " + boat.BoatLength + " Meters\n");
                }
            }
        }

        public void showCompactList()
        {
            var memberList = ReadMemberListFile();

            foreach (var item in memberList)
            {
                    System.Console.WriteLine("Full name: " + item.FullName + "\n" + 
                                            "Member ID: " + item.MemberID + "\n" +
                                            "Number of boats: " + item.Boats.Count() + "\n");
            }
        }

        public void editMemberName(int memberID)
        {
            var memberList = ReadMemberListFile();

            foreach (var item in memberList)
            {
                if(memberID == item.MemberID)
                {
                    System.Console.WriteLine("Current name is: " + item.FullName + "\nInsert new name below:");
                    item.FullName = Console.ReadLine();
                }
            }

            WriteMemberListFile(memberList);
        }

        public void editMemberSSN(int memberID)
        {
            var memberList = ReadMemberListFile();

            foreach (var item in memberList)
            {
                if(memberID == item.MemberID)
                {
                    System.Console.WriteLine("Current SSN is: " + item.SocialSecurityNumber + "\nInsert new SSN below:");
                    item.SocialSecurityNumber = Int32.Parse(Console.ReadLine());  
                }
            }

            WriteMemberListFile(memberList);
        }

        public void AddBoatToJSON(BoatModel boatModel, int memberID)
        {
            var memberList = ReadMemberListFile();
            foreach (var member in memberList)
            {
                if(memberID == member.MemberID)
                {
                        if(member.Boats.Count() == 0) {
                           boatModel.BoatID = 1;
                        } else {
                            var item = member.Boats.LastOrDefault();
                            boatModel.BoatID = item.BoatID + 1;
                        }

                        member.Boats.Add(boatModel);
                        System.Console.WriteLine(boatModel.BoatType + " added to " + member.FullName);          
                }

            }
            WriteMemberListFile(memberList);
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
                    foreach (var boat in member.Boats)
                    {
                        System.Console.WriteLine("BOAT: ID - " + boat.BoatID + ", Type - " + boat.BoatType + ", Length - " + boat.BoatLength + " Meters\n");
                    }                         
                }
            }
                return memberExists;
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

        public void EditBoatType(int memberID, int boatID)
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
                            System.Console.WriteLine("Enter new type: ");
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
                            System.Console.WriteLine("Enter new length: ");
                            boat.BoatLength = Int32.Parse(Console.ReadLine());
                        }
                    }     
                }
            }

            WriteMemberListFile(memberList);
        }

        
    }
    
}