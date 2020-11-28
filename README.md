# BridgeInternational
Full Stack Technical Test for Bridge International Academies


Assumptions:
1. The entire data provided in the battery.json is of same time zone.
2. battery.json file is saved in the project itself.
3. If there is only 1 record in the json data, Web API will result null values instead of 'Unknown', as the resulting Web API is with decimal values. The display of 'Unknown' can be handled from UI.
4. Test cases were limited due to time constraints, but covered most of the scenarios.

Technology Stack and nuget packages used - 
1. .NET Core.
2. Autofac for Dependency Injection.
3. System.Text.Json for deserializing the json file
4. MSTest for writing the Unit test cases.
5. Moq for mock testing.

How to run:
1. Startup Project should be "BridgeInternationalAcademies.WebAPI"
2. Run the application, it will for now redirect directly to the Battery Usage Web API call.
3. Below is the API call to run manually as well - https://localhost:44305/api/BatteryUsage
4. API response will have the below format:
  a. data - It contains the array list of results with serialNumber and avgDailyBatteryUsage
  b. Info - It shows whether the response is successful.
    i. resultCode : Success - 1, Error - 2.
    ii. resultMessage: Empty is case of successfull response, Error message if API fails.
5. All test cases are available under tests folder.

Room for Improvement:
1. Based on the data, we can analyze the peak hours of usage and come up with a plan for better solution.
2. As mentioned in the requirements, json files can be maintained in network path for additional security.

