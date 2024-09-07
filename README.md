# MedfarCodingTestV2
The medfar coding test (version 2.0) for new employees
---
## Introduction
This project is a simple web application using the following technologies:
- Backend - ASP.NET in C#
- Frontend - React with Typescript
- Database - SQL
---
## How to run
### Database setup
From the root folder, navigate to the `./Backend/DataAccessLayer` folder. The `createdb.sql` script can be run on your local sql instance. SSMS can be found [here](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16).

### Backend setup
Open the solution (`MedfarTest.sln`) in the latest version of visual studio. Run the Application project using IIS Express. A swagger UI should appear with only 1 route defined.

### Frontend setup
1. Download the latest version of [Node](https://nodejs.org/en/)
2. Open a command prompt and navigate to the `./Frontend` folder
3. Use the following commands to start the application
    - Install the necessary front end package using: `npm install`
    - Start the development server using: `npm start`
---

<p style="color:lightblue;font-size:24px;text-align:center;">Happy Coding!</p>

---
## F.A.Q.
1. If you get an error connection when loading users, make sure to properly setup the proxy in the `./Frontend/package.json` file to match the URL of the backend (can be found on the swagger UI page)
