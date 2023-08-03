using System.Diagnostics;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace FhirClientDemo_Blazor.Data
{
    public class FhirUtil
    {
        public static FhirClient client = new FhirClient("https://server.fire.ly/r4");

        public FhirUtil() {
            
            var settings = new FhirClientSettings
            {
                Timeout = 0,
                PreferredFormat = ResourceFormat.Json,
                VerifyFhirVersion = true,
                UseFormatParameter = true,
                ReturnPreference = ReturnPreference.Minimal             
            };
            //var client = new FhirClient("http://server.fire.ly", settings);
            //client = new FhirClient("http://localhost:52773/csp/healthshare/fhirserveriris/fhir/r4");

        }

        public static async Task<int> CountResources(string resourceType)
        {
            try
            {
                Bundle? results = await System.Threading.Tasks.Task.Run(() => client.SearchAsync(summary: SummaryType.True, pageSize: 1, resource: resourceType) );
                return results.Total.GetValueOrDefault();
            }
            catch (Hl7.Fhir.ElementModel.StructuralTypeException e) 
            {
                return - 1;
            }
            
        }
    }
}
