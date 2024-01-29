## Question 4:
Create a simple file service using ASP.NET C# Web API that can store large amounts of unstructured data (pictures,
videos, documents, etc.), in a Windows Azure Blob Storage. 

The service will capture the file:

- Name
- Size
- Content Type
- Filename extension
- Timestamp processed
- File path on the Windows Azure blob storage

and store this information on a database structure to be able to query historically files that have been processed
successfully from where and when.

You will require the Windows Azure SDK for .NET which you can find here https://www.windowsazure.com/en-
us/develop/net/  

For the purposes of this Web API you can use the local Azure Storage Emulator provided with the SDK which doesn't
communicate with the actual Azure Blob Store. As part of your response please include additional instructions on the
steps and application settings / configurations required to use a real Azure Blob Store.
Your solution must be accompanied with a set of unit tests verifying the correctness of your functions and application.


### Notes
1. Azure Storage Emulator is **obsolete**, please, use Azurite instead.

### Solution
ASP NET Web API is used to implement solution. As I used .net 8 I had to use Azurite instead of Emulator,
but there are no any difference as far as I know.

The solution contains 3 projects. (it is not clean architecture!)
- API: presentation layer.
- Database: persistence layer.
- Testes: for tests.


### Approach
First of all I moved db as part project which contains domain and db configurations, because it is 
separate logic, which is related to work with databases.

ErrorHandling:
I used for this solution global middleware error handler, as I do for small projects. There are a lots of 
approaches how this can be done. For example in this case definition of custom ```ProblemDetailFactory```, with list 
of error codes could be done. 
For that case, also implement base controller to handle all errors occured during process.

Results:
There are a different approaches for responses to client. Current implementation uses error types in response model,
which could be handled on the client side.

Another approach is to handle ProblemDetails, as described before, and use exceptions\errors that could be handled 
on client side.

Upload:
There are 2 ways to make file upload to AWS\Azure or else storage which i can suggest.

First one is to upload file directly

..test approach

### Configurations

#### Azure

Here is used test environment for Azure Emulator.

If you are willing to use real Azure Storage service, you will
need to sign in to your Azure account.
Then you will need to create the container. 
(**containers** under **data storage** menu, then click add(+).

Then you just copy connection string from there, and paste it to the
[appsettings](BlobStorage/appsettings.json) to the "AzureConnection" configuration string.

If connection string does not contain name, paste it explicitly.

____
#### SQL Server
Go to 
[appsettings](BlobStorage/appsettings.json) 
and paste your connection string for MSSQL database.