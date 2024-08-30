export interface IGetCharactersResponse{
id:number,    
name:string,
status:string,
species:string,
type:string,
gender:string,
image:string,
url:string,
originId:number,
locationId:number,
created:Date,
createdTime:Date
origin:IOrigin,
location:ILocation,
episodes:IEpisode[]
}

export interface ILocation{
name:string,
type:string,
dimension:string,
url:string,
created:Date,
createdTime:Date,
characters:string[]
}

export interface IOrigin{
name:string,
url:string,
createdTime:Date
}

export interface IEpisode{
name:string,
air_date:string,
episode:string,
url:string,
created:Date,
createdTime:Date,
}

export interface IReduxForCardDatas{
    data:IGetCharactersResponse
}