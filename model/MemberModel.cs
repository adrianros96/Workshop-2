using System;
using System.Collections.Generic;

namespace Model
{
    class MemberModel
    {
        private List<BoatModel> _boats = new List<BoatModel>();

        private int _memberID;

        private int _socialSecurityNumber;
        
        private string _fullName;

        public int SocialSecurityNumber { 
            get { return _socialSecurityNumber; }
            set { _socialSecurityNumber = value; }
        }

        public string FullName { 
            get { return _fullName; }
            set { _fullName = value; }
        }
        public int MemberID  { 
            get { return _memberID; }
            set { _memberID = value; }
        }
        public List<BoatModel> Boats 
        {
            get { return _boats; }
            set { _boats = value; } 
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