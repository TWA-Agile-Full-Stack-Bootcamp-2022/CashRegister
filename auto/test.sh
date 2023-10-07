#!/bin/bash

cd $(dirname $0)/..

# See https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-watch
dotnet watch test --project *Test/*Test.csproj
