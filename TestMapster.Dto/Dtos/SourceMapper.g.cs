using System;
using System.Linq.Expressions;
using TestMapster.Dtos.Dtos;
using TestMapster.Library.Models;

namespace TestMapster.Dtos.Dtos
{
    public static partial class SourceMapper
    {
        public static SourceDto AdaptToDto(this Source p1)
        {
            return p1 == null ? null : new SourceDto()
            {
                Prop1 = p1.Prop1,
                Prop2 = p1.Prop2
            };
        }
        public static SourceDto AdaptTo(this Source p2, SourceDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            SourceDto result = p3 ?? new SourceDto();
            
            result.Prop1 = p2.Prop1;
            result.Prop2 = p2.Prop2;
            return result;
            
        }
        public static Expression<Func<Source, SourceDto>> ProjectToDto => p4 => new SourceDto()
        {
            Prop1 = p4.Prop1,
            Prop2 = p4.Prop2
        };
    }
}