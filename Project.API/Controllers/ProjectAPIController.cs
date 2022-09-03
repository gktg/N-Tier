using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project.API.AcerProSoapApi;
using Project.DTOs.DTOModels;


namespace Project.API.Controllers
{
    public class ProjectAPIController : ApiController
    {

        [Route("GetCountries")]
        [HttpGet]
        public List<CountryDTO> GetCountries()
        {
            CountryInfoServiceSoapTypeClient client = new CountryInfoServiceSoapTypeClient("CountryInfoServiceSoap");

            tCountryCodeAndName[] countries = client.ListOfCountryNamesByCode();

            List<CountryDTO> countriesDTOList = new List<CountryDTO>();

            foreach (var country in countries)
            {
                CountryDTO countryDTO = new CountryDTO();
                countryDTO.CountryName = country.sName;

                countriesDTOList.Add(countryDTO);
            }

            return countriesDTOList;
        }  


        [Route("GetCountryInformationWithCountryName/{countryName}")]
        [HttpGet]
        public CountryDTO GetCountryInformationWithCountryName(string countryName)
        {
            CountryInfoServiceSoapTypeClient client = new CountryInfoServiceSoapTypeClient("CountryInfoServiceSoap");

            string countryISOCode = client.CountryISOCode(countryName);

            string countryCapitalCity = client.CapitalCity(countryISOCode);

            tCurrency countryCountryCurrency = client.CountryCurrency(countryISOCode);

            CountryDTO countryDTO = new CountryDTO();

            countryDTO.CountryName = countryName;
            countryDTO.CountryCapital = countryCapitalCity;
            countryDTO.CountryISOCode = countryISOCode;
            countryDTO.CountryCurrency = $"{countryCountryCurrency.sISOCode}({countryCountryCurrency.sName})";




            return countryDTO;
        }




    }
}
