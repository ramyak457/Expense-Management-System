import { useEffect, useState } from "react";
import AdminLayout from "../../layouts/AdminLayout";
import { getCategories, createCategory } from "../../services/categoryService";

interface Category {
  id: number;
  name: string;
  createdAt: string;
}

export default function CategoriesPage() {

  const [list, setList] = useState<Category[]>([]);
  const [name, setName] = useState("");
  const [error, setError] = useState("");
  const [loading] = useState(false);

  useEffect(() => {
  const fetchCategories = async () => {
    try {
      const data = await getCategories();
      setList(data);
    } catch (err) {
      console.error(err);
    }
  };

  fetchCategories();
}, []);



  const add = async () => {
  if (!name.trim()) return;

  try {
    const newCategory = await createCategory(name);

    setList(prev => [...prev, newCategory]);
    setName("");

  } catch (err) {
    console.error(err);
    setError("Could not create category");
  }
};



  return (
    <AdminLayout>

      <h2 className="text-xl font-bold mb-4">
        Categories
      </h2>

      {error && (
        <div className="text-red-600 mb-3">
          {error}
        </div>
      )}

      <div className="flex gap-2 mb-4">
        <input
          value={name}
          onChange={e => setName(e.target.value)}
          className="border p-2 rounded w-64"
          placeholder="New category"
        />
        <button
          onClick={add}
          disabled={loading}
          className="bg-green-600 text-white px-4 rounded disabled:opacity-50"
        >
          {loading ? "Adding..." : "Add"}
        </button>
      </div>

      {list.length === 0 ? (
        <p className="text-gray-500">No categories available</p>
      ) : (
        <ul className="list-disc ml-4">
          {list.map(c => (
            <li key={c.id}>{c.name}</li>
          ))}
        </ul>
      )}

    </AdminLayout>
  );
}
