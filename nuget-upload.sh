set -e

DIR=~/repo
P=$DIR/$1

cd $P

if [ "${CIRCLE_PULL_REQUEST}" = "" ]; then
    #dotnet pack --configuration Release  *.csproj
    cat *.nuspec
    dotnet nuget push *.nuspec --api-key $NUGET_API -s https://www.nuget.org/api/v2/package
fi