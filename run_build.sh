#!/bin/bash

# Path to the CSProj file
CS_PROJ_PATH="MyGame.csproj"

echo "Cleaning the project..."
dotnet clean $CS_PROJ_PATH

echo "Building the project..."
dotnet build $CS_PROJ_PATH
