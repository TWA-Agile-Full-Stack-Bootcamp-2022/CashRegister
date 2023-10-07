#!/bin/bash -e

cd $(dirname $0)/..

function get_coverage_xml_path()
{
    echo `dotnet test --collect:"XPlat Code Coverage" | tee /dev/tty | grep 'coverage.cobertura.xml'` | tr -d '[:space:]'
}

which reportgenerator
if [ $? -ne 0 ]; then
    echo -n "reportgenerator is not installed yet, do you want to install it?(y/n):"
    read ans
    if [ ${ans} = "y" ] ; then
        dotnet tool install -g dotnet-reportgenerator-globaltool
    fi
fi

echo '👉 Run tests and generate coverage.cobertura.xml...'
COVERAGE_XML_PATH=`get_coverage_xml_path`

echo "👉 Generate reports based on the coverage.cobertura.xml..."
TARGET_DIR=coveragereport
reportgenerator -reports:"${COVERAGE_XML_PATH}" -targetdir:"${TARGET_DIR}" -reporttypes:Html

open ${TARGET_DIR}/index.html
