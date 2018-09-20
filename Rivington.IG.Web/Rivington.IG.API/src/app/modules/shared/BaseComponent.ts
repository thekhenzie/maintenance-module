/// https://stackoverflow.com/a/43367791/1035039
// https://medium.com/@benlesh/rxjs-dont-unsubscribe-6753ed4fda87
import { Subject } from "rxjs";
import { OnDestroy } from "@angular/core";

export abstract class BaseComponent implements OnDestroy {
    protected stop$: Subject<boolean>;
    constructor() {
        this.stop$ = new Subject<boolean>();
        let f = this.ngOnDestroy;
        this.ngOnDestroy = () => {
            // without this I was getting an error if the subclass had
            // this.blah() in ngOnDestroy
            f.bind(this)();
            this.stop$.next(true);
            this.stop$.complete();
        };
    }
    /// placeholder of ngOnDestroy. no need to do super() call of extended class.
    ngOnDestroy() {}
}