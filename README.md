# Hair Salon Database (C#)

A web app, built with C#, that allows user to store and retrieve data about stylists in a hair salon, including each stylist's unique set of clients using a sql database.

## Installation

### Database Setup

1. Clone this repository.
2. Within a terminal running MySQL, run the following commands:

 ```
 CREATE DATABASE austin_barr;
 ```

 ```
 USE austin_barr;
 ```

 ```
 CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), specialty VARCHAR(255));
 ```

 ```
 CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), stylist_id INT);
 ```


3. Optional - to allow for testing, run the following SQL commands as well:

 ```
 CREATE DATABASE austin_barr_tests;
 ```

 ```
 USE austin_barr_tests;
 ```


 ```
 CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), specialty VARCHAR(255));
 ```


 ```
 CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), stylist_id INT);
 ```


### Web App Setup

1. Follow the steps above to set up your database/s.
2. Install .NET, if not already present on your local machine.

3. In your preferred shell, navigate to the HairSalon folder and run the following commands:

 ```
 $ dotnet restore
 ```

 ```
 $ dotnet run
 ```

4. Navigate to localhost:5000 in your preferred browser.

## Specifications

1. App routes users to the home page, which displays buttons, to add Clients/Stylists, and view Stylists.

2. When clicking "Add a new stylist", user is routed to a form through which the new stylist can be added to the database.

3. When clicking "Add a new Client", user is routed to a form through which the new stylist can be added to the database with a Stylist.

4. When clicking "View Stylists", user can see what stylists are present and has a link to view which clients the have.

### Technologies Used

* C#
* HTML
* MAMP
* MySql
* MVC Architecture

### Support and Contact Details
If you encounter any bugs or would like to make suggestions regarding this project, please feel free to contact me austinbarr@protonmail.com.


### License

This project is distributed under the MIT License
