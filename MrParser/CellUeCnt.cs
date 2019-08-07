namespace MrParser
{
    public class CellUeCnt
    {
        public string LocalCellId { get; set; }
        public string CellName { get; set; }
        public string MoSignalCounter { get; set; }
        public string MoDataCounter { get; set; }
        public string MTAccessCounter { get; set; }
        public string OtherCounter { get; set; }
        public string TotalCounter{ get; set; }
        public string VoLTECounter { get; set; }
        public string CACounter { get; set; }
        public CellUeCnt()
        {

        }
    }
}