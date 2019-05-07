# imis-vcu
Project Repo for the VCU Meteorite Imaging System team

A visual C# project to guide users through the steps of photographing a meteorite sample, 
and to control the camera in the imaging system.

This project uses the Digicam Library for camera control https://github.com/dukus/digiCamControl

It was orignially intended to run on the Raspberry Pi using the MONO framework https://www.mono-project.com/
The UI is built with windows forms to allow compatability with MONO

The Project does not currently run on the Pi because of issues porting the Digicam Cameracontrol-Devices 
library to run on MONO

