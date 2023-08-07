namespace FhirClientDemo_Blazor.Services
{
    public class NotifyStateService
    {
        public event EventHandler? EventClick;

        public void NotifyEventClick(object sender)
        {
            if (this.EventClick != null)
                this.EventClick(sender, EventArgs.Empty);
        }
    }
}
