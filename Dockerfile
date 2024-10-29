# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar os arquivos de solução e de projeto
COPY *.sln ./
COPY AvaliationEmployee.API/*.csproj AvaliationEmployee.API/
COPY AvaliationEmployee.Application/*.csproj AvaliationEmployee.Application/
COPY AvaliationEmployee.Core/*.csproj AvaliationEmployee.Core/
COPY AvaliationEmployee.Infrastructure/*.csproj AvaliationEmployee.Infrastructure/

# Restaurar as dependências
RUN dotnet restore

# Copiar todo o código-fonte e compilar a aplicação
COPY . .
WORKDIR /src/AvaliationEmployee.API
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Expor a porta que a aplicação usa (ajuste se necessário)
EXPOSE 80

# Definir o entrypoint
ENTRYPOINT ["dotnet", "AvaliationEmployee.API.dll"]
