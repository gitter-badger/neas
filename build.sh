#!/bin/bash
# Build script to build the .NET Application Embedded Server


# Remove old binaries and create new folder
rm -r bin
mkdir bin

# Build root namespace
mcs -t:library -out:bin/nea.dll src/Nea/*.cs

# Build kernel
mcs -t:library -out:bin/nea.core.dll -r:bin/nea.dll src/Nea.Core/*.cs

# Build application server
mcs -out:bin/neas.exe -r:bin/nea.dll,bin/nea.core.dll src/Nea.Server/Program.cs



# Build native libraries
mono --aot bin/*
