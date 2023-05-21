# Base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Set working directory
WORKDIR /app

# Copy the published output of the MVC project into the container
COPY ./* .

# Expose the port number that your application listens on
EXPOSE 5018

# Set the entry point for the container
ENTRYPOINT ["dotnet", "run"]