using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CountryCityManagement.Database_Access;
using CountryCityManagement.Models;

namespace CountryCityManagement.Business_Logic
{
    public class CityManager
    {
        CityGateway cityGatewayObj=new CityGateway();
        public List<CityViewModel> GetALLCityInfo()
        {
            List<CityViewModel> cityView = cityGatewayObj.GetAllCityInfo();
            return cityView;
        }

        public List<CityViewModel> GetALLCityInfoByName(string searchName)
        {
            List<CityViewModel> cityView = cityGatewayObj.GetAllCityInfoByName(searchName);
            return cityView;
        }

        public List<CityViewModel> GetALLCityInfoByCountry(string searchCountry)
        {
            List<CityViewModel> cityView = cityGatewayObj.GetAllCityInfoByCountry(searchCountry);
            return cityView;
        }
    }
}