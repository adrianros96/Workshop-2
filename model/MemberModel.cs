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

        public MemberModel(string name, int ssn)
        {
            FullName = name;
            SocialSecurityNumber = ssn;
        }

        public override string ToString()
        {
            return "Name: " + FullName + " SSN: " + SocialSecurityNumber + " MemberID: " + MemberID;
        }
    }

}