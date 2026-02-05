import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";

export default defineConfig({
    plugins: [react()],
    build: {
        outDir: "wwwroot/js",
        rollupOptions: {
            input: "ClientApp/main.tsx",
            output: {
                entryFileNames: "login.js"
            }
        }
    }
});
