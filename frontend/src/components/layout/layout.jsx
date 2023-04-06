import Header from "../Header/Header"
import Navbar from "../Navbar/Navbar";


function MainLayout({ children }) {
  return (
    <>
      <Header/>
      <main>{children}</main>
      <footer>footer</footer>
    </>
  );
}

export default MainLayout;
