FROM microsoft/aspnetcore-build:2.0 AS builder
WORKDIR /build
COPY ./*.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -o /publish

FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=builder /publish .
ENTRYPOINT [ "dotnet" , "SecuredWebApi.dll" ]