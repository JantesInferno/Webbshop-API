# Webbshop-API

This is an ASP.NET Core Web API that serves as the backend for a webshop application (https://github.com/JantesInferno/Webbshop). 

This API leverages ASP.NET Core, Entity Framework Core and Microsoft Identity to handle user and product CRUD operations, with data stored in an Azure SQL Database.

## Features
### User Management: 
Allows users to register and sign in.
### Cookie Authentication:
Enhances security by adopting Microsoft Identity's cookie-based authentication mechanism, fortifying against XSS vulnerabilities.
### Product Management: 
Provides endpoints for browsing products available in the webshop.
### Order Placement: 
Enables users to place orders for products.


## Technologies Used
#### ASP.NET Core: 
A cross-platform, high-performance framework for building web APIs.
#### C#: 
The primary programming language used for developing the API.
#### Entity Framework Core: 
An object-relational mapper (ORM) that simplifies database interactions.
#### Microsoft Identity: 
Provides authentication and authorization services.
#### Azure SQL Database: 
A fully managed relational database service provided by Microsoft Azure.
