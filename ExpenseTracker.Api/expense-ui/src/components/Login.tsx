export default function Login() {
    return (
        <div className="bg-blue-900 bg-opacity-40 p-10 rounded-xl w-96 text-white">

            <h2 className="text-3xl font-bold text-center mb-8">
                LOGIN
            </h2>

            <input
                placeholder="Email"
                className="w-full mb-5 p-2 bg-transparent border-b border-gray-300 focus:outline-none"
            />

            <input
                type="password"
                placeholder="Password"
                className="w-full mb-5 p-2 bg-transparent border-b border-gray-300 focus:outline-none"
            />

            <button className="w-full bg-green-500 hover:bg-green-600 p-2 rounded text-white font-semibold">
                LOGIN
            </button>

        </div>
    );
}