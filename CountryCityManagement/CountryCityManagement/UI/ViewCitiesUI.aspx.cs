﻿using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using CountryCityManagement.Business_Logic;
using CountryCityManagement.Models;

namespace CountryCityManagement.UI
{
    public partial class ViewCitiesUI : System.Web.UI.Page
    {
        CityManager manageCity = new CityManager();
        CountryManager manageCountry = new CountryManager();
        private List<CityViewModel> cityViewModels;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCountry();
                LoadALLCityInfo();
            }
            else
            {
                cityViewModels = (List<CityViewModel>)ViewState["Data"];
                showInGrid(cityViewModels);
            }
        }

        private void LoadCountry()
        {
            List<Country> countryList = manageCountry.GetAllDepartment();
            countryDropDownList.DataSource = countryList;
            countryDropDownList.DataTextField = "CountryName";
            countryDropDownList.DataValueField = "CountryID";
            countryDropDownList.DataBind();
            countryDropDownList.Items.Insert(0, new ListItem("Select Country"));
        }
        private void LoadALLCityInfo()
        {
            cityViewModels = manageCity.GetALLCityInfo();
            ViewState["Data"] = cityViewModels;
            showInGrid(cityViewModels);
        }
        private void showInGrid(List<CityViewModel> cityViewModels)
        {
            viewCitiesGridView.DataSource = cityViewModels;
            viewCitiesGridView.DataBind();
        }
        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (cityNameRadioButton.Checked)
            {
                LoadCountry();
                string searchName = serachTextBox.Text;
                double parseSearch;
                if (searchName == string.Empty)
                {
                    messageLabel.Text = "Please give any City Name ";
                }
                else if (double.TryParse(searchName, out parseSearch))
                {
                    messageLabel.Text = "Input is not Valid !!!";
                }
                else
                {
                    messageLabel.Text = "";
                    cityViewModels = manageCity.GetALLCityInfoByName(searchName);
                    if (cityViewModels != null)
                    {
                        ViewState["Data"] = cityViewModels;
                        showInGrid(cityViewModels);
                        serachTextBox.Text = "";
                        messageLabel.Text = "Result of " + searchName;
                    }
                    else
                    {
                        messageLabel.Text = "No Result is found of " + searchName + "City";
                    }
                }
            }
            else if (countryRadioButton.Checked)
            {
                messageLabel.Text = "";
                serachTextBox.Text = string.Empty;

                if (countryDropDownList.SelectedItem.Text == "Select Country")
                {
                    messageLabel.Text = "Please Select any County";
                    LoadCountry();
                }
                else
                {
                    messageLabel.Text = "";
                    string searchCountry = countryDropDownList.SelectedItem.Text;
                    cityViewModels = manageCity.GetALLCityInfoByCountry(searchCountry);
                    if (cityViewModels != null)
                    {
                        ViewState["Data"] = cityViewModels;
                        showInGrid(cityViewModels);
                    }
                    else
                    {
                        messageLabel.Text = "No result is found !!!";
                        viewCitiesGridView.DataSource = null;
                        viewCitiesGridView.DataBind();

                    }
                }

            }

            else
            {
                messageLabel.Text = "Please Select Any Search Category !!!";
            }
        }

        protected void viewCitiesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            viewCitiesGridView.PageIndex = e.NewPageIndex;
            showInGrid(cityViewModels);
        }
    }
}