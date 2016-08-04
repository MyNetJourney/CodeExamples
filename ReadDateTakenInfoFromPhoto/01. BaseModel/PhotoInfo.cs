namespace ReadDateTakenInfoFromPhoto._01._BaseModel
{
    public class PhotoInfo
    {
        public string FileName { get; set; }
        public string DateTaken { get; set; }
        public string CreationTime { get; set; }
        public string ModificationDate { get; set; }
        public string FilePath { get; set; }

        public string ComparableDate
        {
            get { return DateTaken ?? ModificationDate; }
        }
    }
}
