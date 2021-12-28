using TestMapster.Dtos;
using TestMapster.Models;

namespace TestMapster.Dtos
{
    public static partial class StudentMapper
    {
        public static StudentDto AdaptToDto(this Student p1)
        {
            return p1 == null ? null : new StudentDto() {Name = p1.Name};
        }
        public static StudentDto AdaptTo(this Student p2, StudentDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            StudentDto result = p3 ?? new StudentDto();
            
            result.Name = p2.Name;
            return result;
            
        }
    }
}