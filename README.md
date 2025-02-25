*# Talking Flight Monitor (TFM)
An accessibility layer for Microsoft FSX and Lockhede Martin Prepar3d.
## downloading
* The latest release build of tfm can be found on the [TFM downloads page](https://www.talkingflightmonitor.com/download/)
* The latest preview release can be found on the [Preview releases page](https://www.talkingflightmonitor.com/preview-releases/)


## features
* reads closest city to the aircraft based on simulator GPS position
* reads many  aircraft instruments and switches automatically
* sonification of key aircraft parameters, such as pitch and bank.
* Sonification of flight director to aide in manual flight
* Reads SimConnect message windows, such as the ones displayed by GSX and Pro ATC/x
* reads Radar Contact ATC menus
* allows control of the aircraft autopilot through a simple interface
* provides many hotkeys for querying aircraft instruments on demand
* Initial support for the PMDG 737 and 747, providing the first fully accessible FMC.


## Requirements
In order to use this software, you will need either [Microsoft Flight Simulator X](https://store.steampowered.com/app/314160/Microsoft_Flight_Simulator_X_Steam_Edition/), or [Lockheed Martin Prepar3d](https://www.prepar3d.com/).

In order to read the nearest city to your aircraft, you will need a free [GeoNames](http://www.geonames.org) account. Once you create the account, enable web access under your profile. 

You will need the latest version of Pete Dowson's [FSUIPC module](http://www.fsuipc.com). If you are using Microsoft FSX, you need version 4. 
Prepar3d requires version 5 or 6. In most cases, you do not need to purchase a registration for Talking Flight Monitor to work. However, if you plan to use TFM with the aircraft from A2A simulations, a registered version of FSUIPC is required.

For the detection of aircraft on ground to work, you will need some files generated by the Makerwys program by Pete Dowson. See the instructions below.

## Quick Start
* Install Talking Flight Monitor by running the installer you downloaded.
* Start your simulator  and start a flight.
* Start Talking Flight Monitor from your desktop.
* The first time it is run, you will be prompted for your Geonames username.
* You should now hear the name of the closest city to your aircraft location.

## configuring the program
Under the Application pull-down menu, select Settings to bring up the settings dialog. You can configure all aspects of Talking Flight Monitor through this dialog. Here is a brief description of each setting.

### General tab
* Geonames username: This is where you can change your Geonames username
* Use SAPI for speech output: Choose to use either SAPI or your screen reader voice
* SAPI speech rate: adjust the rate of SAPI speech. ange is from 1 to 10.
* Enable flight following: enable reading of closest city to your aircraft
* Enable reading of instrumentation: automatically reads various aircraft instruments.
* Read SimConnect messages: automatically reads in-simulator pop-up messages from various add-ons such as gSX, Pro ATC/X, etc.
* Enable GPWS callouts: Ground proximity warning system. provides audible indication of key altitudes when landing.
* Enable ILS: Reads information related to ILS when landing, such as glide slope and localiser.
* Announce groundspeed while on ground: reads groundspeed while taxiing and before takeoff.
* Use metric measurements: Announce distances in Kilometers. Altitudes will always be in feet.
* online flight mode: enable this if you are planning on flying with Vatsim. It controls how nearby aircraft are read.

### Timing tab
Adjusts various timing intervals. Options are self-explanitory.

### Hotkeys
There are several hotkeys for use when Talking Flight Monitor is running. The keys are set up as global, so you don't need to be in the program window to use them. All hotkeys can be changed from this tab.

The keys use a layered aproach. First press the command key, which is Right Square Bracket by default. Then press the desired command. 
The currently available keys are:

* ]: enters command mode (use before all other keys)
* numbers 1 through 0: read info for individual fuel tanks
* shift+numbers 1 through 4: red N1 and N2 values for given engine
* a: read altitude above sea level (ASL).
* shift+a: toggle GPWS (ground proximity warning system) announcements
* b: fuel burn rate (in pounds per hour)
* c: read nearest city
* d: read distance and time to destination
* f: fuel report
* Shift+f: toggle announcement of flap angle
* Ctrl+F: audible flight director (see below)
* g: read  altitude above ground (AGL)
* h: read heading
* Shift+i: toggle reading of ILS info such as localiser and glideslope
* m: mach speed
* Ctrl+m: read pitch and bank angle periodically
* o: read outside ambient temperature
* p: read nearest 5 airborn aircraft
* shift+p: read ground aircraft
* r: read the last SimConnect message displayed.
* shift+r: mute simconnect messages
* s: read indicated airspeed
* t: read true airspeed
* shift+t: toggle announcement of aircraft trim
* v: vertical speed
* w: read next waypoint
* [ (left bracket): audible aircraft attitude indication (see below)
* shift+o: Toggle announcements of autopilot parameters
* i: read wind information
* control+h: toggle runway guidance mode


## audible attitude indications
Flight Following contains four modes that allow you to hear the pitch and bank of your aircraft.

### attitude mode
In "Attitude mode", you will hear a constant tone in the center channel to indicate pitch. Pitch down and pitch up are represented by slightly different sounding tones. The higher the tone, the higher your aircraft pitch.
Bank is represented by a beeping tone in either the right or left stereo channel to indicate the direction of bank. The higher the tone, the higher your bank angle.


### runway guidance mode
Runway guidance mode is designed to help you hold a constant heading on takeoff or landing. When you turn on runway guidance, the current heading of your aircraft is recorded. You will then hear tones in the left or right stereo channel to let you know if you are going off course.

## aircraft proximity system
TFM now has the ability to read the nearest aircraft to your position. This works with both AI generated and online aircraft using systems such as Vatsim.

In order for these facilities to work, you will need some files which are generated by Pete Dowson's [Makerwys program](http://fsuipc.simflight.com/beta/MakeRwys.zip). 

1. Download the zip file and extract it.
2. Copy the makerwys.exe file to the root folder of your flight simulator.
3. Run the makerwys program as administrator. It will take some time to complete.
TFM will detect these files and generate an airport database when it starts.

You can press right bracket, p, to get a list of the nearest airborn aircraft. Pressing right bracket, shift+p, will give you a list of ground aircraft at your current airport.

Note that when at a new airport, it will take around 10 seconds to locate your current airport. Subsequent use of the ground traffic command at the same airport won't have this delay.

## controling autopilot and radios
The Talking Flight Monitor window contains several edit fields that allow you to control the aircraft's autopilot and com radios directly. To change a setting, just type the value you want into the edit box and press Enter.

## experimental A2A aircraft support
TFM now contains experimental support for the payware aircraft from A2A Simulations. Currently, the Beachcraft Bonanza, Cesna C172, Cesna C182 Skylane and the Piper Cherokee have initial support. Given how these aircraft are designed, it is possible to add much more support in the future!
Currently, you are able to check various aircraft instruments, as well as control a few aircraft systems.

### enabling A2A support
The A2A aircraft support requires a registered (payed) version of FSUIPC. Additionally, the A2A aircraft is not fully functional using FSX at this point, due to changes between FSUIPC 4 and FSUIPC 6.
Note that this process has changed. If you used the A2A aircraft support in an older version of TFM, it is probably just easiest to remove your fsuipc6.ini file so it will be re-generated the next time you run the simulator.

In your TFM install folder, there is a folder called "scripts". Copy all files from  this folder into your FSUIPC folder. For FSUIPC version 5, this should be 
``` C:\program files\Lockheed Martin\Prepar3D v4\Modules 
```
For FSUIPC 6, the folder is at:
```C:\Users\<your_user>\Documents\Prepar3D v4 Add-ons\FSUIPC6```

### hotkeys for reading A2A specific info
When TFM detects you are running a supported A2A aircraft, the following hotkeys will be enabled. These also follow a similar layered command mode as the rest of TFM. The command key is the left square bracket. 
Note that these keys are not part of the TFM settings dialog yet. The dialog will be updated once the A2A support is finalized. For now, the keys can be changed by editing the tfm.ini file.

* [: command key
* 1: engine cylinder head temperature
* 2: engine exhaust gas temperature
* 3: engine RPM
* 4: oil temperature
* 5: oil pressure
* 6: manifold pressure
* 7: Ammeter
* 8: volt meter
* f: fuel tank levels
* shift+f: fuel flow
* l: read annunciator lights (Cesna C172 and C182)
* t: read cabin temperature

### keys for controlling aircraft systems
The following keys are only available while in the simulator window. They use the tab key as a modifier, meaning you need to hold down the tab key for each of these keys to work. This does not affect the tab key when using dialogs inside the sim.

* tab+a: toggle air circulation fan (bonanza only)
* tab+c: increase carburetor heat (Piper Cherokee only). Also toggles fuel cutoff on C172.
* shift+tab+c: decrease carburetor heat (Piper Cherokee only)
* tab+d: increasse windshield defrost (all aircraft)
* shift+tab+d: decrease windshield defrost (all aircraft)
* tab+f: fuel selector (all aircraft)
* tab+h: increase cabin heat (all aircraft)
* shift+tab+h: decrease cabin heat (all aircraft)
* tab+l: left tip tank pump switch (Bonanza only)
* tab+p: primer pump open and pump (Cherokee only)
* shift+tab+p: primer close (cherokee only)
* tab+r: right tip tank pump switch (Bonanza only)
* tab+s: adjust fan speed (Bonanza only and not sure if working as expected yet)
* tab+w: open/close window (all aircraft)

### aircraft checklists
In your TFM install folder, you will find a folder called "checklists". This folder contains the checklists for the A2A aircraft. These have been taken directly from the Clipboard panel in the aircraft. For now, there is not a way of accessing the checklists directly from TFM. This is a work in progress.

### Fuel and Payload dialog
TFM now includes a Fuel and Payload dialog for supported A2A aircraft. You will find this feature under the Aircraft menu in TFM. The fuel tab allows you to adjust fuel levels in the various fuel tanks, as well as fill the oil.

The Payload tab lets you add or remove passengers. Note that it is not currently possible to remove the pilot.

## Running from Source

## Building a Binary Version

## Generating HTML Documentation
To generate HTML documentation, install [Pandoc](https://github.com/jgm/pandoc/releases) for your platform, either using the MSI installer (recommended) or the ZIP archive. Once Pandoc is installed, run the following:
```
pandoc readme.md -s -o tfm.html
```

## Building the Installer
To build the installer, [InnoSetup](https://www.jrsoftware.org/isinfo.php) needs to be installed. Be sure to add the path to InnoSetup to your PATH environment variable. Once this is done, and a binary version has been built (see above), run:
```
iscc tfm.iss
```
The installer will be built and placed in the tfm/ subdirectory.

## Bugs and issues
* Please report bugs via the github issues tab.
* It is useful to attach the error.log file to any issues.
    
### Known limitations
* The city given does not take into account the heading of your aircraft. So, the nearest city may be behind you.
* Offline access is not implemented yet. It may be added in the future.

## donating
I started working on Talking Flight Monitor in May of 2019. At that time, all it did was provide nearest city information to your aircraft. we have certainly come a long way since then!
Talking Flight Monitor is and will continue to be free and open source. However, I have now started to work on providing support for commercial (payware) aircraft. This requires me to purchase any aircraft that I add support for. If you feel that TFM is useful and enhances your flight simming experience, I invite you to make a donation via Paypal. There is absolutely no obligation. 

[Make a donation via Paypal](https://www.paypal.me/jfayre)



## contributors and credits
* Thanks to Tyler Rodick for his assistance with this project. This is my first major coding project, and it's helpful to have someone fixing my occasional oversight.



