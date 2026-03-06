namespace Directo.Wari.Application.Common.Responses
{
    public class BeanGenericClass<T>
    {
        public int IdResultado { get; set; } = 0;
        public string Resultado { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int ValueI { get; set; }
        public Dictionary<string, string> Values { get; set; } = new();
        public List<T> List { get; set; } = new();
    }
}
