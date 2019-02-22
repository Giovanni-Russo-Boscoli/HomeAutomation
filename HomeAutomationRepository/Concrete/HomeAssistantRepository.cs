using HomeAutomationModel;
using HomeAutomationRepository.Interface;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace HomeAutomationRepository.Concrete
{
    public class HomeAssistantRepository : IHomeAssistantRepository
    {

        private IConfiguration _configuration;

        public HomeAssistantRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<IConfigurationSection> GetInformationDeviceById(string idDevice)
        {
            return ((_configuration.GetSection(HomeAssistantBase.Prefix_IdDevice).GetSection(idDevice).GetChildren()).AsEnumerable());
        }

    }
}
