import CategoryCard from "../categoryCard/categoryCard";
import CategorySkeleton from "../categorySkeleton/categorySkeleton";
import axios from "axios";
import { useQuery } from "@tanstack/react-query";

function CategoryList() {
  const { data, isLoading, error } = useQuery({
    queryKey: ["categories"],
    queryFn: async () => {
      const response = await axios
        .get("http://wachin93-001-site1.ftempurl.com/api/category")
        .then((res) => res);

      return response.data;
    },
  });

  if (error) {
    return <h1>Ha ocurrido un error: {error.message}</h1>;
  }

  if (isLoading) {
    return (
      <>
        {[...Array(8)].map((idx) => {
          return (
            <li key={idx}>
              <CategorySkeleton />
            </li>
          );
        })}
      </>
    );
  }

  return (
    <>
      {data &&
        data.map((e) => {
          return (
            <li key={e.id}>
              <CategoryCard data={e} />
            </li>
          );
        })}
    </>
  );
}

export default CategoryList;