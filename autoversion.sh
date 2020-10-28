DIR=$(dirname "$0")
VERSION=$(git describe --abbrev=0 --tags)
REVISION=$(git log "$VERSION..HEAD" --oneline | wc -l)

function update_ai {
f="$1"

for nuspec in $f/*.nuspec; do
    if [[ -f "$nuspec" ]]; then
    echo "Processing nuspec file: $nuspec"
    padded=$(printf "%04d" $REVISION)
    sed -i.bak "s/\\\$version\\\$/$VERSION_STR-cibuild$padded/g" $nuspec
    fi
done
}

re="([0-9]+\.[0-9]+\.[0-9]+)"
if [[ $VERSION =~ $re ]]; then
VERSION_STR="${BASH_REMATCH[1]}"
echo "Version of $1 is now: $VERSION_STR"
update_ai $DIR/$1
fi