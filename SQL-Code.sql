-- Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeesDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False

--EF-nugets (körs i Package Manager Console)
--=========
--Install-Package Microsoft.EntityFrameworkCore.SqlServer
--Install-Package Microsoft.EntityFrameworkCore.Tools

--EF-Migrations
--=============
--Add-Migration "A (unique) descrition of the change"
--Update-Database
--Remove-Migration

use
	Master
go

create database
	EmployeesDB
collate
	Finnish_Swedish_CI_AI
go

use
	EmployeesDB
go

select
	*
from
	Employees

select
	*
from
	Company
go

insert into
	Company
values
	('Brights'),
	('Acme')
go

update
	Employees
set
	CompanyId = 1
from
	Employees as E
where
	E.Id % 2 = 1
go

select
	E.*,
	'- - -' as [- - -],
	C.*
from
	Employees as E
full join
	Company as C on
	C.Id = E.CompanyId
	

SELECT [e].[Id], [e].[CompanyId], [e].[Email], [e].[Name], [c].[Id], [c].[CompanyName]
      FROM [Employees] AS [e]
      LEFT JOIN [Company] AS [c] ON [e].[CompanyId] = [c].[Id]
      ORDER BY [e].[Name]