import { Link } from "react-router-dom";
import { authService } from "../services/authService";

export default function Navbar() {
  const roles = authService.getRoles();

  return (
    <nav className="bg-blue-800 text-white p-4 flex justify-between">
      <div className="font-bold">Expense Management System</div>

      <div className="flex gap-4">
        {roles.includes("Admin") && (
          <Link to="/admin" className="hover:underline">Admin</Link>
        )}

        {roles.includes("Manager") && (
          <Link to="/manager" className="hover:underline">Manager</Link>
        )}

        {roles.includes("Employee") && (
          <Link to="/employee" className="hover:underline">Employee</Link>
        )}

        <button
          onClick={() => {
            authService.logout();
            window.location.href = "/";
          }}
          className="ml-4 text-red-200"
        >
          Logout
        </button>
      </div>
    </nav>
  );
}
