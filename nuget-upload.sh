set -e

DIR=~/repo
P=$DIR/$1

cd $P

if [ "${CIRCLE_PULL_REQUEST}" = "" ]; then
    dotnet  pack *.nuspec -Prop Configuration=Release -BasePath $P

    dotnet push *.nupkg -ApiKey $NUGET_API -Source https://www.nuget.org/api/v2/package
fi