FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
COPY *.sln .
COPY /src/Otus.Crud/Otus.Crud.csproj src/Otus.Crud/
RUN dotnet restore src/Otus.Crud/Otus.Crud.csproj
COPY . ./
RUN dotnet publish -c Release -o publish
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
EXPOSE 8000
ENV ASPNETCORE_URLS=http://*:8000
COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "Otus.Crud.dll"]
