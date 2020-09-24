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
            memberModel.MemberID = 1;
            bool uniqueID = UniqueIDcheck(memberModel, memberList);

            if(uniqueID){
                // TODO unique id after deleting member
                memberModel.MemberID = memberList.Count() + 1;
                memberList.Add(memberModel);
            } else {
                memberList.Add(memberModel);
            }

            // Update json data string
            jsonData = JsonConvert.SerializeObject(memberList);
            System.IO.File.WriteAllText("Members.json", jsonData);
        }

          public bool UniqueIDcheck(MemberModel model, List<MemberModel> memberList) 
          {
            bool found = false;
            foreach (var id in memberList)
            {
                if (model.MemberID == id.MemberID)
                {
                    found = true;
                }
            }
            return found;
        }

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
    }
}