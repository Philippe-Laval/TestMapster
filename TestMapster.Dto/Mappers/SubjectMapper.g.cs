using System;
using System.Linq.Expressions;
using TestMapster.Dtos.Dtos;
using TestMapster.Library.Models;

namespace TestMapster.Dtos.Mappers
{
    public partial class SubjectMapper : ISubjectMapper
    {
        public Expression<Func<Subject, SubjectDto>> SubjectProjection => p1 => new SubjectDto() {Name = p1.Name};
        public SubjectDto Map(Subject p2)
        {
            return p2 == null ? null : new SubjectDto() {Name = p2.Name};
        }
        public SubjectDto Map(Subject p3, SubjectDto p4)
        {
            if (p3 == null)
            {
                return null;
            }
            SubjectDto result = p4 ?? new SubjectDto();
            
            result.Name = p3.Name;
            return result;
            
        }
    }
}