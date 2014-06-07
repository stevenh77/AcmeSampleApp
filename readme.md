# ACME Sample app: WPF, Web API services, SQL Server db

Source code:  [https://github.com/stevenh77/acmesampleapp](https://github.com/stevenh77/acmesampleapp)

## Videos

App demo:  [http://youtu.be/Grq1KrVBfCc](http://youtu.be/Grq1KrVBfCc)

Code review:  [http://youtu.be/gXbeHutFKo8](http://youtu.be/gXbeHutFKo8)

SQL review:  [http://youtu.be/dLubVn7kZug](http://youtu.be/dLubVn7kZug)

## Screenshots

![charts](http://stevenhollidge.com/blog-source-code/acme/1.png)

![search](http://stevenhollidge.com/blog-source-code/acme/2.png)

![customer list](http://stevenhollidge.com/blog-source-code/acme/3.png)

![customer detail](http://stevenhollidge.com/blog-source-code/acme/4.png)

![audit](http://stevenhollidge.com/blog-source-code/acme/5.png)

![about](http://stevenhollidge.com/blog-source-code/acme/6.png)

## Getting Started

1) Download the github repo from:  [https://github.com/stevenh77/acmesampleapp](https://github.com/stevenh77/acmesampleapp)

2) Restore the SQL database from the file found in the database folder:  AcmeSampleDb.bak

3) Within the src folder, open the "AcmeSample.sln" solution file in Visual Studio 2012/2013

4) Right click the Solution within the Solution Explorer and select "Enable NuGet Package Restore"

5) Right click the Solution within the Solution Explorer and select "Set StartUp Projects..."
   Select "Multiple startup projects"
   Set the action for "Acme.API" and "Acme.UI" projects to Start without debugging
   
6) Open the "App.config" file within the "Acme.API" project
   Select the connectionString property (line 8)
   
7) Right click the Acme.API project and select properties
   Select the "Web" tab (left hand side of the properties screen)
   Make a note of the "Project Url" value  (http://localhost:17527/ on my machine), you'll need this in a moment

8) Open the "App.config" file within the "Acme.UI" project
   Decide whether you want to use fake data or talk to the sql database
   Update the baseServiceUrl to match the Acme.API virtual directory.  Make sure this property ends "/api/"
   
9) Run the application by click CTRL + F5 (or via the menu:  Debug menu > Start without debugging)