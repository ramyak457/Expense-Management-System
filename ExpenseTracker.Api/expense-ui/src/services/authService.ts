export interface LoginRequest {
    email: string;
    password: string;
}

export interface LoginResponse {
    token: string;
    roles: string[];
    email: string;
}
export interface RegisterRequest {
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    role: string;
    managerId?: string;
}
function getTokenExpiry(token: string): number | null {
  try {
    const payload = JSON.parse(atob(token.split(".")[1]));
    return payload.exp;    
  } catch {
    return null;
  }
}

const API_URL = "http://localhost:5180/api/auth";

export const authService = {
    async login(data: LoginRequest): Promise<LoginResponse> {
        const res = await fetch(`${API_URL}/login`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(data),
        });
        if (!res.ok) {
            throw new Error("Invalid credentials");
        }
        const result: LoginResponse = await res.json();

        localStorage.setItem("token", result.token);
        localStorage.setItem("roles", JSON.stringify(result.roles));
        localStorage.setItem("email", result.email);

        return result;
    },
    logout() {
        localStorage.clear();
    },

    getToken() {
        return localStorage.getItem("token");
    },
    isTokenExpired() {
        const token = this.getToken();
        if (!token) return true;

        const exp = getTokenExpiry(token);
        if (!exp) return true;

        const now = Math.floor(Date.now() / 1000);
        return now > exp;
    },

    getRoles(): string[] {
        const roles = localStorage.getItem("roles");
        return roles ? JSON.parse(roles) : [];
    },
    hasRole(role: string): boolean {
        return this.getRoles().includes(role);
    },
    getEmail(){
        return localStorage.getItem("email") || "";
    },

    isAuthenticated(): boolean {
        return !!localStorage.getItem("token");
    },
};
export async function registerUser(data: RegisterRequest) {
  const response = await fetch(`${API_URL}/register`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${authService.getToken()}`
    },
    body: JSON.stringify(data)
});
 if (!response.ok) {
    throw new Error("Registration failed");
  }

  return response.json();
}
