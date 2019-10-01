using HomeAutomationModel;
using HomeAutomationRepository.Interface;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using System;
using System.Text;
using HomeAutomationModel.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HomeAutomationRepository.Concrete
{
    public class HomeAssistantRepository : IHomeAssistantRepository
    {
        //private readonly HomeAutomationContext _context;
        private IConfiguration _configuration;
        private readonly HomeAutomationContext _context;

        //public HomeAssistantRepository(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public HomeAssistantRepository(HomeAutomationContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IEnumerable<IConfigurationSection> GetInformationDeviceById(string idDevice)
        {
            //testeConnection();
            return ((_configuration.GetSection(HomeAssistantBase.Prefix_IdDevice).GetSection(idDevice).GetChildren()).AsEnumerable());
        }

        

        public void testeConnection()
        {
            //var a = _context.Area.Where(x => x.Area_Id == 1);
            var A = _context.TypeDevice.Where(x => x.Type_Id == 1);
            var b = _context.Area.Where(x => x.Area_Id == 1);
            var d = _context.Action.Include(a => a.TypeDevice).Where(x => x.Action_Id == 1);
            var e = _context.State.Include(a => a.TypeDevice).Where(x => x.State_Id == 1);
            var f = _context.ModelDevice.Where(x => x.ModelDevice_Id == 1);
            var g = _context.Device.Include(x => x.ModelDevice).Include(x => x.Area).Where(x => x.Device_Id == 1);
            var h = _context.DeviceChannelDetail
                .Include(x => x.TypeDevice)
                .Include(x => x.Action)
                .Include(x => x.State)
                .Include(x => x.Device)
                .Where(x => x.DeviceChannelDetail_Id == 1);
            var c = "";

            //var _homeAutomationConnection = _configuration.GetConnectionString("HomeAutomationConnection");
            //NpgsqlConnection conn = new NpgsqlConnection(_homeAutomationConnection);// "Server=localhost;User Id=postgres;Password=postgres;Database=homeautomation;");
            //conn.Open();

            //NpgsqlCommand cmd = new NpgsqlCommand("select * from type", conn);



            //// Execute a query
            //NpgsqlDataReader dr = cmd.ExecuteReader();

            //StringBuilder str = new StringBuilder();

            //// Read all rows and output the first column in each row
            //if (dr.HasRows)
            //{
            //    while (dr.Read())
            //    {
            //       str.Append(dr["description"].ToString());
            //    }
            //    dr.Close();
            //}

            //// Close connection
            //conn.Close();
        }

    }
}
