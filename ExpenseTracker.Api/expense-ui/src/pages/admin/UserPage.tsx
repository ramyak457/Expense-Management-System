import { useEffect, useState } from "react";
import AdminLayout from "../../layouts/AdminLayout";
import { getUsers } from "../../services/userService";
import Pagination from "../../components/pagination";

interface User {
  id: number;
  name: string;
  email: string;
  role: string;
  managerName?: string;
}

export default function UsersPage() {
  const [users, setUsers] = useState<User[]>([]);
  const [totalPages, setTotalPages] = useState(1);
  const [page, setPage] = useState(1);

  useEffect(() => {
    getUsers(page).then(res => {
        setUsers(res.items.filter((u: User) => u.role !== "Administrator"));
        setTotalPages(res.totalPages);
    })
  }, [page]);

  return (
    <AdminLayout>
      <h2 className="text-xl font-bold mb-4">Users</h2>
      <table className="w-full border">
        <thead>
          <tr className="bg-gray-100">
            <th>Name</th>
            <th>Email</th>
            <th>Role</th>
            <th>Manager</th>
          </tr>
        </thead>

        <tbody>
          {users.map(u => (
            <tr key={u.id} className="border-t">
              <td>{u.name}</td>
              <td>{u.email}</td>
              <td>{u.role}</td>
              <td>{u.managerName}</td>
            </tr>
          ))}
        </tbody>
      </table>

      <Pagination page={page} setPage={setPage} totalPages={totalPages} />
    </AdminLayout>
  );
}
