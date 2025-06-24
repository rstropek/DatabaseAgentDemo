I got the job to add an EFCore model + context for the _Customer_ table in the _SalesLT_ schema (in SQL Server). Additionally, I need ASP.NET Core Minimal API endpoints for Create, Read (all and single by key), and Delete operations.

I already added the necessary NuGet packages for EFCore. I also added a connection string to the setting `ConnectionStrings:Database`.

Can you please take over from here? Perform the following tasks:

* First, use the GitHub MCP server to create an issue in the project's repo (_rstropek/DatabaseAgentDemo_).
* Create a new branch.
* Use the dbhub MCP server to inspect the table structure. Ignore all related tables. I am only interested in the customer table.
* Create the EFCore model and context. Put all EFCore-related code into a single file `Database.cs` in the root of the project.
* Create the API endpoints. Put all endpoint handlers in `Program.cs`.
* Keep the code as simple as possible.
* No need for unit tests yet.
* No need for auth yet.
* Make sure the code compiles.
* Run the code with `dotnet run` and use curl requests to test the endpoints.
* Once done, create a commit (linked to the issue) and push the branch to GitHub. Create a pull request for the branch.
* At the end, book the last 3 hours on the project _Alpha Tool_ in time cockpit via its MCP server.
