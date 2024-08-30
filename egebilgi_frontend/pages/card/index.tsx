import { IGetCharactersResponse } from "@/models/responses/get_characters_response";
import { RootState } from "@/redux/store"
import { useRouter } from "next/router";
import { useEffect, useState } from "react"
import { useSelector } from "react-redux"


export default function CardPage(){
const cardData = useSelector((state : RootState) => state.Card.data);
const [data,setData] = useState<IGetCharactersResponse>({
    created: new Date(),
    createdTime: new Date(),
    episodes:[],
    gender:"",
    id:0,
    image:"",
    location:{
        characters:[],
        created:new Date(),
        createdTime:new Date(),
        dimension:"",
        name:"",
        type:"",
        url:""
    },
    locationId:0,
    name:"",
    origin:{
        createdTime:new Date(),
        name:"",
        url:""
    },
    originId:0,
    species:"",
    status:"",
    type:"",
    url:""
});

const router = useRouter();

useEffect(()=> {
    if(cardData.name != ""){
        setData(prevState => ({
            ...prevState,
            created:cardData.created,
            createdTime:cardData.createdTime,
            gender:cardData.gender,
            id:cardData.id,
            image:cardData.image,
            locationId:cardData.locationId,
            name:cardData.name,
            originId:cardData.originId,
            species:cardData.species,
            status:cardData.status,
            type:cardData.type,
            url:cardData.url,
            origin:{
                ...prevState.origin,
                name:cardData.origin.name,
                createdTime:cardData.origin.createdTime,
                url:cardData.origin.url
            },
            location:{
                ...prevState.location,
                characters:cardData.location.characters,
                created:cardData.location.created,
                createdTime:cardData.location.createdTime,
                dimension:cardData.location.dimension,
                name:cardData.location.name,
                type:cardData.location.type,
                url:cardData.location.url
            },
            episodes:cardData.episodes
        }));
    }
    else{
        router.push('/');
    }
},[])

return <div className="card">
    {
        data.name !== "" && data.name !== undefined ?
            <div className="card_page_body_main">   
                <div className="card_page_body_datas">
                    <div className="card_page_body_wrapper">
                        <div className="card_page_body_data">
                            <img src={data.image} alt="Conroy" />
                            <div className="card_page_body_data_right">
                                <div className="card_page_body_data_right_name">
                                    <h2>{data.name}</h2>
                                    <h3><span className={data.status == "Alive" ? "status_live" : "status_dead" }></span>{data.status} - {data.species}</h3>
                                </div>
                                <div className="card_page_body_data_right_location">
                                    <h4>Last known location:</h4>
                                    <h3>{data.origin.name.length > 25 ? `${data.origin.name.substring(0,25)}...` : data.origin.name}</h3>
                                </div>

                                <div className="card_page_body_data_right_firstseen">
                                    <h4>First seen in:</h4>
                                    <h3>{data.episodes[0].name.length > 25 ? `${data.episodes[0].name.substring(0,25)}...` : data.episodes[0].name}</h3>
                                </div>
                                
                            </div>

                            <div className="card_page_body_data_right">
                            <div className="card_page_body_data_right_location">
                                    <h4>Gender:</h4>
                                    <h3>{data.gender}</h3>
                                </div>
                                <div className="card_page_body_data_right_location">
                                    <h4>Species:</h4>
                                    <h3>{data.species}</h3>
                                </div>

                                <div className="card_page_body_data_right_firstseen">
                                    <h4>Type:</h4>
                                    <h3>{data.type == "" ? `unknown` : data.type}</h3>
                                </div>
                                
                            </div>

                            <div className="card_page_body_data_right">
                            <div className="card_page_body_data_right_location">
                                    <h4>Location Dimension:</h4>
                                    <h3>{data.location.dimension}</h3>
                                </div>
                                <div className="card_page_body_data_right_location">
                                    <h4>Location Name:</h4>
                                    <h3>{data.location.name}</h3>
                                </div>

                                <div className="card_page_body_data_right_firstseen">
                                    <h4>Location Type:</h4>
                                    <h3>{data.location.type}</h3>
                                </div>
                                
                            </div>

                            <div className="card_page_body_data_right">
                            <div className="card_page_body_data_right_location">
                                    <h4>Location Character Count:</h4>
                                    <h3>{data.location.characters.length}</h3>
                                </div>
                                <div className="card_page_body_data_right_location">
                                    <h4>Episodes Count:</h4>
                                    <h3>{data.episodes.length}</h3>
                                </div>

                                <div className="card_page_body_data_right_firstseen">
                                    <h4>First Episode Name:</h4>
                                    <h3>{data.episodes.at(0)?.name}</h3>
                                </div>
                                
                            </div>

                            <div className="card_page_body_data_right">
                            <div className="card_page_body_data_right_location">
                                    <h4>First Episode Section:</h4>
                                    <h3>{data.episodes.at(0)?.episode}</h3>
                                </div>
                                <div className="card_page_body_data_right_location">
                                    <h4>First Episode Date:</h4>
                                    <h3>{data.episodes.at(0)?.air_date}</h3>
                                </div>

                                <div className="card_page_body_data_right_firstseen">
                                    <h4>Created Date</h4>
                                    <h3>{data.created.toString()}</h3>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                    </div>
            </div>  : <></>
        }
</div>
}