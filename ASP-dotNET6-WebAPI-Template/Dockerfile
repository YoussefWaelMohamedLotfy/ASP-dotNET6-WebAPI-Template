#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ASP-dotNET6-WebAPI-Template/ASP-dotNET6-WebAPI-Template.csproj", "ASP-dotNET6-WebAPI-Template/"]
RUN dotnet restore "ASP-dotNET6-WebAPI-Template/ASP-dotNET6-WebAPI-Template.csproj"
COPY . .
WORKDIR "/src/ASP-dotNET6-WebAPI-Template"
RUN dotnet build "ASP-dotNET6-WebAPI-Template.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ASP-dotNET6-WebAPI-Template.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ASP-dotNET6-WebAPI-Template.dll"]