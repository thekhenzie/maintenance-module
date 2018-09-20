import { Injectable } from  '@angular/core';
import { Http, Response } from '@angular/http';
import { HttpClient, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import swal, { SweetAlertOptions } from 'sweetalert2';
import { Enumeration } from './enumeration';
import { SelectItem } from 'primeng/components/common/api';
import { FormGroup } from '@angular/forms';

@Injectable()
export default class Utils {
    constructor() {}

    static serializeParam(data: any) {
        let returnData = '';
        let count = 0;
        for (let i in data){
            if(count == 0){
                returnData += i+'='+data[i];
            }else{
                returnData += '&'+i+'='+data[i];
            }
            count = count + 1;
        }
        return returnData;
    }
    
    static getRouteParam(route: ActivatedRoute, routeParameterName: string): string {
        return route.snapshot.paramMap.get(routeParameterName);
    }

    //#region START blockUI

    static blockUI(): void {
        swal({
          text: "Please wait",
          allowOutsideClick: false,
          allowEscapeKey: false,
          showConfirmButton: false,
          customClass: "art-swal full-screen"
        });
        swal.showLoading();
    }

    static unblockUI(): void {
        swal.close();
    }

    //#endregion END blockUI

    //#region START alert messages
    
    private static showNotice(
        options: string|SweetAlertOptions, 
        defaults: SweetAlertOptions, 
        callback: () => any = null): void {

        let opts: any = {};
        if (options && typeof options === "string") {
            opts.text = options as string;
        }

        Object.assign(opts, defaults, options || {});

        swal(opts).then((result) => {
            if(callback) {
                setTimeout(callback);
            }
        });
    }

    static showSuccess(options: string|SweetAlertOptions, callback: () => any = null): void {
        let defaults: any = {
            title: "Great!",
            type: "success"
        };
        this.showNotice(options, defaults, callback);
    }
    
    static showError(options: string|SweetAlertOptions, callback: () => any = null): void {
        let defaults: any = {
            title: "Oops!",
            type: "error"
        };
        this.showNotice(options, defaults, callback);
    }
    
    static showGenericHttpErrorResponse(httpErrorResponse: HttpErrorResponse, options: SweetAlertOptions = {}, callback: () => any = null): void {
        options.html = `
            <div class="swal-generic-http-error-response text-left">
            <h2 class="sub-header">Well, this is unexpected...</h2>
            <div class="content small">
                <p>
                Error code: <mark class="status-code">${httpErrorResponse.status}</mark>
                </p>
                <p>
                Error message: <mark class="status-message">${httpErrorResponse.error}</mark>
                </p>
                <p>
                An error has occurred and we're working to fix the problem!
                </p>
                <p>
                Apologies for the inconvenience. Thanks for your patience!
                </p>
            </div>
            </div>
            `;

        this.showError(options, callback);
    }
    
    static showWarning(options: string|SweetAlertOptions, callback: () => any = null): void {
        let defaults: any = {
            title: "Oops!",
            type: "warning"
        };
        this.showNotice(options, defaults, callback);
    }
    
    //#endregion END alert messages

    static convertEnumerableListToSelectItemList(list: Enumeration[]): SelectItem[] {
        let convertedList: SelectItem[] = [];
        
        for (const item of list) {
            convertedList.push({          
                label: item.name,
                value: item.id
            });
        }
        
        return convertedList;
    }

    static stringArrayToGenericTypeWithIdOnly(idPropertyName: string, list: string[]): any[] {
        if (!!!idPropertyName || !!!list) return [];

        let genericTypes: any[] = [];

        list.forEach(item => {
            let type = {};
            type[idPropertyName] = item;

            genericTypes.push(type);
        });

        return genericTypes;
    }

    static genericTypeArrayToStringOfIds(idPropertyName: string, list: any[]): string[] {
        if (!!!idPropertyName || !!!list) return [];
        
        let stringIdArray: string[] = [];

        list.forEach(item => {
            stringIdArray.push(item[idPropertyName]);
        });

        return stringIdArray;
    }

    static updateFormGroup(group: FormGroup, jsonValues: any): void {
        if (!!!group || !!!jsonValues) return null;
        
        for (let key in jsonValues) {
            if (jsonValues.hasOwnProperty(key)) {
                let formControl = group.get(key);
                if(formControl) {
                    try {
                        formControl.setValue(jsonValues[key]);
                    } catch (error) {
                        let dummy = null;
                    }
                }
            }
        }
    }

    static getLabelOfSelectItemByValue(list: SelectItem[], value: string): string {
        let label = "";
        if (!!!list || !!!value) return label;
        
        list.some(item => {
            if(item.value === value) {
                label = item.label;
                return true;
            }
            return false;
        });
        
        return label;
    }
}
