import Header from "../Header/Header"
import {useRouter} from 'next/router';
import Footer from "../Footer/Footer"
function MainLayout({ children }) {

  //
  const router = useRouter();
  const routes = ["/login", "/signup", "/signIn", "/landing"]

  return (
    <>
      {routes.includes(router.pathname) ? "" : <Header/>}
      <main>{children}</main>
      <Footer/>
    </>
  );
}

export default MainLayout;
