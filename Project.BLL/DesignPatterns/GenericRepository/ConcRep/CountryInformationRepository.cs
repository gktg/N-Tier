using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.BLL.DesignPatterns.GenericRepository.IntRep;
using Project.Entities.Models;

namespace Project.BLL.DesignPatterns.GenericRepository.ConcRep
{
    public class CountryInformationRepository : BaseRepository<CountryInformation>
    {
    }
}
