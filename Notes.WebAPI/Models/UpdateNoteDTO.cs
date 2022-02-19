using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.UpdateNote;
using System;

namespace Notes.WebAPI.Models
{
    public class UpdateNoteDTO : IMapWith<CreateNoteCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDTO, UpdateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Id,
                    opt => opt.MapFrom(noteDTO => noteDTO.Id))
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(noteDTO => noteDTO.Title))
                .ForMember(noteCommand => noteCommand.Content,
                    opt => opt.MapFrom(noteDTO => noteDTO.Content));
        }
    }
}
