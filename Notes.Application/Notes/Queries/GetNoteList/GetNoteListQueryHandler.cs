﻿using AutoMapper;
using MediatR;
using Notes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;


namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryHandler : IRequestHandler<GetNoteListQuery, NoteListVm>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetNoteListQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<NoteListVm> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
        {
            var notesQuery = await _dbContext.Notes
                .Where(n => n.UserId == request.UserId)
                .ProjectTo<NoteLookUpDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new NoteListVm { Notes = notesQuery };
        }
    }
}
