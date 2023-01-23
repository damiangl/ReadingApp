using ReadingApp.Infrastructure.Entities;
using ReadingApp.Infrastructure.Interfaces;
using System.Reflection;

namespace ReadingApp.WebAPI.Helpers
{
    public class AdditionalPropertyProcessorHandler
    {
        public static string? GetAdditionalPropertyProcessorValue(Reading reading)
        {
            String? assembly = reading.AdditionalPropertyProcessor;
            if (String.IsNullOrEmpty(assembly))
                return null;
            String returnValue = String.Empty;
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (path == null)
                    return null;
                var asmPath = Path.Combine(path, $"ReadingApp.AdditionalPropertyProcessor.{assembly}.dll");
                Assembly asmObj = Assembly.LoadFrom(asmPath);
                Type asmObjType = asmObj.GetType($"ReadingApp.AdditionalPropertyProcessor.{assembly}.{assembly}");
                MethodInfo method = asmObjType.GetMethod("GetAdditionalPropertyValue");
                object myInstance = Activator.CreateInstance(asmObjType);
                if (myInstance is IAdditionalPropertyProcessor)
                {
                    returnValue = ((IAdditionalPropertyProcessor)myInstance).GetAdditionalPropertyValue(reading.Id);
                }
                else
                {
                    throw new Exception("");
                }
            }
            catch (Exception ex)
            {
            }
            return returnValue;
        }
    }
}
