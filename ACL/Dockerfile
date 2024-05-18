# Stage 1: Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 1234

# Stage 2: Build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy and restore solution files
COPY src/ACL/ACL.sln .

# Copy and build the ACL project
COPY src/ACL/ACL.csproj src/ACL/
RUN dotnet restore src/ACL/ACL.csproj
COPY . .
RUN dotnet build src/ACL/ACL.csproj -c Release -o /app/build

# Copy and build the SharedLibrary project
COPY SharedLibrary/SharedLibrary.csproj SharedLibrary/
RUN dotnet restore SharedLibrary/SharedLibrary.csproj
COPY . .
RUN dotnet build SharedLibrary/SharedLibrary.csproj -c Release -o /app/build

# Copy and build the test project
COPY test/ACL.TEST/ACL.TEST.csproj test/ACL.TEST/
RUN dotnet restore test/ACL.TEST/ACL.TEST.csproj
COPY . .
RUN dotnet build test/ACL.TEST/ACL.TEST.csproj -c Release -o /app/build

# Stage 3: Publish the project
FROM build AS publish
RUN dotnet publish src/ACL/ACL.csproj -c Release -o /app/publish

# Stage 4: Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ACL.dll"]
