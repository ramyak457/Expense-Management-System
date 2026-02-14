import { Link, useNavigate } from "react-router-dom";
import { authService } from "../services/authService";

export default function AdminNavbar() {
  const email = authService.getEmail()=="" ? "Admin" : authService.getEmail();
  const navigate = useNavigate();
  return (
    <nav className="bg-blue-900 text-white p-4 flex gap-6">
      <div className="flex gap-6">
        <Link to="/admin" className="font-bold">Admin Dashboard</Link>
        <Link to="/admin/users">Users</Link>
        <Link to="/admin/categories">Categories</Link>
        <Link to="/admin/register">Register User</Link>
      </div>
      <div className="ml-auto flex items-center gap-4">
        <span className="text-sm text-gray-200">
          {email}
        </span>
        <button
          onClick={() => {
            authService.logout()
            navigate("/")
          }}
          className="bg-red-600 px-3 py-1 rounded hover:bg-red-700"
        >
          Logout
        </button>
      </div>
    </nav>
  );
}
