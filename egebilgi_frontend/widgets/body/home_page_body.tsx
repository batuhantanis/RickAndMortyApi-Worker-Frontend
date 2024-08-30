import { FilterKey } from "@/core/enums/home_page_filter_enum";
import { GetAllCharacters } from "@/data/HomePage/GetAllCharacters"
import { IGetCharactersRequest } from "@/models/requests/get_characters_request"
import { IGetCharactersResponse } from "@/models/responses/get_characters_response";
import { setCardData } from "@/redux/slices/cardSlicer";
import { useRouter } from "next/router";
import { useEffect, useState } from "react"
import { Blocks } from 'react-loader-spinner'
import { useDispatch } from "react-redux";


export default function HomePageBody(){
    const [datas,setDatas] = useState<IGetCharactersResponse[]>([]);
    const [isLoading,setIsLoading] = useState<boolean>(false);
    const dispatch = useDispatch();
    const router = useRouter();
    const [pageNumber,setPageNumber] = useState(1);
    const [oldPageNumber,setOldPageNumber] = useState(1);
    const [activeKey,setActiveKey] = useState(4);
    useEffect(()=>{
        var request : IGetCharactersRequest = {
            pageNumber:0,
            take:10
        };
        GetAllCharacters(request,setDatas,setIsLoading);
    },[])

    const handleCardPage = (data:IGetCharactersResponse) => {
        setActiveKey(4);
        dispatch(setCardData(data));
        
        router.push('card')
    }
    const handlePageClick = (num:number) => {
        
        console.log(num);
        if ( num <= 82 && num > 1) {
            setActiveKey(4);  
            setPageNumber(num);
            var request : IGetCharactersRequest = {
                pageNumber:num,
                take:10
            };
            GetAllCharacters(request,setDatas,setIsLoading);
        }
    };
    const handleNextPageClick = () => {
        if(oldPageNumber < 82){
           setOldPageNumber(oldPageNumber+3);
        }
    };
    const handlePreviousPageClick = () => {
        if(oldPageNumber > 3){
            setOldPageNumber(oldPageNumber-3);
        }
    };
    const handleFilterData = (key:FilterKey) => {
        setActiveKey(key);
        let sortedData = [...datas];
        switch (key) {
            case 0:
                console.log("0. değere geldi");
                sortedData.sort((a,b) => {
                    if(a.origin.name.toLowerCase() < b.origin.name.toLowerCase()) return -1;
                    if(a.origin.name.toLowerCase() > b.origin.name.toLowerCase()) return 1;
                    return 0;
                })
                break;
            case 1:
                console.log("1. değere geldi");
                sortedData.sort((a,b) => {
                    if(a.episodes[0].name.toLowerCase() < b.episodes[0].name.toLowerCase()) return -1;
                    if(a.episodes[0].name.toLowerCase() > b.episodes[0].name.toLowerCase()) return 1;
                    return 0;
                })
                break;
            case 2:
                sortedData.sort((a,b) => {
                    if(a.status.toLowerCase() < b.status.toLowerCase()) return -1;
                    if(a.status.toLowerCase() > b.status.toLowerCase()) return 1;
                    return 0;
                })
                break;
            case 3:
                sortedData.sort((a,b) => {
                    if(a.status.toLowerCase() < b.status.toLowerCase()) return 1;
                    if(a.status.toLowerCase() > b.status.toLowerCase()) return -1;
                    return 0;
                })
                break;          
            default:
                break;
        }
        setDatas(sortedData);
    }
    return <div className="home_page_body_main">
        
        <div className="home_page_body_filter">
            
            <div className="filter_tag">
                <h3>Filters: </h3>
            </div>
            <div onClick={() => handleFilterData(FilterKey.LastKnownLocation)} className={`button ${activeKey === 0 ? 'active' : ''}`} >
                <h3>Last Known Location</h3>
            </div>
            <div onClick={() => handleFilterData(FilterKey.FirstSeenIn)} className={`button ${activeKey === 1 ? 'active' : ''}`}>
                <h3>First Seen in</h3>
            </div>
            <div onClick={() => handleFilterData(FilterKey.Alive)} className={`button ${activeKey === 2 ? 'active' : ''}`}>
                <h3>Alive</h3>
            </div>
            <div onClick={() => handleFilterData(FilterKey.Dead)} className={`button ${activeKey === 3 ? 'active' : ''}`}>
                <h3>Dead</h3>
            </div>
        </div>
        <div className="home_page_body_datas">
            {
                isLoading ? 
                datas.map((value,index) => (

                <div key={index} className="home_page_body_wrapper">
                    <div className="home_page_body_data">
                        <img src={value.image} alt="Conroy" />
                        <div className="home_page_body_data_right">
                            <div className="home_page_body_data_right_name">
                                <h2 onClick={() => handleCardPage(value)}>{value.name.length > 20 ? `${value.name.substring(0,20)}...` : value.name}</h2>
                                <h3><span className={value.status == "Alive" ? "status_live" : "status_dead" }></span>{value.status} - {value.species}</h3>
                            </div>
                            <div className="home_page_body_data_right_location">
                                <h4>Last known location:</h4>
                                <h3 onClick={() => handleCardPage(value)}>{value.origin.name.length > 25 ? `${value.origin.name.substring(0,25)}...` : value.origin.name}</h3>
                            </div>

                            <div className="home_page_body_data_right_firstseen">
                                <h4>First seen in:</h4>
                                <h3 onClick={() => handleCardPage(value)}>{value.episodes[0].name.length > 25 ? `${value.episodes[0].name.substring(0,25)}...` : value.episodes[0].name}</h3>
                            </div>
                            
                        </div>
                    </div>
                </div>
                
                ))
                
                :
                <div className="loader">  
                <Blocks
                height="80"
                width="80"
                color="#4fa94d"
                ariaLabel="blocks-loading"
                wrapperStyle={{}}
                wrapperClass="blocks-wrapper"
                visible={true}
                />
                </div>
                
            }
            
        </div>
        <div>
            <ul className="pagination">
                <li className="disabled">
                    <a onClick={(e) => {e.preventDefault(); handlePreviousPageClick()}}>Previous</a>
                </li>
                <li className="active">
                    <a onClick={(e) => {e.preventDefault(); handlePageClick(oldPageNumber)}}>{oldPageNumber}</a>
                </li>
                <li>
                    <a onClick={(e) => {e.preventDefault(); handlePageClick(oldPageNumber+1)}}>{oldPageNumber+1}</a>
                </li>
                <li>
                    <a onClick={(e) => {e.preventDefault(); handlePageClick(oldPageNumber+2)}}>{oldPageNumber+2}</a>
                </li>
                <li>
                    <a onClick={(e) => {e.preventDefault(); handleNextPageClick()}}>Next</a>
                </li>
            </ul>
            <div style={{alignItems:"end",textAlign:"end"}}>
                <h4 style={{color:"grey",padding:"0.2em 0.4em"}}>Page Number: {pageNumber}</h4>
            </div>
        </div>
    </div>
}