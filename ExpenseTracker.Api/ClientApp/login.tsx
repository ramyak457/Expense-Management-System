import React, { useState } from "react";

export default function Login() {

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");

    const handleLogin = async (e: any) => {
        e.preventDefault();

        const res = await fetch("/api/auth/login", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ email, password })
        });

        if (!res.ok) {
            setError("Invalid login");
            return;
        }

        const data = await res.json();
        localStorage.setItem("token", data.token);

        window.location.href = "/Home/Dashboard";
    };

    return (
        <div>
            <h2>Login</h2>

            {error && <div style={{ color: 'red' }}>{error}</div>}

            <form onSubmit={handleLogin}>
                <input
                    placeholder="email"
                    value={email}
                    onChange={e => setEmail(e.target.value)}
                />

                <input
                    type="password"
                    placeholder="password"
                    value={password}
                    onChange={e => setPassword(e.target.value)}
                />

                <button>Login</button>
            </form>
        </div>
    );
}


