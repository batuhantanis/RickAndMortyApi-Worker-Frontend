import axios, { AxiosResponse } from "axios";

const dockerUrl = `${process.env.NEXT_PUBLIC_API_DOCKER_URL}`;
const localUrl = `${process.env.NEXT_PUBLIC_API_LOCAL_URL}`;
export const httpClient = axios.create({
    baseURL:dockerUrl,
    headers:{
        "content-type": "application/json",
    }
})

const responseBody = <T>(response:AxiosResponse<T>) =>response?.data

export const useRequest = {
    get: <T>(url: string) => httpClient.get<T>(url).then(responseBody),
    post: <T>(url: string, body: {}) =>
      httpClient.post<T>(url, body).then(responseBody),
    postWithToken: <T>(url: string, body: {}, token: string) =>
      httpClient
        .post<T>(url, body, { headers: { Authorization: `Bearer ${token}` } })
        .then(responseBody),
    put: <T>(url: string, body: {}) =>
      httpClient.put<T>(url, body).then(responseBody),
    del: <T>(url: string) => httpClient.delete<T>(url).then(responseBody),
  };