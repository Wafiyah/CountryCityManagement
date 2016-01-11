using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using CountryCityManagement.Models;

namespace CountryCityManagement.Database_Access
{
    public class CityGateway
    {
        private static string connectionString = WebConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        public List<CityViewModel> GetAllCityInfo()
        {
            int count = 0;
            string query = "SELECT * FROM GetCityInfo";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<CityViewModel> cityView = new List<CityViewModel>();

            while (reader.Read())
            {
                count = count + 1;
                CityViewModel cityViewModelObj = new CityViewModel();
                cityViewModelObj.SL = count;
                cityViewModelObj.CityName = reader["Name"].ToString();

                byte[] cityAboutBinaryString = (byte[])(reader["About"]);
                cityViewModelObj.AboutCity = Encoding.UTF8.GetString(cityAboutBinaryString);
                //cityViewModelObj.AboutCity = reader["About"].ToString();

                cityViewModelObj.NoOfDwellers = Convert.ToDouble(reader["No. of dwellers"].ToString());
                cityViewModelObj.Location = reader["Location"].ToString();
                cityViewModelObj.Weather = reader["Weather"].ToString();
                cityViewModelObj.CountryName = reader["Country"].ToString();

                byte[] countryAboutBinaryString = (byte[])(reader["About Country"]);
                cityViewModelObj.AboutCountry = Encoding.UTF8.GetString(countryAboutBinaryString);
                //cityViewModelObj.AboutCountry = reader["About Country"].ToString();

                cityView.Add(cityViewModelObj);
            }

            connection.Close();
            return cityView;
        }

        public List<CityViewModel> GetAllCityInfoByName(string searchName)
        {
            int count = 0;
            string query = "SELECT * FROM GetCityInfo where Name Like'%["+searchName+"]%'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<CityViewModel> cityView = new List<CityViewModel>();

            while (reader.Read())
            {
                count = count + 1;
                CityViewModel cityViewModelObj = new CityViewModel();
                cityViewModelObj.SL = count;
                cityViewModelObj.CityName = reader["Name"].ToString();

                byte[] cityAboutBinaryString = (byte[])(reader["About"]);
                cityViewModelObj.AboutCity = Encoding.UTF8.GetString(cityAboutBinaryString);
                //cityViewModelObj.AboutCity = reader["About"].ToString();

                cityViewModelObj.NoOfDwellers = Convert.ToDouble(reader["No. of dwellers"].ToString());
                cityViewModelObj.Location = reader["Location"].ToString();
                cityViewModelObj.Weather = reader["Weather"].ToString();
                cityViewModelObj.CountryName = reader["Country"].ToString();

                byte[] countryAboutBinaryString = (byte[])(reader["About Country"]);
                cityViewModelObj.AboutCountry = Encoding.UTF8.GetString(countryAboutBinaryString);
                //cityViewModelObj.AboutCountry = reader["About Country"].ToString();

                cityView.Add(cityViewModelObj);
            }
            connection.Close();
            int dataCount = cityView.Count;
            if (dataCount == 0)
            {
                return null;
            }
            return cityView;

        }

        public List<CityViewModel> GetAllCityInfoByCountry(string searchCountry)
        {
            int count = 0;
            string query = "SELECT * FROM GetCityInfo where Country Like'%" + searchCountry + "%'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<CityViewModel> cityView = new List<CityViewModel>();

            while (reader.Read())
            {
                count = count + 1;
                CityViewModel cityViewModelObj = new CityViewModel();
                cityViewModelObj.SL = count;
                cityViewModelObj.CityName = reader["Name"].ToString();

                byte[] cityAboutBinaryString = (byte[])(reader["About"]);
                cityViewModelObj.AboutCity = Encoding.UTF8.GetString(cityAboutBinaryString);
                //cityViewModelObj.AboutCity = reader["About"].ToString();

                cityViewModelObj.NoOfDwellers = Convert.ToDouble(reader["No. of dwellers"].ToString());
                cityViewModelObj.Location = reader["Location"].ToString();
                cityViewModelObj.Weather = reader["Weather"].ToString();
                cityViewModelObj.CountryName = reader["Country"].ToString();

                byte[] countryAboutBinaryString = (byte[])(reader["About Country"]);
                cityViewModelObj.AboutCountry = Encoding.UTF8.GetString(countryAboutBinaryString);
                //cityViewModelObj.AboutCountry = reader["About Country"].ToString();

                cityView.Add(cityViewModelObj);
            }
            connection.Close();
            int countryCount = cityView.Count;
            if (countryCount != 0)
            {
                return cityView;
            }
          return null;
        }
    }
}