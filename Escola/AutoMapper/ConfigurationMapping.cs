using AutoMapper;
using Escola.Domain;
using ProjetoEscola.API.DTO;

namespace ProjetoEscola.API.AutoMapper
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            CreateMap<Usuario, UsuarioDto>()
                .ReverseMap();

            CreateMap<Aluno, AlunoDto>()
                .ReverseMap();

            CreateMap<Aula, AulaDto>()
                .ReverseMap();

            CreateMap<Professor, ProfessorDto>()
                .ReverseMap();

            CreateMap<Turma, TurmaDto>()
                .ReverseMap();

            CreateMap<TurmaAluno, TurmaAlunoDto>()
                .ForMember(dest => dest.Aluno, opt => opt.MapFrom(src => src.Aluno.Nome))
                .ForMember(dest => dest.Turma, opt => opt.MapFrom(src => src.Turma.Curso));

            CreateMap<TurmaProfessor, TurmaProfessorDto>()
                .ForMember(dest => dest.Professor, opt => opt.MapFrom(src => src.Professor.Nome))
                .ForMember(dest => dest.Turma, opt => opt.MapFrom(src => src.Turma.Curso));
        }
    }
}
