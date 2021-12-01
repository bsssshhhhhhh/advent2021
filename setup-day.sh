#!/bin/bash

DAY_DIR="day $1"

mkdir "$DAY_DIR"
cd "$DAY_DIR"

dotnet new console --name part1
dotnet add part1/part1.csproj reference ../common/common.csproj
touch part1/input.txt

dotnet new console --name part2
dotnet add part2/part2.csproj reference ../common/common.csproj
touch part2/input.txt

find . -name Program.cs | xargs sed -i '/using System;/a using AdventCommon;'
find . -name Program.cs | xargs sed -i 's/Console.WriteLine("Hello World!");/var lines = ConsoleHelpers.ReadInput();/'

cd ..