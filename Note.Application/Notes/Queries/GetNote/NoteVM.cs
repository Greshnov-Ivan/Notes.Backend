using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;
using System;

namespace Notes.Application.Notes.Queries.GetNote
{
    public class NoteVM : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        // Реализуем метод для создания соответствия
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteVM>()
                .ForMember(noteVM => noteVM.Title,
                    opt => opt.MapFrom(note => note.Title))
                .ForMember(noteVM => noteVM.Content,
                    opt => opt.MapFrom(note => note.Content))
                .ForMember(noteVM => noteVM.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteVM => noteVM.CreationDate,
                    opt => opt.MapFrom(note => note.CreationDate))
                .ForMember(noteVM => noteVM.EditDate,
                    opt => opt.MapFrom(note => note.EditDate));
        }
    }
}
