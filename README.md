# Weather-Scraper
C# Windows Form Applicaion to pull weather information from Wunderground

In order to use this application locally on your machine, use the following steps as a guideline:
** Note: I used Microsoft Visual Studio 2015 for this **
1. Create a new Windows Forms Application called WeatherApp
2. Replace the default code in Form1.cs with the repo code
3. Replace the default code in Form1.Designer.cs (code view of form) with the repo code
4. Create a new Data Connection (SQL Server Database File) called Abbreviations.mdf (create a data set)
5. On line 107 of Form1.cs, set the file path of your Connection (escape backslashes with another backslash)
6. Create new tables within this Connection, called Countries and States, using repo data
7. Create a file Countries.csv with repo data
8. On line 28, you may have to edit the file path of Countries.csv (you can leave it as is if you place Countries.csv in /bin/Debug).
9. In form view of Form1.cs, click on the drop-down selection item (list box) and under properties, set DataSource to Other Data Sources > Project Data Sources > name of data set you created > Countries; then set DisplayMember to Country. Do the same with the States (State for DisplayMember). This will create statesBindingSource and CountriesBindingSource in the Designer file

You should be able to run the program after these steps are completed.
If you have any problems along the way, manually editing the code in the Designer file will likely fix it.

You can easily change the color an placement of objects on the form in the form view, by clicking/dragging and changing properties. The code for the objects will be automatically updated in Visual Studio.
