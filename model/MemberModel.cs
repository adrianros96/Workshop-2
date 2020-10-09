using System;
using System.Collections.Generic;

namespace Model
{
    class MemberModel
    {
        private List<BoatModel> _Boats = new List<BoatModel>();
        public string FullName { get; set; }

        public int SocialSecurityNumber { get; set; }
        
        public int MemberID { get; set; }

        public List<BoatModel> Boats 
        {
            get { return _Boats; }
            set { _Boats = value; } 
        }

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