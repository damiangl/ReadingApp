using ReadingApp.Infrastructure.Interfaces;
using System.Text.Json;

namespace ReadingApp.AdditionalPropertyProcessor.PGNiGEstimations
{
    public class PGNiGEstimations : IAdditionalPropertyProcessor
    {
        public string GetAdditionalPropertyValue(int id)
        {
            EstimationsDataContainer container = new EstimationsDataContainer();

            String result = JsonSerializer.Serialize(container);

            return result;
        }
    }
}