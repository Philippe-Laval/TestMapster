using System;
using System.Linq.Expressions;
using TestMapster.Dtos.Dtos;
using TestMapster.Library.Models;

namespace TestMapster.Dtos.Mappers
{
    public partial class StudentMapper : IStudentMapper
    {
        public Expression<Func<Student, StudentDto>> StudentProjection => p1 => new StudentDto() {Name = p1.Name};
        public StudentDto Map(Student p2)
        {
            return p2 == null ? null : new StudentDto() {Name = p2.Name};
        }
        public StudentDto Map(Student p3, StudentDto p4)
        {
            if (p3 == null)
            {
                return null;
            }
            StudentDto result = p4 ?? new StudentDto();
            
            result.Name = p3.Name;
            return result;
            
        }
    }
}