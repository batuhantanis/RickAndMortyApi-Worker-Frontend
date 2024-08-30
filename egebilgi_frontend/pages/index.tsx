import { IGetCharactersResponse } from "@/models/responses/get_characters_response";
import HomePageBody from "@/widgets/body/home_page_body";
import { Poppins } from "next/font/google";



const poppins = Poppins({weight:'400',subsets:['latin']});

export default function Home() {
  return (
    <div className={poppins.className}>
      <HomePageBody/>
    </div>
  )
}
