set -e

DIR=~/repo
P=$DIR/$1

cd $P

if [ "${CIRCLE_PULL_REQUEST}" = "" ]; then
    #dotnet pack --configuration Release  *.csproj

    dotnet nuget push *.nuspec --api-key $NUGET_API -s https://api.nuget.org/v3/index.json
fi