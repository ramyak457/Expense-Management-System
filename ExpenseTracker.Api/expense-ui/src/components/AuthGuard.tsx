import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { authService } from "../services/authService";

export default function AuthGuard({ children }: { children: React.ReactNode }) {
  const navigate = useNavigate();

  useEffect(() => {
    if (authService.isTokenExpired()) {
      authService.logout();
      navigate("/login");
    }
  }, []);

  return children;
}
