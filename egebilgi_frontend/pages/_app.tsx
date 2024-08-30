import AppLayout from "@/layouts/app_layout";
import { store } from "@/redux/store";
import "@/styles/home/home.css";
import type { AppProps } from "next/app";
import { Provider } from "react-redux";


export default function App({ Component, pageProps }: AppProps) {
  return <>
    <Provider store={store}>
        <AppLayout>
          <Component {...pageProps} />
        </AppLayout>
    </Provider>
  </>
}
