using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class GoogleChartManager:IGoogleChartService
    {
        private IGoogleChartDal _chart;

        public GoogleChartManager(IGoogleChartDal chart)
        {
            _chart = chart;
        }

        public List<GoogleChart> AllGetList()
        {
            return _chart.List();
        }
    }
}
