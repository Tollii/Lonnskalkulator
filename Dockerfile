FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Client/SalaryCalculator.csproj", "Client/"]
RUN dotnet restore "Client/SalaryCalculator.csproj"
COPY . .
WORKDIR "/src/Client"

RUN dotnet build "SalaryCalculator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SalaryCalculator.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.