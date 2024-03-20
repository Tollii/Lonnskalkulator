FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Client/BlazorBasic.csproj", "Client/"]
RUN dotnet restore "Client/BlazorBasic.csproj"
COPY . .
WORKDIR "/src/Client"

RUN dotnet build "BlazorBasic.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorBasic.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.