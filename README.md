
 
# **TOLL CALCULATOR** 

Menu
- [**TOLL CALCULATOR**](#toll-calculator)
- [Introduction](#introduction)
    - [Requirements](#requirements)
- [How to use (as end-user)](#how-to-use-as-end-user)
- [Development](#development)
    - [Controllers](#controllers)
    - [Models](#models)
- [Tools](#tools)
- [Language](#language)
- [Tests](#tests)
    - [Using Postman](#using-postman)
    - [Using UnitTest](#using-unittest)
- [Movie](#movie)
- [Contact](#contact)

# Introduction  
>The main functionality of the code is to calculate toll fees for each vehicle according to the requirements described below.
>Based on that, a city decided to implement toll fees to reduce traffic congestion during peak hours. To attend to these needs, the code was started, however it was interrupted. Therefore we need to pick up where it was left off and deliver it to production. 

### Requirements 

>* Fees will differ between 8 SEK and 18 SEK, depending on the time of day;
>* Rush-hour traffic will render the highest fee;
>* The maximum fee for one day is 60 SEK;
>* A vehicle should only be charged once an hour;
>* In the case of multiple fees in the same hour period, the highest one applies;
>* Some vehicle types are fee-free;
>* Weekends and holidays are fee-free.

# How to use (as end-user)
>* The user must register the tickets of each vehicle containing license plate information, vehicle type and day with time (This step can register diferent user's vehicles at the same time);
>* The user must inform a license plate of the vehicle that will be consulted;
>* The user must request the result of the vehicle fees that was informed.

# Development 

>To attend and to do this adaptation, an API was created with the methods listed below.

### Controllers 

>* File HistoricController
> 1. public int GetTollFee()
> 
>      Responsible for retrieving the *__GetTollFee__* main method, which will calculate the fees and return the amount to be charged. 
> 
> 2. public void PostInsert(int vehicleId, string vehicleType, DateTime dates)
> 
>     Responsible for inserting a new register. 
> 
>         Variables:
> 
>         vehicleId: client vehicle license plate;
>     
>         vehicleType: Type vehicle;
> 
>         dates: date with time:
>           (Format datetime: '2013-03-26 15:25:00').
> 
> 3. public void PostConsult(int vehicleId)
>    
>    Responsible for selecting the specific vehicle for which the toll will be calculated.
>         
>         Variables:
> 
>         vehicleId: client vehicle license plate;
> 
> 4. Others: GetTollFee / GetTollFee, IsTollFreeDate, IsTollFreeVehicle and TollFreeVehicles.
> 
>    The methods that should be adapted to the test development.
> 
 ### Models

 >* File HistoricController
> 1. Historic
> 
>    Responsible for receiving the vehicle information.
> 
> 2. ListVehicleDates
> 
>     Responsible for receiving the vehicle dates selected.

# Tools

>* [Visual Studio](https://visualstudio.microsoft.com/);
>
>* [Visual Studio Code](https://code.visualstudio.com/); 
>
>* [Postman](https://www.postman.com/).

# Language

>* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)

# Tests

### Using Postman   
    Example test:

    Create 3 local requests to execute using [Postman tool](https://www.postman.com/).

    Steps: 

    1. Insert the date in the 'Historic' list.
    
        http://localhost:1063/api/Historic?vehicleId=2&vehicleType=car&dates=2013-03-26 15:25:00 </a>

    2. Consult the client vehicle license plate that will calculate the toll. It will be insert in the 'ListVehicleDates' list.
    
        http://localhost:1063/api/Historic?vehicleId=2 </a>
    
    3. Get the toll fees 

        http://localhost:1063/api/Historic </a>

       The expected result should be: 13

### Using UnitTest

    Scenarios:

    1. The maximum amount per day and vehicle is 60 SEK.

    2. The tax is not charged on weekends (Saturdays and Sundays), public holidays, days before a public holiday and during the month of July.

    3. a vehicle that passes several tolling stations within 60 minutes is only taxed once. The amount that must be paid is the highest one.

    4. Tax Exempt vehicles.

    5. Different clients (vehicleId: client vehicle license plate)
   
# Movie

> Hackers: Computer Pirates

# Contact

> *__Nome:__* Francielle Rosa
> 
> *__E-mail:__* francielle.frosa@gmail.com
> 
> *__Linkedin:__* https://www.linkedin.com/in/francielle-rosa-b324736a/
> 
> *__Mobile:__* Sweden  +46 76-584 03 20 / Brazil +55 19 98287-7943
