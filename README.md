# AZ-104 Azure App Service Lab

## Overview

This repository contains a small **ASP.NET Core .NET 8 application** used to demonstrate automated deployment to **Azure App Service** with **GitHub Actions CI/CD**.

The application was created as part of a broader hands-on Azure App Service configuration covering deployment, scaling, deployment slots, networking, security and Infrastructure as Code.

## Architecture

```text
GitHub Repository
   ↓
GitHub Actions
   ↓
Build .NET 8 Application
   ↓
Publish Deployment Artifact
   ↓
Azure App Service
   ↓
Production Web Application
```

## Application

The application is a lightweight ASP.NET Core web app targeting:

```text
.NET 8
```

It reads the following Azure App Service application setting:

```text
AZ104_MESSAGE
```

and exposes it through the application endpoint.

Example application logic:

```csharp
var message = builder.Configuration["AZ104_MESSAGE"]
    ?? "AZ104_MESSAGE is not configured";
```

This demonstrates separation of application configuration from source code.

## GitHub Actions CI/CD

The repository includes a GitHub Actions workflow that automatically deploys the application when changes are pushed to the `main` branch.

The workflow performs:

1. Source checkout
2. .NET 8 setup
3. Release build
4. Application publish
5. Deployment artifact upload
6. Artifact download by the deployment job
7. Deployment to Azure App Service

The deployment uses:

```text
azure/webapps-deploy@v3
```

and stores the Azure App Service publish profile as a **GitHub Actions secret** rather than exposing credentials in the repository.

The workflow can also be triggered manually using `workflow_dispatch`.

## Repository Structure

```text
az104-appservice-lab/
├── .github/
│   └── workflows/
│       └── main_az104-josh-webapp.yml
├── Program.cs
├── az104-appservice-lab.csproj
└── README.md
```

## Security and Repository Practices

- Azure deployment credentials are stored using GitHub Actions secrets.
- Deployment credentials are not hardcoded into application source code.
- Application configuration is provided through Azure App Service settings.
- Source code and CI/CD configuration are maintained separately from Azure infrastructure configuration.

## Related Azure Infrastructure Project

The supporting Azure App Service infrastructure and hands-on administration work is documented in:

[Azure Administration Portfolio — Configuration 07: Azure App Service](https://github.com/josh1542/azure-administration-projects/tree/main/configurations/07-azure-app-service)

That configuration includes:

- Azure App Service Plan
- Azure Web App
- GitHub Actions CI/CD validation
- Deployment slots
- Slot swaps
- Autoscaling
- VNet integration
- TLS configuration
- Backup configuration
- Terraform Infrastructure as Code

## Skills Demonstrated

- Azure App Service
- ASP.NET Core
- .NET 8
- GitHub Actions
- CI/CD
- Azure Web App deployment
- Application settings
- GitHub Actions secrets
- Build and deployment automation
- Source control

## Outcome

Successfully implemented an automated CI/CD workflow that builds and publishes a .NET 8 application and deploys it to Azure App Service.

The repository demonstrates the application and deployment layer of the broader Azure App Service configuration documented in the Azure Administration Portfolio.
