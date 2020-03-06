# BankApp

An updated version of an ATM that I made several years ago.

## Setting up the app
This app uses a SQLite database. You might have to create a directory for the database at C:/bankapp

To run the migrations and enter the seed data into the database open the package manager console and enter "update-database"

## Running the tests
You may have to restore nuget packages and build the project for the tests to run properly. You should be able to run the tests from the test runner, otherwise you can enter "dotnet test" into the package manager console.
