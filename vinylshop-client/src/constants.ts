const PROD_BACKEND_API_URL = "https://sdi-2023-example.strangled.net/api"; //netlify url
const DEV_BACKEND_API_URL = "http://127.0.0.1:5181/api";

export const BACKEND_API_URL =
	process.env.NODE_ENV === "development" ? DEV_BACKEND_API_URL : PROD_BACKEND_API_URL;