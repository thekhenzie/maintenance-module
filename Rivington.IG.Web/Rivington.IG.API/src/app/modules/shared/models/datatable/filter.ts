export interface IFilter {
    Field?: string;
    Operator?:
        'eq' | 'neq' | 'lt' | 'lte' | 'gt' | 'gte' | 'isnull' | 'isnotnull' | 'startswith' | 'endswith' |
        'contains' | 'doesnotcontain' | 'isempty' | 'isnotempty';
    Value?: string;
    Logic?: string;
    IsGlobal?: boolean;
    IsExactSearch?: boolean;    
    Filters?: Filter[];
}

export class Filter implements IFilter {
    // defaults
    public Field?: string;
    public Operator?: any = 'contains';
    public Value?: string;
    public Logic?: string = "and";
    public IsGlobal?: boolean = false;
    public IsExactSearch?: boolean = false;
    public Filters?: Filter[];
    
    public constructor(init?:Partial<IFilter>) {
        Object.assign(this, init);
    }
}