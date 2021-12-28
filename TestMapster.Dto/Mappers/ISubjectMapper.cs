using Mapster;
using TestMapster.Library.Models;
using TestMapster.Dtos.Dtos;
using System.Linq.Expressions;

namespace TestMapster.Dtos.Mappers
{
    [Mapper]
    public interface ISubjectMapper
    {
        Expression<Func<Subject, SubjectDto>> SubjectProjection { get; }
        SubjectDto Map(Subject subject);
        SubjectDto Map(Subject subject, SubjectDto subjectDto);
    }
}
