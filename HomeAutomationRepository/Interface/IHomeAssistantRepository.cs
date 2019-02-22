using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAutomationRepository.Interface
{
    public interface IHomeAssistantRepository
    {
        IEnumerable<IConfigurationSection> GetInformationDeviceById(string idDevice);
    }
}
