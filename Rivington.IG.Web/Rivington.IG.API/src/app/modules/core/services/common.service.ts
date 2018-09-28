import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions } from '@angular/http';
import { HttpClient, HttpParams, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { UrlSegment } from '@angular/router';
import { AuthService } from './auth.service';
import { Constants } from '../../shared/constants';
import { IDataSourceRequest } from '../../shared/models/datatable/datasourcerequest';
import { IFilter, Filter } from '../../shared/models/datatable/filter';
import { Observable } from 'rxjs/Observable';
import { SelectItem } from 'primeng/primeng';
import { Enumeration } from '../../shared/enumeration';
import Utils from '../../shared/Utils';

@Injectable()
export class CommonService {
    constructor(private http: HttpClient, private _authService: AuthService) { }

    postGenericList<T>(
        serviceName: string,
        event: any,
        allColumnsFilter: string,
        columns: string[],
        additionalFilters: Filter[] = null,
        additionalData: any = null): Observable<T> {

        let param: IDataSourceRequest = {
            Take: event.rows,
            Skip: event.first
        };

        if (event.multiSortMeta) {
            param.Sort = [];
            for (let sortMeta of event.multiSortMeta) {
                param.Sort.push({
                    Field: sortMeta.field,
                    Dir: sortMeta.order === 1 ? 'asc' : 'desc'
                });
            }
        }

        if (allColumnsFilter) {
            // if enclosed with double quotes
            let isExactSearch = allColumnsFilter.startsWith("\"") && allColumnsFilter.endsWith("\"");
            if (isExactSearch) {
                allColumnsFilter = allColumnsFilter.substring(1, allColumnsFilter.length - 1)
            }
            if (allColumnsFilter) {
                param.Filter = new Filter({
                    Field: columns.join(","),
                    Operator: "contains",
                    Value: allColumnsFilter,
                    Logic: "and",
                    IsGlobal: true,
                    IsExactSearch: isExactSearch,
                    Filters: []
                });
            }
            // // use this if filter has a per column filtering
            // for(let column of columns) {
            //     param.Filter.Filters.push({
            //         Field: column,
            //         Operator: "contains",
            //         Value: filter,
            //         Logic: "or"
            //     });
            // }
        }

        if (additionalFilters && additionalFilters.length) {
            param.Filter = param.Filter || new Filter({
                Logic: "and",
                Filters: []
            });
            param.Filter.Filters = param.Filter.Filters.concat(additionalFilters);
        }

        let dataParam = Object.assign({}, additionalData || {}, {
            dataSourceRequest: param
            // ScheduledDate: additionalData
        });

        return this.http.post(`${Constants.ApiUrl}/${serviceName}/`, dataParam)
            .map(data => data as T[])
            .catch(this.handleObservableHttpError);
    }

    paginateMaintenance<T>(
        type: string,
        event: any,
        allColumnsFilter: string,
        columns: string[],
        additionalFilters: Filter[] = null,
        additionalData: any = null): Observable<T> {

        let param: IDataSourceRequest = {
            Take: event.rows,
            Skip: event.first
        };

        if (event.multiSortMeta) {
            param.Sort = [];
            for (let sortMeta of event.multiSortMeta) {
                param.Sort.push({
                    Field: sortMeta.field,
                    Dir: sortMeta.order === 1 ? 'asc' : 'desc'
                });
            }
        }

        if (allColumnsFilter) {
            // if enclosed with double quotes
            let isExactSearch = allColumnsFilter.startsWith("\"") && allColumnsFilter.endsWith("\"");
            if (isExactSearch) {
                allColumnsFilter = allColumnsFilter.substring(1, allColumnsFilter.length - 1)
            }
            if (allColumnsFilter) {
                param.Filter = new Filter({
                    Field: columns.join(","),
                    Operator: "contains",
                    Value: allColumnsFilter,
                    Logic: "and",
                    IsGlobal: true,
                    IsExactSearch: isExactSearch,
                    Filters: []
                });
            }
        }

        if (additionalFilters && additionalFilters.length) {
            param.Filter = param.Filter || new Filter({
                Logic: "and",
                Filters: []
            });
            param.Filter.Filters = param.Filter.Filters.concat(additionalFilters);
        }

        let dataParam = Object.assign({}, additionalData || {}, {
            dataSourceRequest: param
            // ScheduledDate: additionalData
        });

        return this.http.get(`${Constants.ApiUrl}/enumeration/generic/${type}`, dataParam)
            // .map(data => data as T[])
            .catch(this.handleObservableHttpError);
    }
    getSomethingWithPagination<T>(serviceName: string, page: number,
        record: number, filter: string) {
        return this.http.post(`${Constants.ApiUrl}/${serviceName}/${page}/${record}`, {
            filter: filter
        })
            .toPromise()
            .then(data => { return data as T; })
            .catch(this.handleError);
    }

    getSomething<T>(serviceName: string) {
        return this.http.post(`${Constants.ApiUrl}/${serviceName}`, {})
            .toPromise()
            .then(data => { return data as T[]; })
            .catch(this.handleError);
    }

    getSomethingWithUrl<T>(serviceName: string, baseUrl: string) {
        return this.http.post(`${Constants.ApiUrl}/${serviceName}`, { baseUrl: baseUrl })
            .toPromise()
            .then(data => { return data as T[]; })
            .catch(this.handleError);
    }

    addSomething<T>(serviceName: string, objEntity: T) {
        return this.http.post(`${Constants.ApiUrl}/${serviceName}`, objEntity)
            .toPromise()
            .then(data => { return data as T; })
        //.catch(this.handleError);
    }

    deleteSomething<T>(serviceName: string, id) {
        return this.http.delete(`${Constants.ApiUrl}/${serviceName}/${id}`)
            .toPromise()
            .then(() => null)
            .catch(this.handleError);
    }

    updateSomething<T>(serviceName: string, id, objEntity: T) {
        return this.http.put(`${Constants.ApiUrl}/${serviceName}/${id}`, objEntity)
            .toPromise()
            .then(() => objEntity)
            .catch(this.handleError);
    }

    getKeyValueList<T>(type: string): Observable<T[]> {
        debugger;
        return this.http.get<T[]>(`${Constants.ApiUrl}/keyvalue/generic/${type}`, {})
            .map(data => data as T[])
            .catch(this.handleObservableHttpError);
    }

    getGenericList<T>(type: string): Observable<T[]> {
        return this.http.get<T[]>(`${Constants.ApiUrl}/RetrieveGeneric/${type}`, {})
            .map(data => data as T[])
            .catch(this.handleObservableHttpError);
    }
    getGenericById<T>(type: string, id: string): Observable<T[]> {
        return this.http.get<T[]>(`${Constants.ApiUrl}/RetrieveGenericById/${type}/${id}`, {})
            .map(data => data as T[])
            .catch(this.handleObservableHttpError);
    }
    addGeneric<T>(type: string, objEntity: T) {
        return this.http.post(`${Constants.ApiUrl}/CreateGeneric/${type}`, objEntity)
            .toPromise()
            .then(data => { return data as T; })
        //.catch(this.handleError);
    }
    updateGeneric<T>(type: string, objEntity: T) {
        return this.http.put(`${Constants.ApiUrl}/UpdateGeneric/${type}`, objEntity)
            .toPromise()
            .then(() => objEntity)
            .catch(this.handleError);
    }
    deleteGeneric<T>(type:string, id: string){
        return this.http.delete(`${Constants.ApiUrl}/DeleteGeneric/${type}/${id}`)
        .toPromise()
        .then(()=> null)
        .catch(this.handleError);
    }
    getAllGeneric(): Observable<SelectItem[]>{
        return this.http.get(`${Constants.ApiUrl}/GetInheritedClass`)
        .map(data => data as SelectItem[])
        .catch(this.handleObservableHttpError);
    }

    getSelectItemList(type: string): Observable<SelectItem[]> {
        return this.http.get<any[]>(`${Constants.ApiUrl}/keyvalue/generic/${type}`, {})
            .map(data => Utils.convertEnumerableListToSelectItemList(data))
            .catch(this.handleObservableHttpError);
    }

    handleError(error: any): Promise<any> {
        if (console && console.error) console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }

    handleObservableHttpError(error: any): Observable<any> {
        console.log('sever error:', error);  // debug
        if (error instanceof HttpErrorResponse) {
            return Observable.throw(error);
        }
        return Observable.throw(JSON.stringify(error) || 'backend server error');
    }
}
