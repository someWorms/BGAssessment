### Question 1:
A palindrome is a word or number that reads the same backward or forward.

Implement a function in .NET C# that checks if a given word or number is a palindrome. Character case should be
ignored. Your solution must be accompanied with a set of unit tests verifying the correctness of your functions and
application.

For example, IsPalindrome ("Deleveled") should return true as character case should be ignored, resulting in
"deleveled", which is a palindrome since it reads the same backward and forward.

**HINT:** Watch out for palindromes with special characters, punctuation and asymmetrical whitespaces.

### Solution 
I decided to make two different variants.
1. PalindromeDefault - checks alphanumeric string for palindrome ignoring case, specials, whitespaces.
1. PalindromeSpecial - checks string for palindrome ignoring case, but sensetive to specials and whitespaces.

Both solutions provide 2-pointer algorithm to detect if string is palindrome or not.

Such algorithm has O(n) time and space complexity.

### Approach
I used **extension method** approah, because:
1. Such approach has simple and small logic.
1. User does not need to create instance of class, or invoke external method via static class.
1. It is simplier to read, as the validating palindrome logically belongs to string.

But, the implementation could be also done via ```IPalindrome``` interface, which will be implemented by 
two different classes ```PalindromeDefault``` and ```PalindromeSpecial```. This is also good approach, because
this interface could be implemented by end user with his own logic. 