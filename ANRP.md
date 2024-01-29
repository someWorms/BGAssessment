## Question 5:
Imagine a system hosting several Automated Number Plate Recognition “ANPR” cameras. Each camera sends back
number plate data using the folder and file conventions as can be seen on the provided “ACS Outout Test.rar” file.

Your task is to produce a .NET C# Windows Service application developed in Visual Studio or later that is capable of
achieving the following:

- Process every plate read file (*.lpr) and store all data in a suitable class or SQL table;
- That no file can be processed more than once. Note that the filenames for different cameras may have the
same name;
- Capable of processing new files as soon as they become available on the various camera folders as per the
examples provided;
-  Queries capable of retrieving plate reads within a certain date range and camera.
A suitable database structure should also be provided that will accommodate your solution.

The format of the contents of the “lpr” file is as follows:
```“NONE\r9112A\r77\rGIBEXIT2\20140827\1210/w27082014,12140198,9112A,77.jpg”```
The '/' and '\' are column delimiters and therefore can be disregarded. A description and format for each field is
summarized in the table below:

| Name of Field | Example | Description |
|---------------|---------|-------------|
|CountryOfVehicle| GBZ |Country of origin|
|RegNumber| r9112A |Number Plate of vehicle <br/> (leading r can be dropped)|
|ConfidenceLevel| r77 |Camera confidence level <br/> (leading r can be dropped)|
|CameraName| rGIBEXIT2 |Camera Name <br/> (leading r can be dropped)|
|Date| 20140827 |Date of capture <br/> (format yyyymmdd)|
|Time| 1210 |Time of capture <br/> (format HHmm where HH is 24 hour)|
|ImageFilename| w27082014,12140198,9112A,77.jpg |name of image file|

Your solution must be accompanied with a set of unit tests verifying the correctness of your functions and application.

### Solution
.Net framework 4.7 is used to create Windows service.

As database connection and ORM EF Core 3.1 is used, (latest version that supports .net framework)

Installer configured to work as User, because we dont need root previlegies.


### StartUp

Use the following command to add service: __InstallUtil will not be able load dependencies__
```shell
sc.exe create ANRP binPath="your path to bin"
```

Update settings.json configuration!

### Approach
As I investigated it is not reliable to use SystemFileWatcher due to his 
problems and buffer limitations. 

It is possible to implement own watcher based on
interop (win32), or tracking file time. Also, there is a way to scan directory every __X__ minutes, as 
I did for this solution (not the best one, but simple), because I do not know how files are comming to the folder, meaning, that
I can not rely on the "file created timestamp". 

The processed files are stored as apart table at the database, with full path. This approach excludes posibility of processing 
the same file with the same path twice.

The database stores date and time as integer. 
I do not format neither date nor time because such format might be consumed by another service, so i left it as is.



