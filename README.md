# Tutorial-UWPWeather
A simple weather app, based on a video tutorial from Channel9: https://channel9.msdn.com/Series/Windows-10-development-for-absolute-beginners/UWP-057-UWP-Weather--Introduction

Even though I consider myself a Mac guy, I find myself absolutely enthralled by the work Microsoft has done with the UWP platform; 
I don't think I have ever been as excited about a MS technology as I am for UWP. This is, thus, an exercise to gain development
experience with the platform.

## App Description
UWPWeather is a simple weather app. First, it retrieves the user's geolocation from the device's `Geolocator` class. Then, it 
uses the coordinates to make a `GET` request to OpenWeatherMaps.org's API. The returned JSON is parsed using .NET's 
`DataContractSerializer` class, along with `DataContract` annotations to the class model. The weather information is then displayed
XAML elements declared in the app's `MainPage.xaml`. 

In addition to fetching the current weather upon startup, the app also sets up the ability to periodically fetch weather updates 
from a server and display the information as a Live Tile. Using the platform's `TileUpdateManager` class, the app fetches XAML 
markup every half hour from http://livetileservice1462.azurewebsites.net, a custom ASP.NET MVC server I made
(source code [here](https://github.com/roggmatsz/LiveTileService)). For whatever reason, however, the Live Tile is not updating
as of 09/16/2016. 

## Installation
If you wanna check it out (you're really not missing out on much, but who am I to stop you) you can:

1. Clone this repository.
2. Open `Tutorial-UWPWeather.sln` on Visual Studio 2015+.
3. Assuming you have installed the Windows 10 SDKs, press `CTRL + F5` to compile and run the app.

Alternatively, if you "ain't got time fo' dat," you can also:

1. Download the zip of the packaged, sideloadable version [here](https://1drv.ms/u/s!ArkU09AdDjt8wVSPdPeVGH9wxo42).
2. Extract the zip's contents and double-click on `Add-AppDevPackage` PowerShell script.
3. Follow the directions and voila! 

## Next Steps
I will leave the app as it is for now. As I learn more about UWP, I plan to come back to it and extend it accordingly until it
becomes a nice, publishable app. On the bucket list:

1. A proper, less flaming-hot-pink user interface.
2. 3, 5, and 7-day forecast "Views."
3. Xbox and Windows ~~Phone~~ Mobile capable.
4. Adapt whatever cool platform features I think might be suitable for a weather app.

**Thanks for reading!**
