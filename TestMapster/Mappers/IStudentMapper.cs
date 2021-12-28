using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestMapster.Dtos;
using TestMapster.Models;

namespace TestMapster.Mappers
{
    [Mapper]
    public interface IStudentMapper
    {
        Expression<Func<Student, StudentDto>> StudentProjection { get; }
        StudentDto Map(Student student);
        StudentDto Map(Student student, StudentDto studentDto);
    }
}
