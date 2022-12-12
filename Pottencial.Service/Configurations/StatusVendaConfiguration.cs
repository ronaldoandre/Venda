namespace Pottencial.Service.Configurations
{
    public class StatusVendaConfiguration
    {
        public StatusVendaConfiguration(int i, string d)
        {
            Id = i;
            Description = d;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}