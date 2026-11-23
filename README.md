# Azure Hello World

[![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=daveops-app_Azure-hello-world&branch=feature&metric=alert_status)](https://sonarcloud.io/project/overview?id=daveops-app_Azure-hello-world)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=daveops-app_Azure-hello-world&branch=feature&metric=coverage)](https://sonarcloud.io/project/overview?id=daveops-app_Azure-hello-world)

Azure DevOps home assignment: a .NET 10 "Hello World" app with CI/CD pipelines for build, versioning, testing, code analysis and publishing.

## How it works

```mermaid
flowchart LR
    dev[Push to GitHub] --> branch{Branch?}
    branch -->|main| build1[Build + version] --> up[Azure Artifacts<br/>Universal Package]
    branch -->|feature| build2[Build + version] --> test[xUnit tests<br/>+ coverage]
    test --> sonar[SonarQube Cloud<br/>quality gate]
    sonar --> nuget[NuGet package<br/>Azure Artifacts]
    nuget --> mail[Email with status]
    sonar -.->|fail| mail
```

The project has two pipelines.

**`artifact-upload-pipeline.yml`** runs on `main`. Builds the app, increments the version with a pipeline counter (1.0.1, 1.0.2, ...) and uploads it to Azure Artifacts as a Universal Package.

**`SonarQube-pipeline.yml`** runs on `feature`. Builds the app, runs the unit tests with coverage and scans the code with SonarQube Cloud. If the quality gate passes, it packs a NuGet package and pushes it to the Azure Artifacts feed. An email with the pipeline status is sent at the end of every run.

## Structure

```
HelloWorld/          the app
HelloWorld.Tests/    xUnit tests
```

## Run locally

```bash
dotnet run --project HelloWorld
dotnet test HelloWorld.Tests
```
