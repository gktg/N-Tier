using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Project.Entities.Models;
using Project.DTOs.DTOModels;
using System.Net;
using Newtonsoft.Json;
using Project.Web.Models;
using Project.BLL.DesignPatterns.GenericRepository.ConcRep;

namespace Project.Web.Controllers
{
    public class CountryController : Controller
    {
        CountryInformationRepository _countryInformationRepository;

        public CountryController()
        {
            _countryInformationRepository = new CountryInformationRepository();
        }

        public ActionResult Country()
        {
            return View();
        }

        /// <summary>
        /// Gets the countries informations from API
        /// </summary>
        /// <returns>List of countries</returns>
        [Route("/Country/GetCountries/")]
        public ActionResult GetCountries()
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44336/";
                    string data = webClient.DownloadString("GetCountries");
                    List<CountryDTO> countryDTOList = JsonConvert.DeserializeObject<List<CountryDTO>>(data);

                    List<CountryVM> countryVMList = new List<CountryVM>();

                    foreach (var countryDTO in countryDTOList)
                    {
                        CountryVM countryVm = new CountryVM()
                        {
                            CountryName = countryDTO.CountryName,
                        };
                        countryVMList.Add(countryVm);
                    }


                    return Json(countryVMList, JsonRequestBehavior.AllowGet);
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// With country name, gets country informations(ISO code, capital and currency)
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns>CountryVM</returns>
        [Route("/Country/GetCountryInformationWithCountryName")]
        public ActionResult GetCountryInformationWithCountryName(string countryName)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44336/";
                    string data = webClient.DownloadString("GetCountryInformationWithCountryName/" + countryName);
                    CountryDTO countryDTO = JsonConvert.DeserializeObject<CountryDTO>(data);


                    CountryVM countryVm = new CountryVM()
                    {
                        CountryName = countryDTO.CountryName,
                        CountryCapital = countryDTO.CountryCapital,
                        CountryISOCode = countryDTO.CountryISOCode,
                        CountryCurrency = countryDTO.CountryCurrency,
                    };


                    return Json(countryVm,JsonRequestBehavior.AllowGet);
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Saves the selected country information to DB
        /// </summary>
        /// <param name="country"></param>
        /// <returns>true or false</returns>
        [Route("/Country/CountrySave")]
        public ActionResult CountrySave(CountryVM country)
        {
            try
            {
                CountryInformation countryInformation = new CountryInformation()
                {
                    CountryName = country.CountryName,
                    CountryCapital = country.CountryCapital,
                    CountryISOCode = country.CountryISOCode,
                    CountryCurrency = country.CountryCurrency,
                };

                _countryInformationRepository.Add(countryInformation);

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }



        }
    }
}