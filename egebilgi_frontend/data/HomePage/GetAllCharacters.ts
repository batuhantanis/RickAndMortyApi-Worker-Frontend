import { useRequest } from "@/helpers/GenericServiceHelpers";
import { IGetCharactersRequest } from "@/models/requests/get_characters_request";
import { IBaseServiceResponse } from "@/models/responses/base_service_response";
import { IGetCharactersResponse } from "@/models/responses/get_characters_response";
import { Dispatch, SetStateAction } from "react";


export const GetAllCharacters = async(requests:IGetCharactersRequest,setState:Dispatch<SetStateAction<IGetCharactersResponse[]>>,setIsLoading : Dispatch<SetStateAction<boolean>> ) => {
    var response = await useRequest.post<IBaseServiceResponse<IGetCharactersResponse[]>>("GetCharacters",requests)
    console.log(response);
    setState(response.data);
    setIsLoading(response.data.length > 0 ? true : false);
    return response;
} 