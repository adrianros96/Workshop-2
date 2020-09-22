namespace Model
{
    class Member
    {
        private string name;
        private int ssn;
        private int memberID;
        
        public string FullName {
            get { return name; }
        }

        public int Birthday {
            get { return ssn; }
        }

        public int MemberID 
        {
            get { return memberID; }
        }

        public Member(string name, int ssn, int memberID)
        {

        }

        public void AddMember(string name, int birthday) {
            
        }
    }
}