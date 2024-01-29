using ANPR.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANPR.Services.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Saves plate to database.
        /// Saves processed files.
        /// </summary>
        /// <param name="path">file path</param>
        bool SaveData(string path);

        /// <summary>
        /// Gets plate by Camera name
        /// </summary>
        /// <param name="cameraName">Camera name</param>
        /// <returns>List of plates shot by specified camera</returns>
        List<PlateModel> GetByCameraName(string cameraName);

        /// <summary>
        /// Gets plates from given date range
        /// Implemeted  date as Integer.
        /// </summary>
        /// <param name="startDate">start date format:YYYYMMDD</param>
        /// <param name="endDate">last date format:YYYYMMDD</param>
        /// <returns>List of plates within given range</returns>
        List<PlateModel> GetByDateRange(int startDate, int endDate);

        /// <summary>
        /// Check if file exists. 
        /// Here servers to check if file is already processed
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>true if processed, otherwise false</returns>
        bool IsExist(string path);
    }
}
