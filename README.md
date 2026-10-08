# ASP.NET Core Web API: Posts & Comments (midterm)

Midterm project for the .NET course at Caucasus University (2024): a posts-and-comments REST API.

- CRUD for posts and comments
- **Filtering, dynamic sorting and pagination** on posts (`PostsController`)
- Global **exception-handling middleware**
- Entity Framework Core with SQLite and migrations

**Tech:** C# · ASP.NET Core Web API · Entity Framework Core · SQLite · Swagger

<details>
<summary>My original exam notes</summary>

- Create the project and install EF Core Tools, `Microsoft.EntityFrameworkCore.Sqlite.Core` and Design from NuGet
- Add Models, `Program.cs`, `ApplcationDBContext`, and the Posts and Comments controllers
- Lines 22–58 of `PostsController` contain filtering, dynamic sorting and pagination
- In the Package Manager Console: `Install-Package SQLitePCLRaw.bundle_e_sqlite3`, `Add-Migration InitialCreate`, `Update-Database`
</details>
