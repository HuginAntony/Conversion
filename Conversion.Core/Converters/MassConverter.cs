using System.Threading.Tasks;
using Conversion.Core.Contracts;

namespace Conversion.Core.Converters
{
    public class MassConverter : IMassConverter
    {
        public Task<decimal> ConvertToKilograms(decimal poundValue)
        {
            var result = poundValue / 2.20462m;
            return Task.FromResult(result);
        }

        public Task<decimal> ConvertToPounds(decimal kilogramValue)
        {
            var result = kilogramValue * 2.20462m;
            return Task.FromResult(result);
        }
    }
}
