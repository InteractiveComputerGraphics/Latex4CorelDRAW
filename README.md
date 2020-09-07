# Latex4CorelDRAW

This is a addon for CorelDRAW. It allows to add and edit Latex equations or symbols easily. The addon is based on ScintillaNET and supports syntax highlighting, code snippets etc.

The library was tested on Windows 10, CorelDRAW x8. 

**Author**: [Jan Bender](http://www.interactive-graphics.de), **License**: MIT

## Build Instructions

The included project file was made with Visual Studio 2015. You have to adapt the path of CorelDRAW in the project file Latex4CorelDraw.csproj if your CorelDRAW installation differs from `C:\Program Files\Corel\CorelDRAW Graphics Suite X8`.

Remember to build the Release version not the Debug version.

The build process was also successfully completed with Viusal Studio 2019 Community Edition.

## Installation

1. Download the latest release and extract the zip into C:\Program Files\Corel\CorelDRAW Graphics Suite X8\Programs64\Addons\Latex4CorelDraw to install the addon.
2. Right-click and open "Properties" for each DLL file in the folder. If you see the following text, you have to unblock the file:
"Security: This file came from another computer and might be blocked to help protect this computer."
3. Activate docker window "Latex" in the menu "Windows".
4. If you have a better solution for step 2, write me an email ;-)

## Screenshots

<img src="screenshots/screenshot1.jpg" width="320">

## Write Access to the Addons Folder

The build procedure copies the files to the final addon foler destination.
Some installations would not allow Visual Studio to write to this folder if the code is built with user privelages (writing requires admin rights).  The (not so nice way) around this is to create the `Latex4CorelDraw` folder in 
`C:\Program Files\Corel\CorelDRAW Graphics Suite XXXX\Programs64\Addons\` and then to set the access rights to this folder such that users can have full rights access to the folder. With these rights, the VS build procedure can write to the folder.

Alternatively build the addon and then manually copy the following files:
`AppUI.xslt`,
`CorelDrw.addon`,
`Latex4CorelDraw.dll`,
`list.txt`,
`SciLexer.dll`,
`SciLexer64.dll`,
`ScintillaNET.dll`,
`ScintillaNET.xml`,
`UserUI.xslt`.

