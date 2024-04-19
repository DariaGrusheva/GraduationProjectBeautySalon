using BeautySalon.Context;
using BeautySalon.Models;

namespace BeautySalon.Services
{
    public interface IAboutUsInfo
    {
        string NameSalon { get; }
        string ContactNumber { get; }
        string WorkSheet { get; }   
        string InstaLink { get; }
        string VkLink { get; }
        string OkLink { get; }
        string AnyLink { get; }
        string Description { get; }
        string Address { get; }
    }
    public class AboutUsInfo : IAboutUsInfo
    {
        private readonly BsContext _context;
        private readonly AboutUs _aboutUsInfo;

        public AboutUsInfo(BsContext context)
        {
            _context = context;
            _aboutUsInfo = _context.AboutUss.FirstOrDefault();
        }

        public string NameSalon => _aboutUsInfo.NameSalon;
        public string ContactNumber => _aboutUsInfo.ContactNumber;
        public string WorkSheet => _aboutUsInfo.Worksheet;
        public string InstaLink => _aboutUsInfo.InstaLink;
        public string VkLink => _aboutUsInfo.VkLink;
        public string OkLink => _aboutUsInfo.OkLink;
        public string AnyLink => _aboutUsInfo.AnyLink;
        public string Description => _aboutUsInfo.Description;
        public string Address => _aboutUsInfo.Address;

    }
}
