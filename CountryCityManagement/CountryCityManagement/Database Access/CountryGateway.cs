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
    public class CountryGateway
    {
        private static string connectionString = WebConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        public List<CountryViewModel> GetALLCountryView()
        {
            int count = 0;
            string query = "Select * from GetCountryInfo";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<CountryViewModel> countryView = new List<CountryViewModel>();
            while (reader.Read())
            {
                count = count + 1;
                CountryViewModel countryViewModelObj = new CountryViewModel();
                countryViewModelObj.SL = count;
                countryViewModelObj.Name = reader["Name"].ToString();
                byte[] binaryString = (byte[])(reader["About"]);
                countryViewModelObj.About = Encoding.UTF8.GetString(binaryString);
                //countryViewModelObj.About = reader["About"].ToString();
                countryViewModelObj.NoOfCities = Convert.ToInt32(reader["No Of Cities"].ToString());
                countryViewModelObj.NoOfCityDwellers = Convert.ToInt32(reader["No Of City Dwellers"].ToString());

                countryView.Add(countryViewModelObj);
            }
            connection.Close();
            return countryView;
        }

        public List<CountryViewModel> GetALLCountryViewByName(string searchName)
        {
            int count = 0;
            string query = "Select * from GetCountryInfo where Name LIKE '%[" + searchName + "]%' ";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<CountryViewModel> countryView = new List<CountryViewModel>();
            while (reader.Read())
            {
                count = count + 1;
                CountryViewModel countryViewModelObj = new CountryViewModel();
                countryViewModelObj.SL = count;
                countryViewModelObj.Name = reader["Name"].ToString();

                byte[] binaryString = (byte[])(reader["About"]);
                countryViewModelObj.About = Encoding.UTF8.GetString(binaryString);

                //countryViewModelObj.About = reader["About"].ToString();
                countryViewModelObj.NoOfCities = Convert.ToInt32(reader["No Of Cities"].ToString());
                countryViewModelObj.NoOfCityDwellers = Convert.ToInt32(reader["No Of City Dwellers"].ToString());

                countryView.Add(countryViewModelObj);
            }
            connection.Close();
            int datacount = countryView.Count;
            if (datacount == 0)
            {
                return null;
            }
            return countryView;
        }

        public List<Country> GetAllCounty()
        {
            string query = "SELECT * FROM Country ";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Country> countryList = new List<Country>();

            while (reader.Read())
            {
                Country countryObj = new Country();
                countryObj.CountryID = Convert.ToInt32(reader["CountryID"].ToString());
                countryObj.CountryName = reader["CountryName"].ToString();

                countryList.Add(countryObj);
            }
            connection.Close();
            return countryList;
        }
    }
}