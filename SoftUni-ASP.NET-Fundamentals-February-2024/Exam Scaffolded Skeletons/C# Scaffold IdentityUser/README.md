Exam Scaffolded Skeleton which will help you Finish the Exam for less than 1 hour and 30 mins out 6 hours.

Ctrl+F5 - start the localhost
Ctrl+Shift+B - Build - to see errrors!

DROP DATABASE [име_на_базата];

commands:
Add-Migration , remove-migration , update-database

in Package Manager Console:
add-migration CustomTablesAdded - адване на миграция
remove-migration - изтриване на последната успешна миграция,(миграциите в червено не се добавят,в жълто се добавят)
(при проблеми изтрий миграциите в Migrations и свали първоначалните миграции и променяй името на базата)

//При проблеми с миграциите:
изтрий миграциите в Migrations и свали първоначалните миграции и променяй името на базата
 
seed:
1. първо направи коректно Add-Migration CustomTablesAdded
2. update-database
3. remove-migration

1. Add-Migration, Check Migrations if correct, Fix Migrations if needed and update-database
update-database - когато има промени в Entities,Model или DBContext

add-migration Test-случайно име


//При проблеми с миграциите:
изтрий миграциите в Migrations и свали първоначалните миграции и променяй името на базата
Register Test:
0.Back up the starter Migrations on the desktop // if u forget download them again
1.Add "ConnectionString" in "appsettings.json":           "Server=ASUS-DESKTOP\\SQLEXPRESS;Database=Homies;Trusted_Connection=True;MultipleActiveResultSets=true" //replace "Homies"

2.Add "new Scaffolded item" in "Areas.Identify : Reg,Log,LogOut/Remove extra code
//Check if scaffold its broken//Check if u see home,reg,log view *


3.Add " DataConstants.cs " in "Data":                                
4.Add folder " Entities " in "Data":                             
5.Add entity classes in Data.Entities:                copy/paste all entities from the description

6.Full: DataConstants.cs
7.Full: Entities(add: using static Library.Data.DataConstants;)

(you can replace 3 to 7 with the drag/drop mini skelet)


8.Add in: Data.DbContext (Add: DBSets,OnModelCreating)//using Type = Homies.Data.Entities.Type;//sometimes needed

9.Program.cs: Identity Requirements:      Copy/Paste AddDefaultIdentity <>{}

10.Fix namespaces if needed somewhere

11.Package Manager Console commmands:

12.Open MSSMS and check Top 1000
13.Test: Reg,Log,LogOut *





Controller,Views//using static Homies.Data.DataConstants;

//Views:
1.1.Uncomment everything: Views.Item 
1.2.Add: @model in Views

@*
// Add: IEnumerable<ItemViewModel>  to All.cshtml,Profile.cshtml
// Add: ItemFormModel               to Add.cshtml,Edit.cshtml
*@
@model ItemFormModel  


2.Full: Solution.Models


//Controller:
3.Add: " ItemController.cs " in "Controllers"
           





















Skelet #2 (it may be needed for Skelet 1 as well)

1.If Scaffold Identity i already added remove it by removing everything inside Areas.Identity and on Areas.Identity
scaffold a new Identity and remove folder User if exists in Views because it breaks the app

2.Fix: _Layout.cshtml//with if/else//if needed

3.1. Add snippet: (careful the classes)
Views.Shared._Layout.cshtml:

@if (this.User.Identity.IsAuthenticated)//if logged: All,Add,Profile, //else to Home
{
    <li class="nav-item">
        <a class="nav-link text-dark"
           asp-area="" asp-controller="Contacts" asp-action="All">Home</a>
    </li>
    <li class="nav-item">
        <a class="nav-link text-dark"
           asp-area="" asp-controller="Contacts" asp-action="Add">Add</a>
    </li>
    <li class="nav-item">
        <a class="nav-link text-dark"
           asp-area="" asp-controller="Contacts" asp-action="Team">Profile</a>
    </li>
}
else
{
    <li class="nav-item">
        <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
    </li>
}


3.2. Add code:
Views.Shared._LoginPartial.cshtml:
@inject SignInManager<ApplicationUser> SignInManager
@inject UserManager<ApplicationUser> UserManager

3.3
Views.Shared._LoginPartial.cshtml:
Remove! one of the 2 code parts(remove the non scaffolded code)

3.4
Views.Shared._ViewImports.cshtml
Add all usings from Views.Items here _ViewImports.cshtml










