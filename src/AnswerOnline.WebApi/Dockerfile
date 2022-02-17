#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/AnswerOnline.WebApi/AnswerOnline.WebApi.csproj", "src/AnswerOnline.WebApi/"]
COPY ["src/AnswerOnline.Swagger/AnswerOnline.Swagger.csproj", "src/AnswerOnline.Swagger/"]
COPY ["src/AnswerOnline.Application/AnswerOnline.Application.csproj", "src/AnswerOnline.Application/"]
COPY ["src/AnswerOnline.EntityFrameworkCore/AnswerOnline.EntityFrameworkCore.csproj", "src/AnswerOnline.EntityFrameworkCore/"]
COPY ["src/AnswerOnline.Domain/AnswerOnline.Domain.csproj", "src/AnswerOnline.Domain/"]
COPY ["src/AnswerOnline.Domain.Shared/AnswerOnline.Domain.Shared.csproj", "src/AnswerOnline.Domain.Shared/"]
COPY ["src/AnswerOnline.Toolkit/AnswerOnline.Toolkit.csproj", "src/AnswerOnline.Toolkit/"]
RUN dotnet restore "src/AnswerOnline.WebApi/AnswerOnline.WebApi.csproj"
COPY . .
WORKDIR "/src/src/AnswerOnline.WebApi"
RUN dotnet build "AnswerOnline.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AnswerOnline.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AnswerOnline.WebApi.dll"]