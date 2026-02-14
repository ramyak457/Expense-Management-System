import { authService } from "./authService";

const API = "http://localhost:5180/api/users";

export async function getUsers(page = 1) {
  const response = await fetch(`${API}?page=${page}`, {
  headers: {
    Authorization: `Bearer ${localStorage.getItem("token")}`,
  }
});

  if (response.status === 401) {
    authService.logout();
    window.location.href = "/";
  }

  if (!response.ok) {
    throw new Error("Failed to fetch users");
  }

  return response.json();
}

