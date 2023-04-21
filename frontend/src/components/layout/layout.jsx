import Header from "../Header/Header"
import {useRouter} from 'next/router';
import Footer from "../Footer/Footer"



function MainLayout({ children }) {

  const router = useRouter();
<<<<<<< HEAD
  const routes = ["/login", "/signup", "/signIn", "/landing", "/register" , "/frequent"]
=======
  const routes = ["/login", "/signIn", "/landing", "/register", "/frequent", "/somos"]
>>>>>>> 9e2f9d0c319692bd44157ff04379a0c9b23bbdf2

  return (
    <>
      {routes.includes(router.pathname) ? "" : <Header/>}
      <main>{children}</main>
      {routes.includes(router.pathname) ? "" :  <Footer/>}
    </>
  );
}

export default MainLayout;
