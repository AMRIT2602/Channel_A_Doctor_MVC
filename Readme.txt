1. Open the Solution in Visual Studio
2. Build the project 
3. Navigate to tools ans select Nuget Package manager -> Package Manager Console (PMC)
4. On the console execute the following command
 Update-Database  -Context Channel_A_Doctor_Identity_MVC_AppContext



5. On the console execute the following command

Update-Database  -Context Channel_A_Doctor_MVC_DatabaseContext



6. After migration is successful Run the project 

7 if you click on Appointments/Doctors/MedicalCentres/Patients this will redirect you to ASP .net identity login page login from the following credentials

User : admin@echannel.com
Password: 1qaz2wsX@

8. Also you can register your own user via the Register link on menubar and login with that user.
