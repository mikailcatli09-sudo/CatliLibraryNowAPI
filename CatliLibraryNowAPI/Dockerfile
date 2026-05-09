	FROM mcs.microsoft.com/dotnetaspnet:8.0 AS base
	WORKDIR /app
	EXPOSE 8080
	ENV ASPNETCORE_URLS=http ://+:8080

	FROM mcs.microsoft.com/dotnet/sdk:8.0 AS build
	WORKDIR /src
	COPY . .
	RUN dotnet restore
	RUN dotnet publish -c Release -o /app/out

	FROM base AS final
	WORKDIR /app
	COPY --from=build /app/out .
	ENTRYPOINT ["dotnet", "CatliLibraryNowAPI.dll"]S
