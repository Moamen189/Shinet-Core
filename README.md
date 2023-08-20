# Shinet-Core E-Commerce Application 
![image](https://github.com/Moamen189/Shinet-Core/assets/79394414/ac3a4488-bc69-415b-bf57-824651f2f4f2)


Shinet-Core is an exemplar of an advanced E-Commerce web application built using a modern technology stack and robust architectural patterns. Our application lets users browse products, securely make purchases through Stripe payment gateway, and utilizes Redis in-memory caching for improved performance. The project also incorporates the Generic Repository, Unit of Work, and Repository Pattern, enhancing code reusability and maintainability.

## Features

- **Product Showcase:** Browse a diverse range of products with detailed descriptions and images.
- **Secure Payments:** Seamless integration with Stripe payment gateway ensures secure transactions.
- **User Authentication:** Register, log in, and manage your personal account.
- **Shopping Cart:** Easily add, update, and remove products from your shopping cart.
- **Efficient Caching:** Leverage Redis for enhanced data retrieval speed.
- **3-Tier Architecture:** Structured as API, Core, and Infrastructure layers for better separation of concerns.
- **Advanced Patterns:** Utilize the Generic Repository, Unit of Work, and Repository Pattern for organized data access.

## Technologies Used

- **Frontend:** Angular
- **Backend:** .NET Core
- **Database:** Entity Framework Core with In-Memory Database
- **Caching:** Redis
- **Payment Gateway:** Stripe

## Architecture Overview

Our project employs a 3-Tier Architecture to enhance modularity, scalability, and maintainability:

1. **API Layer:** Contains controllers that handle incoming requests, orchestrating data manipulation operations.
2. **Core Layer:** Defines entities and business logic, encapsulating the application's core functionality.
3. **Infrastructure Layer:** Houses data access logic, implementing the Generic Repository and Unit of Work patterns.

## Architectural Patterns

- **Repository Pattern:** Isolates data access code, promoting separation of concerns and organized data retrieval.
- **Generic Repository:** Maximizes code reusability by providing a single, flexible repository for multiple entity types.
- **Unit of Work:** Manages transactional boundaries and ensures data integrity across multiple repository operations.

## Getting Started

1. **Clone the Repository:** `git clone https://github.com/yourusername/e-commerce-app.git`
2. **Frontend Setup:**
   - Navigate to the `frontend` directory.
   - Install dependencies: `npm install`
   - Run the frontend: `ng serve`
3. **Backend Setup:**
   - Open the solution in Visual Studio or your preferred IDE.
   - Build and run the backend application.
4. **Database Migration:**
   - Apply EF migrations to set up the database: `dotnet ef database update`
5. **Configuration:**
   - Configure Stripe API keys and other settings in the respective configuration files.
6. **Redis Configuration:**
   - Ensure Redis is installed and running locally or update connection settings.
7. **Access the Application:**
   - Open your browser and navigate to `http://localhost:4200`.


## MIT License

Copyright (c) 2023 Mo'men Ashraf Mohamed

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
