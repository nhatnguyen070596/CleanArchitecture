Readme 

Install Docker and Run

sudo docker pull mcr.microsoft.com/azure-sql-edge:latest

sudo docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=Password.1' -p 1433:1433 --name azuresqledge -d mcr.microsoft.com/azure-sql-edge

migrations database

dotnet ef --startup-project ../Member.Domain/Member.API  migrations add initial8  -c StoreContext -p Member.Infrastructure/Member.Infrastructure.csproj

dotnet ef --startup-project ../Member.Domain/Member.API database update initial8  -c StoreContext -p Member.Infrastructure/Member.Infrastructure.csproj

"DefaultConnection": "Data Source=localhost;Initial Catalog=Member;User Id=sa; Password=Password.1; TrustServerCertificate=True;"