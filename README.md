# Task 3: Web Service / API

## Environment
Framework: .Net 5


### Projects 
* task1.app: .Net Console WebApi Project
* task1.test: .Net NUnit Test Project

## Build & Run

```
dotnet build && dotnet test

dotnet run -p task3.webapi/task3.webapi.csproj
```
## Request

Request to obtain hotel rates by HotelID and ArrivalDate:

```
GET /HotelRates/GetHotelRates/7294?arrivalDate=2016-03-18 HTTP/1.1
Host: localhost:5001
```
