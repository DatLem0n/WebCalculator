cd back/calculator
start cmd /k "dotnet run"
cd ../../front
start cmd /k "python3 -m http.server 5051"
timeout /t 3 /NOBREAK
start http://localhost:5051/
