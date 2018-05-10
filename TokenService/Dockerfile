FROM microsoft/dotnet:2.1-sdk-alpine AS builder
ENV DOTNET_CLI_TELEMETRY_OPTOUT 1
WORKDIR /build
COPY ./*.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -o /publish -c Release

FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=builder /publish .
ENTRYPOINT [ "dotnet" , "TokenService.dll" ]