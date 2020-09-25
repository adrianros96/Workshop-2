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
            // TODO FIX DRY
            var jsonData = System.IO.File.ReadAllText("Members.json");
            var memberList = JsonConvert.DeserializeObject<List<MemberModel>>(jsonData) 
                                                                ?? new List<MemberModel>();

            if(memberList.Count() == 0) {
                memberModel.MemberID = 1;
                } else {
                var item = memberList.LastOrDefault();
                memberModel.MemberID = item.MemberID + 1;
                }
                // memberModel.MemberID = memberList.LastOrDefault();º
                memberList.Add(memberModel);

            // Update json data string
            jsonData = JsonConvert.SerializeObject(memberList);
            System.IO.File.WriteAllText("Members.json", jsonData);
        }

        //   public bool UniqueIDcheck(MemberModel model, List<MemberModel> memberList) 
        //   {
        //     bool found = false;
        //     foreach (var id in memberList)
        //     {
        //         if (model.MemberID == id.MemberID)
        //         {
        //             found = true;
        //         }
        //     }
        //     return found;
        // }

        public void removeMember(int memberID) 
        {
            var jsonData = System.IO.File.ReadAllText("Members.json");
            var memberList = JsonConvert.DeserializeObject<List<MemberModel>>(jsonData) 
                                                                ?? new List<MemberModel>();
            memberList.RemoveAll(r => r.MemberID == memberID);
            jsonData = JsonConvert.SerializeObject(memberList);
            System.IO.File.WriteAllText("Members.json", jsonData);
        }

        public void showMember(int memberID)
        {
            var jsonData = System.IO.File.ReadAllText("Members.json");
            var memberList = JsonConvert.DeserializeObject<List<MemberModel>>(jsonData) 
                                                                ?? new List<MemberModel>();
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
            var jsonData = System.IO.File.ReadAllText("Members.json");
            var memberList = JsonConvert.DeserializeObject<List<MemberModel>>(jsonData) 
                                                                ?? new List<MemberModel>();
            // For loop för indexera ut båt information?
            foreach (var item in memberList)
            {
                    System.Console.WriteLine("Full name: " + item.FullName + "\n" +
                                            "Social Security Number: " + item.SocialSecurityNumber + "\n" +
                                            "Member ID Number: " + item.MemberID + "\n" +
                                            "Boats and information: " + item.Boats + "\n");
            }
        }

        public void showCompactList()
        {
            var jsonData = System.IO.File.ReadAllText("Members.json");
            var memberList = JsonConvert.DeserializeObject<List<MemberModel>>(jsonData) 
                                                                ?? new List<MemberModel>();
            foreach (var item in memberList)
            {
                    System.Console.WriteLine("Full name: " + item.FullName + "\n" + 
                                            "Member ID: " + item.MemberID + "\n" +
                                            "Number of boats: " + item.Boats.Count() + "\n");
            }
        }

        public void editMemberName(int memberID)
        {
            var jsonData = System.IO.File.ReadAllText("Members.json");
            var memberList = JsonConvert.DeserializeObject<List<MemberModel>>(jsonData) 
                                                                ?? new List<MemberModel>();
            foreach (var item in memberList)
            {
                if(memberID == item.MemberID)
                {
                    System.Console.WriteLine("Current name is: " + item.FullName + "\nInsert new name below:");
                    item.FullName = Console.ReadLine();
                }
            }

            // Update json data string
            jsonData = JsonConvert.SerializeObject(memberList);
            System.IO.File.WriteAllText("Members.json", jsonData);
        }

        public void editMemberSSN(int memberID)
        {
            var jsonData = System.IO.File.ReadAllText("Members.json");
            var memberList = JsonConvert.DeserializeObject<List<MemberModel>>(jsonData) 
                                                                ?? new List<MemberModel>();
            foreach (var item in memberList)
            {
                if(memberID == item.MemberID)
                {
                    System.Console.WriteLine("Current SSN is: " + item.SocialSecurityNumber + "\nInsert new SSN below:");
                    item.SocialSecurityNumber = Int32.Parse(Console.ReadLine());  
                }
            }

            // Update json data string
            jsonData = JsonConvert.SerializeObject(memberList);
            System.IO.File.WriteAllText("Members.json", jsonData);
        }

/////////////////////////////////////////


        public void AddBoatToJSON(BoatModel boatModel, int memberID)
        {
            // TODO FIX DRY
            var jsonData = System.IO.File.ReadAllText("Members.json");
            var memberList = JsonConvert.DeserializeObject<List<MemberModel>>(jsonData) 
                                                                ?? new List<MemberModel>();
                            
            foreach (var item in memberList)
            {
                if(memberID == item.MemberID)
                {
                    System.Console.WriteLine("Boat added to " + item.FullName);                           
                    item.Boats.Add(boatModel);

                }

                    // if(item.Boats.Count() == 0) {
                    //     memberModel.MemberID = 1;
                    //     } else {
                    //     var item.Boats = memberList.LastOrDefault();
                    //     memberModel.MemberID = item.MemberID + 1;
                    //     }
                    //     // memberModel.MemberID = memberList.LastOrDefault();º
                    //     memberList.Add(memberModel); 

            }

            // Update json data string
            jsonData = JsonConvert.SerializeObject(memberList);
            System.IO.File.WriteAllText("Members.json", jsonData);
        }



    }

    
}