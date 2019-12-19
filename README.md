# GreenvilleRevenue
I wrote this program after completing the course I took on C#. It is a console application demonstrating my knowledge of C# and object-oriented programming.
## Prompt
Greenville County hosts the Greenville Idol competition (talent contest) each summer during the county fair. Write a program that collects and then displays information about the contest. 
## Objectives
* Create a Contestant class with the following characteristics:

   * The class contains an array that holds talent codes [ S, D, M, O ] and an array that holds talent code descriptions  
   [ Singing, Dancing, Musical Instrument, Other ].
   * The class contains fields for a contestant's name and talent code.
   * The class contains properties for a contestant's name, talent code, talent description, and entry fee. The set accessor for the name only accepts valid names. The set accessor for the talent code only accepts valid codes and also sets the talent description property.
   * Override the class' ToString() method to return a string containing all of the contestant's data.
   
* Extend the Contestant class to create three subclasses: ChildContestant, TeenContestant, and AdultContestant.  

   * Child contestants are 12 years old and younger, and their entry fee is $15.
   * Teen contestants are 13 - 17 years old, and their entry fee is $20.
   * Adult contestants are 18 years old and older, and their entry fee is $30.
   
* The program performs the following tasks:  

   * The program prompts the user for the number of contestants in last year's and this year's competition; the number must be between 0 and 30. The program continues to prompt the user until a valid value is entered.
   * The program prompts the user for names, ages, and talent codes for the number of contestants entered in this year's competition. Along with the prompt for a talent code, display a list of valid categories. The program continues to prompt the user until valid values are entered.
   * Based on the age entered for each contestant, create an object of the correct type (child, teen, or adult), and store it in an array of Contestant objects.
   * After data entry is complete, display statistics about the contest including: the number of contestants in last year's and this year's competition, the number of contestants in each category, and the total expected revenue for this year's competition (sum of entry fees for the contestants).
   * After statistics have been displayed, continuously prompt the user for talent codes, and display all the data for all the contestants in each category. Display an appropriate message if the entered code is invalid. Give the user the option to enter a sentinel code that terminates the program.
## Programming Fundamentals Utilized
* Object-oriented design
* Classes and subclasses
* Objects
* Inheritance
* Encapsulation
* Polymorphism
* User input validation  
   * Exception handling
   * Parsing
* Methods
* Loops
* Conditionals
* Arrays
