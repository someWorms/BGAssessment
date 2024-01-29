using AgeCalculator.Models;

namespace AgeCalculator.Services.Interfaces
{
    /// <summary>
    /// ICalculator base interface
    /// </summary>
    public interface ICalculatorService
    {
        /// <summary>
        /// Calculates dates, processes the only model. 
        /// </summary>
        /// <param name="data"><c>AgeViewModel</c> containing input data</param>
        /// <returns><c>AgeViewModel</c> containing input and calculated data</returns>
        AgeViewModel CalculateDate(AgeViewModel data);
    }
}
