
FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1-sdk
LABEL Name=titanapi-dotnetcore Version=0.0.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "titanapi-dotnetcore.dll"]
