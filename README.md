Kalibrate Technical Assessment
------------------------------

By: Omar Khan
email: omarkhan55@gmail.com

Solution for 'Gilded Rose Inn Problem'

Development Platform:

 - IDE: Visual Studio 2017 (Community Edition)
 - Project Type: .NET Core 2.0 Console Application

 - Dependencies (Core Solution)
	- Microsoft.Extensions.Configuration, Version 2.0.0
	- Microsoft.Extensions.Configuration.Json, Version 2.0.0
	- Microsoft.Extensions.DependencyInjection, Version 2.0.0

 - Dependencies (Tests)
	- Microsoft.NET.Test.Sdk
	- Microsoft.MSTest.TestAdapter
	- Microsoft.MSTest.TestFramework

Config Files: 

- Please Ensure the 'appsettings.json' config file is present in both core and test root folders, if needed you may need to set the 'Copy To Output' to true under properties for the file. This contains a few 'Rate of Decay' options for the program

General Information:

 - Simply load the solution in Visual Studio, build and run, no special instructions needed. Ensure dependencies are installed as above.

 - Please find the source for the solution inside the folder, the core app is the 'GildedRoseProblem' project while the tests are in 'GildedRoseUnitTests' solution. This is a minimal .net core 2.0 console application. There should be no extraneous third party dependencies other than the Microsoft ones listed above. 

- 'Program.cs' contains the entry point of the application which should have the basic test scenario as per the solution pdf, feel free to modify/test with this. the Unit tests contain further specialised tests. Project uses the .net core built-in dependency container which I have wrapped up in the static 'DIServices' class. This also injects the built-in configuration interface.

- To run the tests you can use the built in visual studio UnitTests window interface or open the test file , right-click (somewhere at very top) and select 'Run Tests'

 
