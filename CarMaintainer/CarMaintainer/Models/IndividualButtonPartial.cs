﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaintainer.Models
{
    public class IndividualButtonPartial
    {
        //button type
        public string ButtonType { get; set; }
        public string Action { get; set; }
        public string Glyph { get; set; }
        public string Text { get; set; }

        public string CustomerId { get; set; }
        //nullable int
        public int? ServiceId { get; set; }
        public int? CarId { get; set; }
        //properties to pass to _individualButtonPartial
        public string ActionParameters
        {
            get
            {
                var param = new StringBuilder(@"/");
                if (ServiceId != 0 && ServiceId != null)
                {
                    param.Append(String.Format("{0}", ServiceId));
                }
                if (CustomerId != null && CustomerId.Length > 0)
                {
                    //if true append customer id
                    param.Append(String.Format("{0}", CustomerId));
                }
                if (CarId != 0 && CarId != null)
                {
                    param.Append(String.Format("{0}", CarId));
                }
                return param.ToString().Substring(0, param.Length);
            }
        }
    }
}
