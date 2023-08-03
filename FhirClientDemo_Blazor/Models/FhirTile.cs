using System.Diagnostics;
using System.Text.RegularExpressions;
using FhirClientDemo_Blazor.Components;
using FhirClientDemo_Blazor.Data;

namespace FhirClientDemo_Blazor.Models
{
    // Arrays containing tiles for Dashboard
    public class FhirTile
    {
        public string SpinnerVisible { get; set; }
        public string ResourceType { get; set; }
        public string ResourceDisplayName { get; set; }
        public string GroupName { get; set; }
        public int StatNumber { get; set; }
        public string Icon { get; set; }

        FhirDashboardTile FhirDashboardTileComp;

        public FhirTile(string resourceType, string groupName, int statNum, string icon)
        {
            ResourceType = resourceType;
            GroupName = groupName;
            StatNumber = statNum;
            Icon = icon;
            SpinnerVisible = "none";

            ResourceDisplayName = Regex.Replace(resourceType, "(\\B[A-Z])", " $1");
            Debug.Print($"ResourceDisplayName = {ResourceDisplayName}");
        }

        public void Refresh()
        {
            
            
        }
    }
}
