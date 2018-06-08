# Weather-Scraper
C# Windows Form Applicaion to pull weather information from Wunderground

In order to use this application locally on your machine, use the following steps as a guideline:
** Note: I used Microsoft Visual Studio 2015 for this **
1. Create a new Windows Forms Application
2. Replace the default code in Form1.cs with the repo code
3. Replace the default code in Form1.Designer.cs (code view of form) with the repo code
4. Create a new Data Connection (SQL Server Database File) called Abbreviations.mdf (create a data set)
5. Create new tables within this Connection, called Countries and States, using repo data
6. Create a file Countries.csv with repo data
7. In form view of Form1.cs, click on the drop-down selection item (list box) and under properties, set DataSource to Other Data Sources > Project Data Sources > name of data set you created > Countries; then set DisplayMember to Country. Do the same with the States (State for DisplayMember). This will create statesBindingSource and CountriesBindingSource in the Designer file.

You should be able to run the program after these steps are completed.
