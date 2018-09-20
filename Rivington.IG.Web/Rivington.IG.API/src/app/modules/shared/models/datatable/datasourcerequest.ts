import { ISort } from "./sort";
import { Filter } from "./filter";

export interface IDataSourceRequest {
    Take?: number;
    Skip?: number;
    Sort?: ISort[];
    Filter?: Filter;
}

export class DataSourceRequest implements IDataSourceRequest {
    // defaults
    public Take: number = 0;
    public Skip: number = 0;
    public Sort: ISort[] = [];
    public Filter: Filter = new Filter();

    public constructor(init?:Partial<IDataSourceRequest>) {
        Object.assign(this, init);
    }
}