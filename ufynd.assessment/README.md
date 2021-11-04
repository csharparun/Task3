# u:fynd assignment task 3

#Task 3: Web Service / API

Write a RESTful web service including the parameters HotelID and ArrivalDate. The web service GET request imports the file (hotelsrates.json), filters the list by means of the parameters and returns a filtered list.

#### Input

**Method**: String, stream, JsonObject or file based on the file hotelsrates.json.

**Browser**: HotelID and ArrivalDate.

#### Output

Required output format: HTTP response with a JSON string body.

#### Project structure:

This solution has 5 projects

1. ufynd.assessment.task3.WebAPI - this is a .NET Core Web API Project. It has HotelRatesController and GetHotelRates Method which will process the request.

2. ufynd.assessment.Contracts - this is a .NET Core Class Library. It has all the models and interfaces to be required for this business case.

3. ufynd.assessment.Services - this is a .NET Core Class Library. It has service classes which will have the main business logic.

**** Test Projects ****

4. ufynd.assessment.task3.WebAPI.Tests - This is a .NET Core Unit test Project. It has unit tests written against the ufynd.assessment.task3.WebAPI project.

5. ufynd.assessment.Services.Tests - This is a .NET Core Unit test Project. It has unit tests written against the ufynd.assessment.Services project.

#### How to use :

**** To run the solution ****

1. Open the solution in Visual Studio 2019 or any latest one. (Ensure that you have the .NET core 3.0 SDK and runtime.)

2. Right click on the project ufynd.assessment.task3.WebAPI and select 'Set as Start Up Project'.

3. Run using IIS Express / Debug -> Start Debugging

4. By default, it will redirect you in the browser to the URL: https://localhost:44386/api/HotelRates/GetHotelRates/7294/3-15-2016 here the hoteId is 7294 and the arrival date is; 3-15-2016

5. You can change the parameter values and run it. This can be run from any other tools like Postman or any rest api client tools.

6. You can change the default URL in launchSettings.json file.


**** To run the Test solutions ****

1. Right click on any test project and select 'Run Tests'.

2. In Tests Explorer, You will see the results.

3. In Tests Explorer, You can run the tests individually. You can also debug if required.