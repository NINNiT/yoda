#!/usr/bin/env bash
set -euo pipefail

cd proxy && npm i && (npm run start &)
cd hat && python3 hat.py &
