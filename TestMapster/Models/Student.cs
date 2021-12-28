using Mapster;

namespace TestMapster.Models
{
    [AdaptTo("[name]Dto"), GenerateMapper]
    public class Student
    {
        public string Name { get; set; } = String.Empty;
    }
}
