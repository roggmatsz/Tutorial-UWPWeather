using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Tutorial_UWPWeather {
    public class LocationManager {
        public async static Task<Geoposition> GetPosition() {
            //request the user's permission to access his/her location
            var accessStatus = await Geolocator.RequestAccessAsync();

            //for the sake of testing purposes, keep it simple and just crash the app if 
            //permission is not granted.
            if (accessStatus != GeolocationAccessStatus.Allowed) throw new Exception();

            //get an instance of Geolocator and specify the desired accuracy.
            var geolocator = new Geolocator { DesiredAccuracyInMeters = 0 };

            //get and return the user's location
            var position = await geolocator.GetGeopositionAsync();
            return position;
        }
    }
}
