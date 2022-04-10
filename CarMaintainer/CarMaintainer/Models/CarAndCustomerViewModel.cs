using CarMaintainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMaintainer.Models
{
    public class CarAndCustomerViewModel
    {
        public ApplicationUser UserObj { get; set; }
        //customer might have many cars thats why we create this
        public IEnumerable<Car> Cars { get; set; }
    }
}
