import { IGetCharactersResponse, IReduxForCardDatas } from "@/models/responses/get_characters_response";
import { createSlice } from "@reduxjs/toolkit";

const initialState : IReduxForCardDatas = {
    data:{
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
    }
    
}

export const cardSlicer = createSlice({
    name:"cardSlicer",
    initialState:initialState,
    reducers:{
        setCardData:(state,action) => {
            state.data = action.payload
        }
    }
})

export const {setCardData} = cardSlicer.actions;
export default cardSlicer.reducer;