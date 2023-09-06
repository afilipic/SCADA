export interface Alarm{
    id : number
    analogInputId: string,
    type: AlarmType,
    priority : number,
    limit: number,
    value : number,
    isDeleted : boolean,
    timeStamp : Date
}

export enum AlarmType{
    LOW, HIGH
}