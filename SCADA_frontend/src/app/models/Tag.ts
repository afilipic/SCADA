import { Data } from "@angular/router"
import { Alarm } from "./Alarm"

export interface Tag{
    Id : string,
    Description : string,
    Address : number,
}

export interface DOTag extends Tag{
    InitialValue: number,
    Value: number
}


export interface DITag extends Tag{
    DriverType : DriverType,
    ScanTime: Date,
    isScanning: boolean
    Value: number
}

export interface AOTag extends Tag{
    LowLimit: number,
    HighLimit: number,
    Units: string,
    InitialValue: number,
    Value: number
}

export interface AITag extends Tag{
    LowLimit: number,
    HighLimit: number,
    Units: string,
    DriverType : DriverType,
    ScanTime: Date,
    isScanning: boolean,
    Value: number,
    Alarms: Alarm[]

}

export enum DriverType{
    RTU, SIMULATION
}