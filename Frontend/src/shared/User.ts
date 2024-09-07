
export class User {
    public id: string;
    public first_name: string;
    public last_name: string;
    public email: string;
    public date_created: string;
}

export class UserDTO {    
    public first_name: string;
    public last_name: string;
    public email: string;
    public date_created: Date = new Date;
}