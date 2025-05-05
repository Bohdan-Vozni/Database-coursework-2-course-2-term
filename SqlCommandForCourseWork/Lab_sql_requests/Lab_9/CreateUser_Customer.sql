

if not exists (select name from sys.server_principals where name  = 'Customer')
	create login Customer with password = '1234';


use helsi;


if exists (select name from sys.database_principals where name = 'Customer')
   drop user Customer;


create user Customer from login Customer


alter role db_datareader add member Customer

