namespace Model
{
    class BoatModel
    {
        public int BoatID { get; set; }

        public string BoatType { get; set; }
        // (Sailboat, Motorsailer, kayak/Canoe, Other)

        public int BoatLength{ get; set; }

        public BoatModel(string boatType, int length)
        {
            BoatType = boatType;
            BoatLength = length;
        }
    }
}