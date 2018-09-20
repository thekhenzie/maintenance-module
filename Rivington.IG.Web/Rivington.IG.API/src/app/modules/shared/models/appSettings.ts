export class AppSettings {
    defaultDateFormat?: string;
    environmentName?: string;
    canConnectToDB?: boolean;
    readyToPrintStatus?: string;
    imageSizes?: {
        main?: {
            height?: number;
            width?: number;
        },
        thumb?: {
            height?: number;
            width?: number;
        }
    };
    copyright?: string;
    appVersion?: string;
    jsMapApiKey?: string;
    
    public constructor(init?:Partial<AppSettings>) {
        Object.assign(this, init);
    }
}