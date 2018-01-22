namespace NTachyon.Api.Model
{
    public class CrontabRequest
    {
        public string Expression { get; set; }
        public int? Occurances { get; set; }
    }
}