using System;
using System.Linq.Expressions;
using TestMapster.Dtos.Dtos;
using TestMapster.Library.Models;

namespace TestMapster.Dtos.Dtos
{
    public static partial class SubjectMapper
    {
        public static SubjectDto AdaptToDto(this Subject p1)
        {
            return p1 == null ? null : new SubjectDto() {Name = p1.Name};
        }
        public static SubjectDto AdaptTo(this Subject p2, SubjectDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            SubjectDto result = p3 ?? new SubjectDto();
            
            result.Name = p2.Name;
            return result;
            
        }
        public static Expression<Func<Subject, SubjectDto>> ProjectToDto => p4 => new SubjectDto() {Name = p4.Name};
    }
}