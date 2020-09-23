using System;
using System.Collections.Generic;

namespace Model
{
    class MemberModel
    {
        public List<BoatModel> Boats = new List<BoatModel>();
        public string FullName { get; set; }

        public int SocialSecurityNumber { get; set; }
        
        public int MemberID { get; set; }

        public MemberModel(string name, int ssn, int memberID)
        {
            FullName = name;
            SocialSecurityNumber = ssn;
            MemberID = memberID;
        }

        public void AddMember(MemberModel model) {
            DatabaseModel dbModel = new DatabaseModel();

            dbModel.AddToJSON(model);
        }
        public override string ToString()
        {
            return "Name: " + FullName + " SSN: " + SocialSecurityNumber + " MemberID: " + MemberID;
        }
    }

}