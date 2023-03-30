import { useRouter } from "next/router";

function Category() {
  const router = useRouter();
  const { id } = router.query;

  return (
    <div>
      <h1>Category</h1>
      <p>{id}</p>
    </div>
  );
}

export default Category;
