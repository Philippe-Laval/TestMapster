using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMapster.Library.Models;
using TestMapster.Dtos.Dtos;
using System.Linq.Expressions;

namespace TestMapster.Library.Mappers
{
    [Mapper]
    public interface ISubjectMapper
    {
        Expression<Func<Subject, SubjectDto>> SubjectProjection { get; }
        SubjectDto Map(Subject subject);
        SubjectDto Map(Subject subject, SubjectDto subjectDto);
    }
}
