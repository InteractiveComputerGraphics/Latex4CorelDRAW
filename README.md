# Latex4CorelDRAW

This is a addon for CorelDRAW. It allows to add and edit Latex equations or symbols easily. The addon is based on ScintillaNET and supports syntax highlighting, code snippets etc.

The library was tested on Windows 10, CorelDRAW x8. 

**Author**: [Jan Bender](http://www.interactive-graphics.de), **License**: MIT

**Modified** Updated (hardcoded) for CorelDraw 2020 and VS2019 by CJ Willers

## Screenshots

<img src="screenshots/screenshot1.jpg" width="320">

## Building the binary files

1. [JB] Jan Bender's original files were set up for Visual Studio 2015 and CorelDraw X8. You have to adapt the path of CorelDRAW in the project file `Latex4CorelDraw.csproj` if your CorelDRAW installation differs from `C:\Program Files\Corel\CorelDRAW Graphics Suite X8`.

1. [JB] Jan Bender's original  build procedure copies the files to the final addon folder destination.
Some installations would not allow Visual Studio to write to this folder if the code is built with user privileges (writing requires admin rights).  The (not so nice way) around this is to create the `Latex4CorelDraw` folder in 
`C:\Program Files\Corel\CorelDRAW Graphics Suite XXXX\Programs64\Addons\` and then to set the access rights to this folder such that users can have full rights access to the folder. With these rights, the VS build procedure can write to the folder.


1. [CJW] The build process was also successfully completed with Visual Studio 2019 Community Edition and with `Latex4CorelDraw.csproj` changed to the CorelDraw 2020 paths.  

1. [CJW] The automatic installation procedure in Bender's project did not work for me, so I copied the files by hand to a new folder.
Everything you need should be in the `Latex4CorelDrawFolder` folder, just copy this folder with its 11 files.  This set of files will only work if you use CorelDraw 2020 and if it is installed in the folder shown below.  This installation was tested with CorelDraw 2020 on Win7 and Win10, with MikTex as LaTeX compiler.

1. Remember to build the Release version not the Debug version.

## Installation

1. Clone or Download this repository outside of your CorelDRaw installation folder, somewhere you can keep it or eventually delete it. In this example it was `K:\WorkN\Latex4CorelDRAW` on my PC

2. Locate where CorelDraw is installed on your PC. On my PC it is here `C:\Program Files\Corel\CorelDRAW Graphics Suite 2020`. In this folder there should be a subfolder `\Programs64\Addons`.  Inside the `Addons` folder create a new folder `Latex4CorelDraw`. The full path to this folder should be something like this
`C:\Program Files\Corel\CorelDRAW Graphics Suite 2020Programs64\Addons\Latex4CorelDraw`. This is the folder where the addon files must be copied to.
   
1. Copy the 11 files in the download subfolder `K:\WorkN\Latex4CorelDRAW\Latex4CorelDrawFolder` into the `C:\Program Files\Corel\CorelDRAW Graphics Suite 2020\Programs64\Addons\Latex4CorelDraw` folder (or where ever it is installed on your PC). Note the small but important folder name change.   
You may get a warning that you need administrator rights to do the copy, approve and continue with the copy.  

1.  After the copy the following files should be in the `\Addons\Latex4CorelDraw`  folder:
 
        `AppUI.xslt`,
        `CorelDrw.addon`,
        `Latex4CorelDraw - Shortcut.lnk`,
        `Latex4CorelDraw.dll`,
        `License.txt`,
        `readme.md`,
        `SciLexer.dll`,
        `SciLexer64.dll`,
        `ScintillaNET.dll`,
        `ScintillaNET.xml`,
        `UserUI.xslt`

1. There should be one file with zero length `CorelDrw.addon`, which may not be present in this set of files (depending on how you got this).  If the file is not there make an empty file in the `\Addons\Latex4CorelDraw` folder, with the name `CorelDrw.addon`.

2. Right-click and open "Properties" for each copied DLL file in the `Latex4CorelDraw` folder. If you see the following text, you have to unblock the file:
**"Security: This file came from another computer and might be blocked to help protect this computer."**. 

1. The addon needs to know where to look for the LaTeX compiler on your PC. Add a path to the environment pointing to the local LaTeX compiler.   For MikTex, the path on my PC is `C:\Users\%USER%\AppData\Local\Programs\MiKTeX\miktex\bin\x64\`.  Change this for your installation details, it will probably be different from mine.

2. Start CorelDraw. In the CorelDraw menu `<Windows>` scroll down to and open `<Dockers>`. Search for the `LaTeX` entry (probably near the bottom end).




