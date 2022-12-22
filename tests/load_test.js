import http from 'k6/http';
import { sleep } from 'k6';

// Configuration options for the load test.
export const options = {
    duration: '1m',
    vus: 150,
    thresholds: {
        http_req_failed: ['rate<0.1'],
        http_req_duration: ['p(95)<200','p(99)<300'],
        checks: 
    },
}

// Script for load test:
export default function() {
    // Local:
    //const res = http.get('http://10.136.0.115:80/movies-service/api/Movies')
    // Azure:
    const res = http.get('http://20.238.149.147/movies-service/api/Movies');
    sleep(1);
}