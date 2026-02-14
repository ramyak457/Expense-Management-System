interface Props {
  page: number;
  setPage: (p: number) => void;
  totalPages?: number;     // optional – you can extend later
}

export default function Pagination({ page, setPage, totalPages = 10 }: Props) {

  const prev = () => {
    if (page > 1) setPage(page - 1);
  };

  const next = () => {
    if (page < totalPages) setPage(page + 1);
  };

  return (
    <div className="flex items-center justify-center gap-4 mt-4">

      <button
        onClick={prev}
        disabled={page === 1}
        className="px-3 py-1 border rounded disabled:opacity-40"
      >
        Previous
      </button>

      <span className="font-semibold">
        Page {page}
      </span>

      <button
        onClick={next}
        disabled={page === totalPages}
        className="px-3 py-1 border rounded disabled:opacity-40"
      >
        Next
      </button>

    </div>
  );
}
