Agency Address Book
==================
John S. Vicencio, johnvicencio.com, has developed a simple CRM with two tables with one-to-many relationship.

Technologies: ASP.NET MVC, C#, Razor, Entity Framework (using Code First method), Identity, SQL, Bootstrap, jQuery (and two other libraries), JavaScript, CSS and HTML.

Users have to be logged-in to access records of brokers and their clients. Once they are logged in they can now do CRUD such as creating records, viewing details of records, editing or updating them and deleting as well. Search, sorting and pagination are implemented.

The MVC design method separates concerns by putting all the logic as much as possible in the Controller. All data related entities are placed in the Model. The data are then displayed in the View through the Controller. Separation of concerns also mean that each technologies are utilize based on their responsibilities. For example, C# mainly on the overall development of the application; HTML with some help from Razor C# to display the presentation UI with minimal JavaScript/jQuery as possible; uses styling separately; separating repeatable partials and so on. One could use AJAX or Angular, as one technique, to pull/insert data into a layout; I didn't follow this trend because this DOM manipulation would be another layer of complexities when you can accomplish that with C# (Razor) and HTML in the view. Also, if you want to rank a dynamic webpage, Google seems to have trouble indexing HTMLs with DOM manipulation.

Live sample: http://aabaspnetmvc.mythoslife.com
GitHub: https://github.com/johnvicencio/The-Tech-Academy-Projects/tree/master/Csharp/FinalProject/AgencyAddressBook
