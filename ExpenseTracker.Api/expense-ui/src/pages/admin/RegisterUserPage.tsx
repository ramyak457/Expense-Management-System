import { useEffect, useState } from "react";
import AdminLayout from "../../layouts/AdminLayout";
import { getUsers } from "../../services/userService";
import { registerUser } from "../../services/authService";

interface User {
  id: string;
  name: string;
  email: string;
  role: string;
}

export default function RegisterUserPage() {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [role, setRole] = useState("Employee");
  const [managerId, setManagerId] = useState("");
  const [managers, setManagers] = useState<User[]>([]);
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const loadManagers = async () => {
      try {
        const data = await getUsers(); 
        const managerUsers = data.items.filter(
          (u: User) => u.role === "Manager"
        );
        setManagers(managerUsers);
      } catch (err) {
        console.error(err);
      }
    };

    loadManagers();
  }, []);

   const handleSubmit = async () => {
    try {
      setLoading(true);
      setError("");

      await registerUser ({
        firstName,
        lastName,
        email,
        password,
        role,
        managerId
      });

      // Clear form after success
      setFirstName("");
      setLastName("");
      setEmail("");
      setRole("Employee");
      setManagerId("");

    } catch (err) {
      console.error(err);
      setError("Failed to register user");
    } finally {
      setLoading(false);
    }
  };

  return (
    <AdminLayout>
      <h2 className="text-xl font-bold mb-4">Register User</h2>
      {error && <div className="text-red-600 mb-3">{error}</div>}

      <div className="grid gap-3 max-w-md">
        <input className="border p-2 rounded" placeholder="First Name" value={firstName}
          onChange={e => setFirstName(e.target.value)}
        />
        <input className="border p-2 rounded" placeholder="Last Name" value={lastName}
          onChange={e => setLastName(e.target.value)}
        />
        <input className="border p-2 rounded" placeholder="Email" value={email}
          onChange={e => setEmail(e.target.value)}
        />
         <input className="border p-2 rounded" placeholder="Password" value={password}
          onChange={e => setPassword(e.target.value)}
        />
        <select className="border p-2 rounded" value={role} onChange={e => setRole(e.target.value)}>
          <option>Employee</option>
          <option>Manager</option>
          <option>Admin</option>
        </select>

        {role === "Employee" && (
          <select className="border p-2 rounded" value={managerId} onChange={e => setManagerId(e.target.value)}
          >
            <option value="">Select Manager</option>
            {managers.map(m => (
              <option key={m.id} value={m.id}>
                {m.name} ({m.email})
              </option>
            ))}
          </select>
        )}

        <button onClick={handleSubmit} disabled={loading} className="bg-blue-700 text-white p-2 rounded disabled:opacity-50">
          {loading ? "Creating..." : "Create User"}
        </button>
      </div>
    </AdminLayout>
  );
}
