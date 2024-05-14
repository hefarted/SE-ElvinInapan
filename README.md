# Customer Payroll System

## Introduction
This Customer Payroll System is designed to manage and compute salaries for different types of employees based on their attendance. The system is built with a focus on clean architecture, adhering to SOLID principles and leveraging a Domain-Driven Design (DDD) approach.

## Project Setup

### Requirements
- .NET Core 3.1 or later
- Visual Studio 2019 or later
- SQL Server 2019 or later
- Docker (for containerization)

### Installation Instructions
1. **Clone the repository:**
   ```bash
   git clone https://github.com/hefarted/SE-ElvinInapan.git

## If we are going to deploy this on production, what do you think is the next
## improvement that you will prioritize next? This can be a feature, a tech debt, or
## an architectural design.

Deployment and Next Improvements
Current State
The application is currently set up with foundational payroll functionality, structured around a simplified Domain-Driven Design (DDD) framework. The architecture and design patterns in place are intended to facilitate scalability and maintainability.

Next Steps for Production Deployment
As we prepare for production deployment, the following improvements will be prioritized:

Enhanced Naming Conventions:

Refine naming conventions across the codebase to improve readability and consistency, making it easier for new developers to understand and contribute to the project.
Deepening DDD Implementation:

Further develop the Domain-Driven Design implementation to decouple the domain logic more distinctly from the infrastructure and UI layers, thus enhancing the modularity and testability of the system.
Containerization with Docker:

Package the application into Docker containers to encapsulate the environment and ensure consistency across development, testing, and production platforms. This will minimize "works on my machine" issues and streamline deployment processes.
Adhering to SOLID Principles:

Continue to refine the system architecture to fully embrace SOLID principles, ensuring each module and class has single responsibilities and is open for extension but closed for modification, which is crucial for long-term maintenance and scalability.
