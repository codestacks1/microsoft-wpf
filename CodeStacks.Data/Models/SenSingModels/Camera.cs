namespace xiaowen.codestacks.data.SenSingModels
{
    public class Camera
    {
        public int Id { get; set; }
        public long Id64 { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public decimal SnapPeopleCount { get; set; }
        public int TypeKey { get; set; }
        public string TypeValue { get; set; }
        public string Location { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Brand { get; set; }
        public bool IsOpen { get; set; }


        #region redundancy
        public string Host { get; set; }
        public int Port { get; set; }
        public string Description { get; set; }

        #endregion

        #region METHODS



        #endregion
    }
}
