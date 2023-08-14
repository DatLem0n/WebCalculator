#!/bin/env bash

# set output redirection (launch with DEBUG=1 for debug)
if [ $DEBUG ]; then
    REDIR_DEST=/dev/tty
else
    REDIR_DEST=/dev/null
fi

# kill processes when exiting
trap 'exit' INT TERM
trap 'kill 0' exit

# run the calculator
cd back/calculator
dotnet run &> "$REDIR_DEST" &
cd ../../front
python3 -m http.server 5051 &> "$REDIR_DEST" &
xdg-open http://localhost:5051/ &> "$REDIR_DEST"

# wait until user exits
echo -e "\e[32mPress Ctrl + C to quit."
sleep infinity
