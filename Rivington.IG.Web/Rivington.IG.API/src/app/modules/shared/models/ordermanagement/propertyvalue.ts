export interface IPropertyValue{
    id? : string;
    name? : string;
}

export class PropertyValue implements IPropertyValue{
    id? : string;
    name? : string;
    
    public constructor(init?:Partial<IPropertyValue>) {
        Object.assign(this, init);
    }
}