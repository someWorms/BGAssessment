### Question 2:
In .NET C# implement a function that uses the quicksort recursive sorting algorithm. The function will take as input
from a console window:
1. the number of elements to be sorted (maximum of 10 elements)
2. the integer and/or float per element
and will display as output to a console:
3. the elements in the order input by the user
4. the elements sorted using the quicksort recursive method
Your solution must be accompanied with a set of unit tests verifying the correctness of your functions and
application.

**HINT:** function must be able to handle elements that have the same value or numbers

### Solution
Solution for the question performed via ```Sort``` class containing logic for QS algorithm with recursion.
This class also has wrapper method, containing data validation, and that executes only once per sorting.

Nevertheless, client side console application also has own validation, processing input data from user.
Console application is built in simple way.

Provided Tests are testing algorithm itself, (with validation), as partial methods are divided into small parts, 
and are part of the algorithm.

### Approach
The approach is using SQ Recursive algorithm, with complexity of ```O (n log n)```, with recursion depth ```~log n```.

In some cases complexity could be ```O(n^2)```, depending on input data. For example: when every time pivot is maximum 
or minimum of sequence input.