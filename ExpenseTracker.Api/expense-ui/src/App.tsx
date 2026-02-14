import { BrowserRouter, Routes, Route } from "react-router-dom";
import AuthGuard from "./components/AuthGuard";
import LoginPage from "./pages/LoginPage";
import AdminDashboard from "./pages/admin/AdminDashboard";
import UsersPage from "./pages/admin/UserPage";
import CategoriesPage from "./pages/admin/CategoriesPage";
import RegisterUserPage from "./pages/admin/RegisterUserPage";

export default function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<LoginPage />} />
                <Route path="/admin" element={<AuthGuard><AdminDashboard /></AuthGuard>} />
                <Route path="/admin/users" element={<AuthGuard><UsersPage /></AuthGuard>} />
                <Route path="/admin/categories" element={<AuthGuard><CategoriesPage /></AuthGuard>} />
                <Route path="/admin/register" element={<AuthGuard><RegisterUserPage /></AuthGuard>} />
            </Routes>
        </BrowserRouter>
    );
}