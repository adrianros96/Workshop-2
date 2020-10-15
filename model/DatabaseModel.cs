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

        public List<MemberModel> ReadMemberListFile()
        {
            var jsonData = System.IO.File.ReadAllText("MemberData/Members.json");
            var memberList = JsonConvert.DeserializeObject<List<MemberModel>>(jsonData) 
                                                                ?? new List<MemberModel>();
            return memberList;
        }

        public void WriteMemberListFile(List<MemberModel> memberList)
        {
            var jsonData = JsonConvert.SerializeObject(memberList);
            System.IO.File.WriteAllText("MemberData/Members.json", jsonData);
        }

        public List<MemberModel> GetMemberList() 
        {
            var memberList = ReadMemberListFile();

            return memberList;
        }  

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
            var memberList = GetMemberList();

            memberList.RemoveAll(r => r.MemberID == memberID);
            WriteMemberListFile(memberList);
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
    }
}