
import AdminNavbar from "../components/AdminNavbar";

export default function AdminLayout({ children }: { children: React.ReactNode }) {
  return (
    <div>
      <AdminNavbar />
      <div className="p-6">{children}</div>
    </div>
  );
}