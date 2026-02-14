import Navbar from "../components/Navbar";

interface Props {
  children: React.ReactNode;
}

export default function AppLayout({ children }: Props) {
  return (
    <div>
      <Navbar />

      <div className="p-6">
        {children}
      </div>
    </div>
  );
}
