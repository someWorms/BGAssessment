## Question 3:
Build an ASP.NET C# solution for an Age Calculator.

The application will be web based and requires as input the date of birth of the user. The age calculator will then
calculate and display the age of the user in years, months, weeks, days, hours, minutes, and seconds. You are free to
choose to implement the solution using any ASP.NET C# web framework.

The web application will take as input a date in the format dd/mm/yyyy and will display the age of the user as from
the todays date.

Your solution must be accompanied with a set of unit tests verifying the correctness of your functions and application.

**Example:**

- Birth date: 01/01/2000

- Today’s date: 05/12/2022

Output:

- 22 years, 11 months, 4 days, … hours, … minutes, …. Seconds


### Solution 
For this solution I used ASP.NET MVC framework.

Solution uses MVC Pattern, and only one view model. The model generates within GET request, and then used 
for POST request with data.
The model validates at the controller. Custom attribute is used to check if indicated birthday is in the future.


### Approach
As the solution contains only 1 controller and 1 service,
There is no need to do overengineering and split layers as separate units (this approach is also good for testing).

Also, MVC does not split api and userUI as separate units, and having same code base. That is advantage to use this 
pattern for solution.

