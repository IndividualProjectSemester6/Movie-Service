docker-compose -f docker-compose.yml up --no-recreate -d
Write-Output "--------------------------------------------------------------------------------------"
Write-Output "Load testing with Grafana dashboard http://localhost:3000/"
Write-Output "--------------------------------------------------------------------------------------"
k6 run /tests/load_test.js --out json=test.json --out influxdb=http://localhost:8089/moviesservice