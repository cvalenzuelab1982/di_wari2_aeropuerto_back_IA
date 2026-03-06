namespace Directo.Wari.Application.Common.Responses
{
    public class BeanGeneric
    {
        public int idResultado { get; set; }
        public string resultado { get; set; } = "";
        public string value { get; set; } = "";
        public Dictionary<string, string> values { get; set; } = new();
        public List<object> list { get; set; } = new();
    }
}
