# EurofinAsgn

### Contains 3 Projects
I have Used VS2019 but .net Framework used is 4.6 so that it can be compiled in VS2015 and higher versions
 1. ClubHouseUtil - Contains the utility class library 
  	 1. Api -  Contains the API for the library
     1. Facilities - Contains different Facilities like (Gym, Library etc.) and FacilityBase with all default impl.
     1. Model - Contains
        1. Configurations - All fields that can be configred
        1. Constants - contains all string constants at one place, de to lack of time not moved many response messages.
        1. Dtos - All Data transfer objects used by the library.
        1. Enms - All Enums used by the library.
        1. Interfaces - Interfaces exposed by the library.
        1. Logging - Log utility for the library, Should be used to write exceptions, not used much due to lack of time.
        1. Utility - Extension methods and any other resables utility files.   
 2. ClubHouseUtil.UnitTests - Contains few unit tests, would loved to add more had enough time.
 3. ClubHouseUtil.Client - A Console application which uses the library, it has few uses of library, More can be added and more testing required
 4. Compiling and restoring all nuget packages should work. We can discuss further over call about different cases.
