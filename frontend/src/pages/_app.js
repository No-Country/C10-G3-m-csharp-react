import "@/scss/styles/globals.scss";
import "../scss/base/barrelBase.scss";
import "../scss/views/barrelService.scss";
import Head from "next/head";
import MainLayout from "@/components/layout/layout";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import "boxicons/css/boxicons.min.css";

export default function App({ Component, pageProps }) {
  const queryClient = new QueryClient();

  return (
    <QueryClientProvider client={queryClient}>
      <MainLayout>
        <Head>
          <title>Inclusive</title>
          <meta name="description" content="Una app inclusiva" />
          <meta name="viewport" content="width=device-width, initial-scale=1" />
          
          <link rel="icon" href="/favicon.ico" />

          
          
        </Head>
        <Component {...pageProps} />
      </MainLayout>
    </QueryClientProvider>
  );
}
