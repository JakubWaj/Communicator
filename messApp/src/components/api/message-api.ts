import {AxiosInstance} from "axios";

export interface AddMessageRequest {
    "groupId": string,
    "content": string,
    "userId": string
}