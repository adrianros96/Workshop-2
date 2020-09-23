namespace Model
{
    class BoatModel
    {
        public int BoatID { get; set; }

        public string BoatType { get; set; }

        public int BoatLength{ get; set; }

        public BoatModel(int boatdID, string boatType, int length)
        {
            BoatID = boatdID;
            BoatType = boatType;
            BoatLength = length;
        }
    }
}