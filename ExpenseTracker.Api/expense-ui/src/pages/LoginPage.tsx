import { useState } from "react";
import AuthLayout from "../layouts/AuthLayout";
import { authService, type LoginRequest } from "../services/authService";
import  { useNavigate } from "react-router-dom";

export default function LoginPage() {

    const [form, setForm] = useState<LoginRequest>({
        email: "",
        password: "",
    });
    const [error, setError] = useState<string>("");
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();
    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setForm({
            ...form,
            [e.target.name]: e.target.value,
        });
    };
    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            setLoading(true);
            setError("");
            await authService.login(form);

            navigate("/admin");

        } catch (err: unknown) {
            if (err instanceof Error) {
                setError(err.message);
            } else {
                setError("Something went wrong");
            }
        } finally {
            setLoading(false);
        }
    };
    return (
        <AuthLayout>
            <form
                onSubmit={handleSubmit}
                className="bg-blue-900 bg-opacity-40 p-10 rounded-xl w-96 text-white"
            >
                <h2 className="text-3xl font-bold text-center mb-8">
                    LOGIN
                </h2>

                {error && (
                    <p className="text-red-300 mb-4 text-center">
                        {error}
                    </p>
                )}

                <input
                    name="email"
                    placeholder="Email"
                    value={form.email}
                    onChange={handleChange}
                    className="w-full mb-5 p-2 bg-transparent border-b border-gray-300 focus:outline-none"
                />

                <input
                    name="password"
                    type="password"
                    placeholder="Password"
                    value={form.password}
                    onChange={handleChange}
                    className="w-full mb-5 p-2 bg-transparent border-b border-gray-300 focus:outline-none"
                />

                <button
                    disabled={loading}
                    className="w-full bg-green-500 hover:bg-green-600 p-2 rounded text-white font-semibold"
                >
                    {loading ? "Logging in..." : "LOGIN"}
                </button>
            </form>
        </AuthLayout>
    );
}