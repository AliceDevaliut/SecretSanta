using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CreateEvent
{
    public class GetEventResponse
    {
        public GetEventResponse(string name, DateTime startDate, DateTime finishDate)
        {
            Name = name;
            StartDate = startDate;
            FinishDate = finishDate;
        }

        public string Name { get; set; }
                
        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }
    }
}
