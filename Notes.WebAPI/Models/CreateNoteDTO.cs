﻿using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.CreateNote;

namespace Notes.WebAPI.Models
{
    public class CreateNoteDTO : IMapWith<CreateNoteCommand>
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteDTO, CreateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(noteDTO => noteDTO.Title))
                .ForMember(noteCommand => noteCommand.Content,
                    opt => opt.MapFrom(noteDTO => noteDTO.Content));
        }
    }
}
