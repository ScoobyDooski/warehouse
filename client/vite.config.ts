import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

export default defineConfig({
    plugins: [react()],
    server: {
        port: 5173,
        proxy: {
            '/api': {
                target: 'https://localhost:5001', // your ASP.NET HTTPS port
                changeOrigin: true,
                secure: false
            }
        }
    },
    build: {
        outDir: '../server/wwwroot', // put index.html + assets here
        emptyOutDir: true
    }
})