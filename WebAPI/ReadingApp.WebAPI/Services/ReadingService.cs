using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using ReadingApp.WebAPI.DbContexts;
using ReadingApp.Infrastructure.DTOs;
using ReadingApp.Infrastructure.Entities;
using System.Collections.Generic;
using ReadingApp.WebAPI.Helpers;
using ReadingApp.WebAPI.Services.Interfaces;

namespace ReadingApp.WebAPI.Services
{
    public class ReadingService : IReadingService
    {
        private readonly ReadingDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ILogger<ReadingService> logger;

        public ReadingService(ReadingDbContext dbContext, IMapper mapper, ILogger<ReadingService> logger)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.logger = logger;
        }

        public IEnumerable<ReadingDto> ReadAll()
        {
            var readings = dbContext.Readings.Where(w => w.Enabled).ToList();
            var readingsDtos = mapper.Map<List<ReadingDto>>(readings);
            return readingsDtos;
        }

        public ReadingDto? ReadAt(int id)
        {
            var reading = dbContext.Readings.Where(w => w.Enabled && w.Id.Equals(id)).FirstOrDefault();
            if (reading == null)
                throw new ReadingNotFoundException();
            var readingDto = mapper.Map<ReadingDto>(reading);
            return readingDto;
        }

        public int Create(ReadingCreateDto readingCreateDto)
        {
            var reading = mapper.Map<Reading>(readingCreateDto);
            dbContext.Readings.Add(reading);
            dbContext.SaveChanges();
            return reading.Id;
        }

        public void Update(ReadingUpdateDto readingUpdateDto)
        {
            var reading = dbContext.Readings.SingleOrDefault(s => s.Id.Equals(readingUpdateDto.Id));
            if (reading == null)
                throw new ReadingNotFoundException();
            reading.Name = readingUpdateDto.Name;
            reading.Description = readingUpdateDto.Description;
            reading.AdditionalPropertyProcessor = readingUpdateDto.AdditionalPropertyProcessor;
            dbContext.SaveChanges();
        }
        public void DeleteAll()
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            var reading = dbContext.Readings.Where(w => w.Id.Equals(id)).FirstOrDefault();
            if (reading == null)
                throw new ReadingNotFoundException();
            else if (!reading.Enabled)
                throw new ReadingAlreadyExistsException();
            else
            {
                reading.Enabled = false;
                dbContext.SaveChanges();
            }
        }

    }
}
