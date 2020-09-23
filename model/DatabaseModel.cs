using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Model
{
    class DatabaseModel
    {
        public void AddToJSON(MemberModel model)
        {
            var jsonData = System.IO.File.ReadAllText("Members.json");
            var memberList = JsonConvert.DeserializeObject<List<MemberModel>>(jsonData) 
                                                                ?? new List<MemberModel>();
            bool hey = UniqueIDcheck(model, memberList);
            if(hey){
                model.MemberID += 1;
                memberList.Add(model);
            } else {
                memberList.Add(model);
            }

            // Update json data string
            jsonData = JsonConvert.SerializeObject(memberList);
            System.IO.File.WriteAllText("Members.json", jsonData);
        }

          public bool UniqueIDcheck(MemberModel model, List<MemberModel> memberList) {
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
    }
}