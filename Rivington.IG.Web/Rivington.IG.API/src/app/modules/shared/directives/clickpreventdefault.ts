import {Directive, HostListener} from "@angular/core";

@Directive({
    selector: "[click-prevent-default]"
})
export class ClickPreventDefault
{
    @HostListener("click", ["$event"])
    public onClick(event: any): void
    {
        event.preventDefault();
    }
}