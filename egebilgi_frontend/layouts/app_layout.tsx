import { ReactNode } from "react"
import HomePageBody from "@/widgets/body/home_page_body";
import Footer from "@/widgets/footer/footer";
import Header from "@/widgets/header/header";
import { Poppins } from "next/font/google";
type prop = {
    children:ReactNode
}

const poppins = Poppins({weight:'400',subsets:['latin']});
export default function AppLayout({children}:prop){
    return <div className={poppins.className}>
        <Header />
        <div>{children}</div>
        <Footer />
    </div>
}