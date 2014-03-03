InspectCode Result Viewer
=========================

This is a simple viewer which allows you to read the result file of Jetbrains' [InspectCode commandline tool](http://www.jetbrains.com/resharper/features/command-line.html)
more easily. It reads the xml file produced by InspectCode and shows it in a tree list, grouping the issues reported by project, file and category. When clicking an issue
it allows to open the file in VS.NET and navigate to the particular line. This requires that the viewer is run using the same user as VS.NET as it uses
EnvDTE interop to communicate with VS.NET, which isn't possible if the applications run under different users (e.g. normal user and administrator). 

I hope this code is useful to you. 

### Compiling ###
The code uses the DevExpress TreeList control (v13.1). If you want to compile the code you need a license for this control from DevExpress. An older version
might suffice, change the Properties/Licenses.licx file to the version you're using and of course the references in the vs.net project.

### Configuration ###
It requires that you specify the path where InspectCode was run from in the app.config file. This is required because the path for the solution inspected
is emitted into the results xml file in a relative form (relative to InspectCode), which can't be used directly to calculate the file paths for opening the file
in VS.NET. The path specified in the app.config file will be used to correct this. 

### Dependencies ###
The code depends on [BCL Extensions](https://github.com/SolutionsDesign/BCLExtensions), which reference is obtained from [Nuget](https://nuget.org/packages/SD.Tools.BCLExtensions/)

### License ###
This code is &copy; 2014 [Solutions Design bv](http://www.sd.nl/) and is released under the [BSD2 license](https://github.com/FransBouma/InspectCodeResultViewer/blob/master/LICENSE.txt).

