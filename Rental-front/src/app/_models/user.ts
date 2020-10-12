import { Booking } from './booking';
export interface User {

    
    a_ID: number ;
    a_FIRST_NAME : string;
    a_LAST_NAME: string; 
    a_EMAIL: string; 
    a_BOOKING : Booking[];
    a_IS_ADMIN: boolean;

    
}