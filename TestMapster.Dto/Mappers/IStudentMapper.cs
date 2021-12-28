using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestMapster.Dtos.Dtos;
using TestMapster.Library.Models;

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
