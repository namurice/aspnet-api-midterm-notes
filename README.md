create project
name project midterm

download entityframeworkcore,tools, Microsoft.EntityFrameworkCore.Sqlite.Core and design from nuget

create models folder copy paste from my rep

copy paste program.cs

copy paste ApplcationDBContext

add commentscontroller and postscontroller.

in postscontroller from 22 to 58 lines is filtering, dynamic sorting, pagination

copy paste appsettings.json file

in package manager console
Install-Package SQLitePCLRaw.bundle_e_sqlite3
Add-Migration InitialCreate
Update-Database

if i dont have filtering/pagination/sorting then ill have handling which is the middlewares folder

if i dont have to do handling then remove 5th and 41st line from program.cs
