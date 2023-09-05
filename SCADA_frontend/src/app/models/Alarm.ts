export interface Alarm{
    Id : number
    AnalogInputId: string,
    Type: AlarmType,
    Priority : number,
    Limit: number,
    Value : number,
    isDeleted : boolean,
    TimeStamp : Date
}

export enum AlarmType{
    LOW, HIGH
}