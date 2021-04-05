# .NET Core Container With Multiple App Settings & External DB Connection

In this application I tried to show two things. One, how to connect external or remote db to docker container which is not in container. Two, I did experiment of Overriding ASP Net Core settings with Environment Variables in a container.

## 1. .NET Container with Remote or External DB Connection Which is not in Container

- First, You have to find ip of your db server machine. Ex. For local machine, type ipconfig in cmd and pick ipv4 address of Default switch.
- Second, Expose 1433(for local machine) or your DB port in DockerFile.
- Third, Write ```Data Source=<db machine ip>,<db port> ``` on Connection string.
- And finally buid your docker image & run container.

## 2. Overriding ASP Net Core settings with Environment Variables in a container

It is very typical to see something similar in asp.netcore applications like appsettings.Development.json, appsettings.Production.json. If you want to change development to production or vice versa without deploying whole code everytime. You can use Docker environment variable way. Using environment variable you can override or change appsettings file without deploy code everytime.

- Write bellow code in Startup.cs
```
var configuration = new ConfigurationBuilder()
  .AddJsonFile("appsettings.json")
  .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
  .AddEnvironmentVariables()
  .Build();
```
- Set environment variable with default value like,
```
ENV ASPNETCORE_ENVIRONMENT Development
```
- Build your image & run your container.
- If you want to override this default environment variable. Run bellow command,
```
docker run  -e "ASPNETCORE_ENVIRONMENT=Production" <your image name>
```
