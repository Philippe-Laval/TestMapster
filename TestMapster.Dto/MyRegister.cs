using Mapster;
using System.Reflection;
using TestMapster.Library.Models;

// How to generate code with Mapster.Tool.exe
// cd C:\Users\philippe\source\repos\Philippe-Laval\TestMapster\TestMapster.Dto
// C:\Users\philippe\source\repos\Philippe-Laval\Mapster\src\Mapster.Tool\bin\Debug\net6.0\Mapster.Tool.exe model -a "C:\Users\philippe\source\repos\Philippe-Laval\TestMapster\TestMapster.Dto\bin\Debug\net6.0\TestMapster.Dto.dll" -n TestMapster.Dtos.Dtos -o Dtos
// C:\Users\philippe\source\repos\Philippe-Laval\Mapster\src\Mapster.Tool\bin\Debug\net6.0\Mapster.Tool.exe extension -a "C:\Users\philippe\source\repos\Philippe-Laval\TestMapster\TestMapster.Dto\bin\Debug\net6.0\TestMapster.Dto.dll" -n TestMapster.Dtos.Dtos -o Dtos
// C:\Users\philippe\source\repos\Philippe-Laval\Mapster\src\Mapster.Tool\bin\Debug\net6.0\Mapster.Tool.exe mapper -a "C:\Users\philippe\source\repos\Philippe-Laval\TestMapster\TestMapster.Dto\bin\Debug\net6.0\TestMapster.Dto.dll" -n TestMapster.Dtos.Mappers -o Mappers


namespace TestMapster.Dto
{
    public class MyRegister : ICodeGenerationRegister
    {
        public void Register(CodeGenerationConfig config)
        {
            //config.AdaptTo("[name]Dto")
            //    .ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), "TestMapster.Library.Models");

            var as1 = Assembly.Load("TestMapster.Library");

            config.AdaptTo("[name]Dto", MapType.Map | MapType.MapToTarget | MapType.Projection)
                .ForAllTypesInNamespace(as1, "TestMapster.Library.Models");
            //.IgnoreNoModifyProperties();

            //config.AdaptTo("[name]Dto")
            //    .ForType<Author>();

            //config.AdaptTo("[name]Dto")
            //    .ForType<Book>();


            config.GenerateMapper("[name]Mapper")
                .ForAllTypesInNamespace(as1, "TestMapster.Library.Models");

        }
    }

    static class RegisterExtensions
    {
        public static AdaptAttributeBuilder ApplyDefaultRule(this AdaptAttributeBuilder builder)
        {
            var as1 = Assembly.Load("TestMapster.Library");

            return builder
                .ForAllTypesInNamespace(as1, "TestMapster.Library.Models")

                //.ExcludeTypes(typeof(SchoolContext))
                .ExcludeTypes(type => type.IsEnum)
                .AlterType(type => type.IsEnum || Nullable.GetUnderlyingType(type)?.IsEnum == true, typeof(string));
                //.ShallowCopyForSameType(true)
                //.ForType<Enrollment>(cfg => cfg.Ignore(it => it.Course))
                //.ForType<Student>(cfg => cfg.Ignore(it => it.Enrollments));
        }

        public static AdaptAttributeBuilder IgnoreNoModifyProperties(this AdaptAttributeBuilder builder)
        {
            return builder
                .ForType<Book>(cfg => cfg.Ignore(it => it.Author));
        }
    }
}

