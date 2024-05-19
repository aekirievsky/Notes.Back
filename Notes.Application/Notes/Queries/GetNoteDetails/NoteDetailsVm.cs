using AutoMapper;
using Core.Domain;
using Notes.Application.Common.Mapping;
using System;
using AutoMapper;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class NoteDetailsVm : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteDetailsVm>()
                .ForMember(noteVm => noteVm.Title,
                opt => opt.MapFrom(n => n.Title))
                .ForMember(noteVm => noteVm.Details,
                opt => opt.MapFrom(n => n.Details))
                 .ForMember(noteVm => noteVm.Id,
                opt => opt.MapFrom(n => n.Id))
                  .ForMember(noteVm => noteVm.CreationDate,
                opt => opt.MapFrom(n => n.CreationDate))
                   .ForMember(noteVm => noteVm.EditTime,
                opt => opt.MapFrom(n => n.EditTime));
        }
    }
}
