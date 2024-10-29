#!/bin/bash

#https://developer.apple.com/documentation/security/notarizing_macos_software_before_distribution/customizing_the_notarization_workflow

echo '---------Building App - MUST RUN FROM SOLUTION FOLDER'

#dotate publish -f net8.0-maccatalyst
dotnet build ./MauiApp1/MauiApp1.csproj -f net8.0-maccatalyst -c Release

echo '---------Registering app with Gatekeeper'

rm -r -f ./MacBuild/MauiApp1.app
rm -f ./MacBuild/MauiApp1.zip
rm -f ./MacBuild/MauiApp1.app.zip

cp -R ./MauiApp1/bin/Release/net8.0-maccatalyst/maccatalyst-x64/MauiApp1.app ./MacBuild/MauiApp1.app

#compress to zip file
/usr/bin/ditto -c -k --keepParent ./MacBuild/MauiApp1.app ./MacBuild/MauiApp1.zip

xcrun notarytool submit "./MacBuild/MauiApp1.zip" --wait --keychain-profile "RoastPATH-Mac"

xcrun stapler staple ./MacBuild/MauiApp1.app 

#xcrun notarytool log --keychain-profile "RoastPATH-Mac" 420f68b4-35c0-4117-98af-dd7615b502c1

echo '---------Cleanup Gatekeeper Zip - Create Distribution Zip'

rm -f MacBuild/MauiApp1.zip

/usr/bin/ditto -c -k --keepParent ./MacBuild/MauiApp1.app ./MacBuild/MauiApp1.app.zip

# xcrun notarytool log --keychain-profile "RoastPATH-Mac" ce7b794f-8b0b-4163-9e14-d73e93367d58
