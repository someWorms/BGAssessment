using ANPR.Infrastructure.Extensions;
using ANPR.Persistence.Database;
using ANPR.Persistence.Database.Interfaces;
using ANPR.Persistence.Models;
using ANPR.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ANPR.Services
{
    public class FileService : IFileService
    {
        private readonly IDatabaseContext _context;
        public FileService(IDatabaseContext databaseContext)
        {
            _context = databaseContext;
        }
        public List<PlateModel> GetByDateRange(int startDate, int endDate)
        {
            return _context.Plates.Where(e => e.Date >= startDate && e.Date <= endDate).ToList();
        }

        public List<PlateModel> GetByCameraName(string cameraName)
        {
            return _context.Plates.Where(e => e.CameraName == cameraName).ToList();
        }

        public bool IsExist(string path)
        {
            var result = _context.ProcessedFiles.Any(e => e.FilePath == path);
            return result;
        }

        public bool SaveData(string path)
        {
            if(IsExist(path))
            {
                return false;
            }

            using (StreamReader reader = new StreamReader(path))
            {
                var line = reader.ReadLine();
                var devidedSections = line.Split('/');
                var infoSection = devidedSections[0].Split('\\');

                var plate = BuildPlate(infoSection, devidedSections);

                var processed = new ProcessedFileModel { FilePath = path };

                _context.Plates.Add(plate);
                _context.ProcessedFiles.Add(processed);

                _context.SaveChanges();

            }
            return true;
        }

        private PlateModel BuildPlate(string[] infoSection, string[] devidedSections)
        {
            return new PlateModel
            {
                CountryCode = infoSection[0],
                RegNumber = infoSection[1].DropR(),
                ConfidenceLevel = infoSection[2].DropR(),
                CameraName = infoSection[3].DropR(),
                Date = Int32.Parse(infoSection[4]),
                Time = Int32.Parse(infoSection[5]),
                ImageFileName = devidedSections[1],
            };
        }
    }
}
