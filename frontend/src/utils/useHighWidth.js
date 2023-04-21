import { useState, useEffect } from "react";

function useHighWidth() {
  const [isHighWidth, setWidth] = useState(false);

  useEffect(() => {
    setWidth(window.innerWidth > 700);
  }, []);

  return isHighWidth;
}

export default useHighWidth;
