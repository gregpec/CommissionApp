# CommissionApp

In this application you can add a car and a customer to the database, 
you can also add data from a csv file to the database, 
you can delete data from the database by providing the ID from the database repository. 
The application creates audit files, text files containing information about 
the actions taken, saving or deleting the ID from the repository. 
A Json file is also created when we import data from a csv file. 
We can also read the AuditFile.txt file. 
The program allows you to convert a csv file to a txt file.
The following files are created from the Customers.csv and Cars.csv files:
- Customers.json
- Cars.json
- Customers.txt
- Cars.txt
When we enter data from the console an audit file is created:
- AuditFile.txt
We can also export Cars.csv data to xml and file is created:
- Cars.xml