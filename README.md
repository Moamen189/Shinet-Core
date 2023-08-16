# E-Commerce Application with .NET, Angular, Advanced Patterns, and 3-Tier Architecture

![image](https://github.com/Moamen189/Shinet-Core/assets/79394414/ac3a4488-bc69-415b-bf57-824651f2f4f2)


Welcome to our E-Commerce Application repository! This project is an exemplar of an advanced E-Commerce web application built using a modern technology stack and robust architectural patterns. Our application lets users browse products, securely make purchases through Stripe payment gateway, and utilizes Redis in-memory caching for improved performance. The project also incorporates the Generic Repository, Unit of Work, and Repository Pattern, enhancing code reusability and maintainability.

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

## Contributions

We enthusiastically welcome contributions from the community! Feel free to open issues, submit pull requests, and provide feedback.

## License

This project is licensed under the [MIT License](link_to_license).

---

With a powerful blend of .NET, Angular, advanced patterns, and a meticulously designed 3-Tier Architecture, our E-Commerce Application showcases best practices in modern software development. If you have any questions, suggestions, or feedback, don't hesitate to connect with us!

**Project Maintainers:**  
Your Name [@yourusername](https://github.com/yourusername)  
Co-Maintainer [@co_maintainer](https://github.com/co_maintainer)
