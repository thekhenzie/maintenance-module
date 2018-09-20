import { OnInit } from "@angular/core";

export interface IColumn {
    field?: string;
    header?: string;
    sortable?: boolean;
    visible?: boolean;
    width?: string;

    renderStyleWidth(): string;
}

export class Column implements IColumn {
    // defaults
    public field = '';
    public header = '';
    public sortable = true;
    public visible = true;
    public width = 'auto';

    public constructor(init?:Partial<IColumn>) {
        Object.assign(this, init);
    }

    public renderStyleWidth(): string {
        return this.width === 'auto' ? 'auto' : this.width + 'px'
    }
}