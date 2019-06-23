WeatherREST
===========

Example app sends latitude and longitude information in an HTTP 
request and gets back weather information for that 
longitude and latitude. The user keys in the global latitude and 
longitude parameters and then presses **Get Weather**. When the HTTP 
response is received, the app parses the results and displays a subset 
of the weather information in textbox fields in the lower half of the 
display: 

This example uses `System.Json` to parse the results of the HTTP 
request. The HTTP request, response, parsing, and display are handled 
asynchronously via `async`/`await`. 

Using Android device or emulator with a large screen to view the results. 

Author
------ 

Ming Ye