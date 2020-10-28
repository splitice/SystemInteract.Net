set -e

DIR=~/repo
P=$DIR/$1

cd $P

if [ "${CIRCLE_PULL_REQUEST}" = "" ]; then
    dotnet pack *.nuspec -configuration Release

    dotnet nuget push *.nupkg --api-key $NUGET_API
fi