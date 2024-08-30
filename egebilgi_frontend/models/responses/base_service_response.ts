export interface IBaseServiceResponse<T>{
    data:T,
    message:string,
    isSuccessfull:boolean
}