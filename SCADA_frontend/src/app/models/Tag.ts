import { Data } from "@angular/router"
import { Alarm } from "./Alarm"

export interface Tag{
    id : string,
    description : string,
    address : number,
    value: number,
}

export interface DOTag extends Tag{
    initialValue: number,
}


export interface DITag extends Tag{
    driverType : DriverType,
    scanTime: Date,
    isScanning: boolean
}

export interface AOTag extends Tag{
    lowLimit: number,
    highLimit: number,
    units: string,
    initialValue: number,
}

export interface AITag extends Tag{
    lowLimit: number,
    highLimit: number,
    units: string,
    driverType : DriverType,
    scanTime: Date,
    isScanning: boolean,
    alarms: Alarm[]

}

export enum DriverType{
    RTU, SIMULATION
}