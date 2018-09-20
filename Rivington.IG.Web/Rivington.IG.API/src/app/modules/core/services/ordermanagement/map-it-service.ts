import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { SelectItem } from 'primeng/primeng';
import { Observable } from 'rxjs/Observable';
import { Constants } from '../../../shared/constants';
import { DateDifferenceConstants } from '../../../shared/date-difference-constants';
import { MapItViewModel } from '../../../shared/models/view-model/map-it-view-model';
import { CommonService } from '../common.service';
import { GetInspectorService } from './getinspector.service';
import { InfoWindow } from '../../../../../../node_modules/@agm/core/services/google-maps-types';

@Injectable()
export class MapItService {
    currentOpenedInfoWindow: InfoWindow;

    constructor(private http: HttpClient,
        private commonService: CommonService,
        public fb: FormBuilder,
        private inspectorService: GetInspectorService
    ) {
    }
    
    getIoByIoId(ioId) : Observable<MapItViewModel>{
        return this.http.get(`${Constants.ApiUrl}/inspectionorder/GetIoMapItByIoId/${ioId}`)
            .map((data: MapItViewModel) => {
                if(data) {
                    data.longitude = parseFloat(data.longitude.toString());
                    data.latitude = parseFloat(data.latitude.toString());
                    
                    data.inceptionStatus = this.getInceptionStatus(data);

                    data.todayToInceptionDaysCount = this.getInceptionCount(data.inceptionDate);
                }
                return data;
            })
            .catch(this.commonService.handleObservableHttpError);
    }
    
    getIoList(inspectorId: string = "") : Observable<MapItViewModel[]>{
        return this.http.get(`${Constants.ApiUrl}/inspectionorder/GetIoMapItList/${inspectorId}`)
            .map((data: MapItViewModel[]) => {
                if(data) {
                    // remove current inspection order
                    if(inspectorId) {
                        for (let i = 0, dataLength = data.length; i < dataLength; i++) {
                          const item = data[i];
                          if(item.id === inspectorId) {
                            data.splice(i, 1);
                            i = dataLength;
                          }
                        }
                    }

                    data.forEach(item => {
                        item.longitude = parseFloat(item.longitude.toString());
                        item.latitude = parseFloat(item.latitude.toString());
                        item.inceptionStatus = this.getInceptionStatus(item);

                        item.todayToInceptionDaysCount = this.getInceptionCount(item.inceptionDate);
                    });
                }
                return data;
            })
            .catch(this.commonService.handleObservableHttpError);
    }
    
    getUserListForDropdown() : Promise<SelectItem[]>{
        return this.inspectorService.getInspectorList("User", "")
            .then((data: any[]) => {
                let list: SelectItem[] = [];
                if(data) {
                    data.forEach(item => {
                        list.push({
                            value: item.id,
                            label: `${item.firstName} ${item.lastName}`
                        });
                    });
                    
                    list.sort((a,b) => {
                        return (a.label > b.label) ? 1 : ((b.label > a.label) ? -1 : 0);
                    });
                }
                return list;
            })
            .catch(this.commonService.handleError);
    }
    
    getUniqueUsersFromIoList(list: MapItViewModel[]) : SelectItem[] {
        list = list || [];
      
        let availableInspectorIds = list.map(x => x.inspectorId); 
        let uniqueInspectorIds = Array.from(new Set(availableInspectorIds));
        let uniqueInspectorList: SelectItem[] = [];
        uniqueInspectorIds.forEach(inspectorId => {
          if(inspectorId) {
            let io = list.find(x => x.inspectorId === inspectorId);
            if(io) {
              uniqueInspectorList.push({
                value: io.inspectorId,
                label: io.inspector
              });
            }
          }
        });

        uniqueInspectorList.sort((a,b) => {
            let aa = a.label.toLowerCase();
            let bb = b.label.toLowerCase();
            return (aa > bb) ? 1 : ((bb > aa) ? -1 : 0);
        });

        return uniqueInspectorList;
    }
    
    private getInceptionStatus(io: MapItViewModel): any {
        switch (io.dateDifference) {
            case "0-19":
                return DateDifferenceConstants.ZeroToNineteenDays;
            case "20-39":
                return DateDifferenceConstants.TwentyToThirtyNineDays;
            default: // case "40-59":
                return DateDifferenceConstants.FortyToFiftyNineDays;
        }
    }
    
    private getInceptionCount(inceptionDate: Date): number {
        try {
            if(!!!inceptionDate) return null;

            inceptionDate = new Date(inceptionDate);
            let todayDate = new Date();
            let timeDiff = Math.abs(todayDate.getTime() - inceptionDate.getTime());
            let diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
    
            return diffDays;
        } catch (error) {
            return null;
        }
    }
}