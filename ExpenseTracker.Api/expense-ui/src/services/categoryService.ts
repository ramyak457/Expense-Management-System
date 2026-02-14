
const API = "http://localhost:5180/api/categories";

export const getCategories = async () =>
  (await fetch(API)).json();

export const createCategory = async (name: string) =>
{
  const response = await fetch(API, {
    method: "POST",
    headers: { "Content-Type": "application/json", Authorization: `Bearer ${localStorage.getItem("token")}` },
    body: JSON.stringify({ name }),
  });

    if (!response.ok) {
      throw new Error("Failed to create category");
    }
  
    return response.json();
}
