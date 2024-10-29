#!/bin/bash

#--- This script must be executed from the project folder (where the .csproj file is located for mac)
echo '---------Adding Symbolic Link to Phidget Framework'

ln -s bin/Release/net8.0-maccatalyst/maccatalyst-x64/MauiApp1.app/Contents/Frameworks/Phidget22.framework bin/Release/net8.0-maccatalyst/maccatalyst-x64/MauiApp1.app/Contents/MonoBundle/libphidget22.dylib

echo '---------Symlink Added'




