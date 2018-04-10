FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY HolidayBooking.sln ./
COPY HolidayBooking.VacationService/HolidayBooking.VacationService/HolidayBooking.VacationService.csproj HolidayBooking.VacationService/HolidayBooking.VacationService/
COPY HolidayBooking.Vacation.Contract/HolidayBooking.Vacation.Contract.csproj HolidayBooking.Vacation.Contract/
COPY Domain/Domain.csproj Domain/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/HolidayBooking.VacationService/HolidayBooking.VacationService
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HolidayBooking.VacationService.dll"]
