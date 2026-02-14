export interface Props {
    children: React.ReactNode;
}
export default function AuthLayout({ children  }: Props) {
    return (
        <div className="min-h-screen flex bg-gradient-to-r from-cyan-600 to-blue-900">

            {/* Left Illustration Area */}
            <div className="hidden md:flex w-1/2 items-center justify-center p-10">
                <img
                    src="/Illustration1.webp"
                    className="w-full"
                    alt="finance illustration"
                />
            </div>

            {/* Right Form Area */}
            <div className="w-full md:w-1/2 flex items-center justify-center">
                {children}
            </div>

        </div>
    );
}