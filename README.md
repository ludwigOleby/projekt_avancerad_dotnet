# projekt_avancerad_dotnet
# Slutprojekt i kursen avancerad .NET

## Vi vill kunna hämta ut detaljerad information om en specifik anställd och dennes tidrapporter

https://localhost:44397/api/time/1/all

https://localhost:44397/api/time/1/single


## Vi vill kunna få ut en lista med alla anställda i systemet

https://localhost:44397/api/employee/


## Vi vill kunna få ut en lista på alla anställda som jobba med ett specifikt projekt

https://localhost:44397/api/projects/1

## Vi vill kunna få ut hur många timmar en specifik anställd jobbat en specifik vecka (ex
antal timmar vecka 25)

https://localhost:44397/api/time/1/1

## Vi vill kunna lägga till, uppdatera och ta bort anställda.

[POST]

https://localhost:44397/api/employee/

	{
	"firstName": "Ludde",
	"lastName": "Von Oleby",
	"phone": "0736004656",
	"project": null,
	"timeReports": null
	}

[PUT]

https://localhost:44397/api/employee/7

	{
	"employeeID": 7,
	"firstName": "Ludde",
	"lastName": "Von Oleby XI",
	"phone": "0736004656",
	"project": null,
	"timeReports": null
	}

[DELETE]

https://localhost:44397/api/employee/7

## Vi vill kunna lägga till, uppdatera och ta bort projekt

[POST]

https://localhost:44397/api/projects/

	{
	"projectName": "Ruby",
	"employee": null,
	"employeeID": 1
	}

[PUT]
https://localhost:44397/api/projects/7/

	{
	"projectID": 7,
	"projectName": "Ruby on rails",
	"employee": null,
	"employeeID": 1
	}

[DELETE]
https://localhost:44397/api/projects/7/

## Vi vill kunna lägga till, uppdatera och ta bort specifika tids rapporter

[POST]
https://localhost:44397/api/time/

	{
	"week": 2,
	"date": 20220410,
	"reportedHours": 37.5,
	"employee": null,
	"employeeID": 1
	}

[PUT]
https://localhost:44397/api/time/6/

	{
	"reportID": 6,
	"week": 3,
	"date": 20220410,
	"reportedHours": 11.5,
	"employee": null,
	"employeeID": 1
	}

[DELETE]
https://localhost:44397/api/time/6/



# Reflektion:
För att kunna få VG ska du:

### 1. Skriva ett resonemang kring din arkitektur och dina val av tekniska metoder i din readme-fil i ditt GIT-repo. Detta resonemang ska vara nyanserat, dvs du ska resonera kring för och nackdelar med din lösning i projektet.

Jag är överlag nöjd med arbetet som jag har utfört i detta projektet.
Alla funktioner fungerar utan större buggar och det finns möjlighet att utöka funktionaliteten om behovet skulle finnas i framtiden.
Jag kan se några möjliga förbättringar:
I klassen "TimeReports så lagras datum och tidsenheterna (Week, date, reported hours) som int och double parametrar vilket fungerar för målen i uppgiften,
Dock så skulle man kunna få tydligare och mer mätbara resultat om man hade ändrat dessa till DateTime variabler och t.ex använt sig utav "TimeSpan" funktionen för att mäta in och utstämplingar i applikationen.

Vidare så har jag installerat och använt mig utav NuGet paketet "Microsoft.AspNetCore.Mvc.NewtonsoftJson" för att undvika konflikter vid körning av applikationen, detta gjorde vi i kursen men jag vill minnas att detta paketet enbart används för "PATCH" funktioner i postman.
Jag använde detta paktet i förra labben (https://github.com/ludwigOleby/Labb4) då jag hade en ".include" funktion i min LINQ query som inte kunde köras utan detta, jag använder mig dock inte av denna lösningen i detta projektet.
Om detta är fallet så är paketet onödigt i denna versionen då patch verbet inte används, detta kan också använda fler resurser vilket på sikt kan göra applikationen långsammare.
Jag har inte hunnit testa att köra funktionaliteten utan detta paketet men detta bör testat och ses över innan lansering av en senare programversion.

Slutligen så använder jag mig stundtals av generiska variabelnamn (framförallt variabeln "ID") i mina controllers, detta kan skapa både konflikter och förvirring och skall i framtiden döpas mera specifikt (EmployeeID, projectID, ReportID) i alla funktioner där variabeln förekommer.

Vid uppladdning av projektet ser jag också att exempel funktionen "WeatherForecast" ligger kvar som controller och klass, denna bör också raderas för att inte förbruka onödiga resurser.

I Nuläget ser jag inga fler förbättringar som jag hade kunnat utföra då jag ännu inte har skapat någon frontend lösning till detta projektet (görs i nästa kurs) men jag antar att förbättringar kan utföras om jag stöter på problem under utvecklandet av frontend delen.
