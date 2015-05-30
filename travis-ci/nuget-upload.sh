#!/bin/bash

set -e

DIR=$(dirname "$0")

cd $DIR/../SystemInteract

mono ../.nuget/NuGet.exe pack SystemInteract.csproj -Prop Configuration=Release

mono ../.nuget/NuGet.exe setApiKey $NUGET_API

mono ../.nuget/NuGet.exe push *.nupkg