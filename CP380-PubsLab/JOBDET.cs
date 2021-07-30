namespace CP380_PubsLab
{
    internal class JOBDET
    {
        internal string name;

        public string Desc { get;  set; }
        public int Id { get;  set; }
        public string Salesid { get; internal set; }
    }
    public class   EMPDET
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int jid { get; set; }
    }
    public class SALDET
    {
        public string Salesid { get; set; }
        public string title { get; set; }
    }
    public class TITDET
    {
        public string Salesid { get; set; }
        public string name { get; set; }
    }

}