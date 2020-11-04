using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.Models.Model
{
    public class MapMarkerModel
    {
        public MapMarkerModel()
        {

        }
        public MapMarkerModel(string lat, string lng, string infoTitle, string infoBody)
        {
            this.lat = lat;
            this.lng = lng;
            this.infoTitle = infoTitle;
            this.infoBody = infoBody;
        }
        public string lat { get; set; }
        public string lng { get; set; }
        public string infoTitle { get; set; }
        public string infoBody { get; set; }

    }
}
