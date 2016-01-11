
using System.Collections.Generic;
using CountryCityManagement.Database_Access;
using CountryCityManagement.Models;

namespace CountryCityManagement.Business_Logic
{
    public class CountryManager
    {
        CountryGateway countryGatewayObj = new CountryGateway();
        public List<CountryViewModel> GetALLCountryView()
        {
            List<CountryViewModel> countryView = countryGatewayObj.GetALLCountryView();
            return countryView;
        }

        public List<CountryViewModel> GetALLCountryViewByName(string searchName)
        {
            List<CountryViewModel> countryView = countryGatewayObj.GetALLCountryViewByName(searchName);
            return countryView;
        }

        public List<Country> GetAllDepartment()
        {
            List<Country> countryList = countryGatewayObj.GetAllCounty();
            return countryList;
        }
    }
}