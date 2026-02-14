import AdminLayout from "../../layouts/AdminLayout";
import { useNavigate } from "react-router-dom";

export default function AdminDashboard() {
  const navigate = useNavigate();

  return (
    <AdminLayout>

      <h1 className="text-2xl font-bold mb-6">
        Admin Dashboard
      </h1>

      <div className="bg-gradient-to-r from-blue-500 to-purple-600 w-full grid grid-cols-1 md:grid-cols-3 gap-6">

        <div
          onClick={() => navigate("/admin/users")}
          className="p-6 border rounded shadow cursor-pointer hover:bg-gray-50"
        >
          <h2 className="text-lg font-semibold">User Management</h2>
          <p className="text-sm text-gray-600">
            View all users, roles and managers
          </p>
        </div>

        <div
          onClick={() => navigate("/admin/categories")}
          className="p-6 border rounded shadow cursor-pointer hover:bg-gray-50"
        >
          <h2 className="text-lg font-semibold">Categories</h2>
          <p className="text-sm text-gray-600">
            Manage expense categories
          </p>
        </div>

        <div
          onClick={() => navigate("/admin/register")}
          className="p-6 border rounded shadow cursor-pointer hover:bg-gray-50"
        >
          <h2 className="text-lg font-semibold">Register User</h2>
          <p className="text-sm text-gray-600">
            Create new employee / manager / admin
          </p>
        </div>

      </div>

    </AdminLayout>
  );
}
