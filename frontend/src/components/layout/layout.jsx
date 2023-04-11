import Header from "../Header/Header"
import {useRouter} from 'next/router';

function MainLayout({ children }) {

  //
  const router = useRouter();
  const routes = ["/login", "/signup", "/signIn", "/landing"]

  return (
    <>
      {routes.includes(router.pathname) ? "" : <Header/>}
      <main>{children}</main>
      <footer>footer</footer>
    </>
  );
}

export default MainLayout;
