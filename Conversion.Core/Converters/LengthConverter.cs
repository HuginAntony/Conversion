using System.Threading.Tasks;
using Conversion.Core.Contracts;

namespace Conversion.Core.Converters
{
    public class LengthConverter : ILengthConverter
    {
        public Task<decimal> ConvertToKilometers(decimal mileValue)
        {
            var result = mileValue / 0.62137m;
            return Task.FromResult(result);
        }

        public Task<decimal> ConvertToMiles(decimal kilometerValue)
        {
            var result = kilometerValue * 0.62137m;
            return Task.FromResult(result);
        }
    }
}