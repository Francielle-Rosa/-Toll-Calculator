
# 
# **TOLL CALCULATOR** 


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

# How use (as end-user)
>* The user must register the tickets of each vehicle containing license plate information, vehicle type and following data with time (This step can be registered any user's vehicles);
>* The user must pass a license plate of the vehicle that will be consulted;
>* The user must request the result of the vehicle fees that was passed.

# Development 

>To attend and to do this adaptation, an API was created with the methods listed below.

### Controllers 

>* File HistoricController
> 1. public int Get()
> 
>      Responsible for retrieving the *__GetTollFee__* main method, which will calculate the fees and return the amount to be charged. 
> 
> 2. public void Post(int vehicleId, string vehicleType, DateTime dates)
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
> 3. public void Post(int vehicleId)
>    
>    Responsible for selecting the specific vehicle that will calculate the toll.
>         
>         Variables:
> 
>         vehicleId: client vehicle license plate;
> 
> 4. Others: GetTollFee / GetTollFee, IsTollFreeDate, IsTollFreeVehicle e TollFreeVehicles.
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

# How to do the test using Postman

    Example test:

    Create 3 local requests to execute using [Postman tool](https://www.postman.com/).

    Steps: 

    1. Insert the date in the list 'Historic'
    
        http://localhost:1063/api/Historic?vehicleId=2&vehicleType=car&dates=2013-03-26 15:25:00 </a>

    2. Consult the client vehicle license plate that will calculate the toll. Will be insert in the list 'ListVehicleDates'
    
        http://localhost:1063/api/Historic?vehicleId=2 </a>
    
    3. Get the toll fees 

        http://localhost:1063/api/Historic </a>

       Expect the result needs to be: 13

# Movie

> Hackers: Computer Pirates
