//#region imports
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { SelectItem } from 'primeng/primeng';
import { Observable } from 'rxjs/Observable';
import Utils from '../../../../shared/Utils';
import { Constants } from '../../../../shared/constants';
import { InspectionOrder } from '../../../../shared/models/ordermanagement/inspection-order';
import { CommonService } from '../../common.service';
import { CityService } from '../city.service';
import { StateService } from '../state.service';
import { InspectionOrderProperty } from '../../../../shared/models/ordermanagement/inspection-order/checklist/property';
import { InspectionOrderChecklistWildFireService } from './wildfire.service';
//#endregion imports

export interface IInspectionOrderChecklistPropertyServiceForms {
    general?: FormGroup;
    interiorDetail?: FormGroup;
    homeDetail?: FormGroup;
    buildingConcern?: FormGroup;
    detachedStructure?: FormGroup;
    additionalExposure?: FormGroup;
    highValueKitchen?: FormGroup;
    highValueBath?: FormGroup;
    highValueFloorToCeiling?: FormGroup;
    highValueInteriorFeature?: FormGroup;
}

@Injectable()
export class InspectionOrderChecklistPropertyService {
    public isNumOfFirePlaces: boolean;
    public kitchenIsland: boolean;
    public isHighValue: boolean;
    public additionalConcern: boolean;
    public bearInvasion: boolean;
    public animalsOnPremises: boolean;
    public businessPremises: boolean;
    public dogs: boolean;
    public adjacentExposure: boolean;
    public otherNuisance: boolean;
    public trampoline: boolean;
    public woodPlace: boolean;
    public burglarAlarm: boolean;
    public smokeAlarm: boolean;
    public septicTank: boolean;
    public fireAlarm: boolean;
    public domesticHelp: boolean;
    public priorLoss: boolean;
    public preUpdates: boolean;
    public recentlyRenovated: boolean;

    numberOfFirePlaces: number;

    public prefilledVaules: any = {
        "primaryRoofId": null,
        "secondaryRoofId": null,
        "roofShape": null,
        "roofPitch": null,
        "roofConcernDetails": null,
        "foundationType": null,
        "framingType": null,
        "primaryExteriorWall": null,
        "secondaryExteriorWall": null,
        "windowStyles": null,
        "outBuilding": null,
        "outBuildingDetails": null,
        "otherDetachedStructure": null,
        "otherDetachedStructureDetails": null
    };

    propertyForms: IInspectionOrderChecklistPropertyServiceForms;
    cities: SelectItem[];
    propertyTabValues: InspectionOrderProperty;

    constructor(private http: HttpClient,
        private commonService: CommonService,
        public fb: FormBuilder,
        private stateService: StateService,
        private cityService: CityService,
        private wildFireService: InspectionOrderChecklistWildFireService
    ) {
        this.numberOfFirePlaces = 0;
    }

    initiateFormValues(): IInspectionOrderChecklistPropertyServiceForms {
        this.propertyForms = {};
        this.propertyForms.general = this.fb.group({
            'streetAddress1': new FormControl(), // FormControl('')
            'streetAddress2': new FormControl(), // FormControl('')
            'cityId': new FormControl(), // FormControl(0),
            'stateId': new FormControl(), // FormControl('')
            'zipCode': new FormControl(), // FormControl('')
            'estimatedSquareFootage': new FormControl(), // FormControl(0),
            'yearBuilt': new FormControl(), // FormControl(0),
            'recentlyRenovated': new FormControl(false),
            'contractorName': new FormControl(), // FormControl('')
            'contractorPhone': new FormControl(), // FormControl('')
            'roofAge': new FormControl(), // FormControl(0),
            'waterHeaterAge': new FormControl(), // FormControl(0),
            'majorSystemAge': new FormControl(), // FormControl(0),
            'majorSystemDescription': new FormControl(), // FormControl('')
            'pre1970Updates': new FormControl(false),
            'pre1970UpdatesDescription': new FormControl(), // FormControl('')
            'septicTank': new FormControl(false),
            'lastServiceDate': new FormControl(), // FormControl('')
            'priorLoss': new FormControl(false),
            'priorLossDescription': new FormControl(), // FormControl('')
            'problemResolved': new FormControl(false),
            'occupancyTypeId': new FormControl(), // FormControl('')
            'domesticHelpTypeId': new FormControl(),
            'domesticHelpTypes': new FormControl(), // FormControl([])
            'fireAlarmId': new FormControl(), // FormControl('')
            'fireAlarmTypeId': new FormControl(), // FormControl('')
            'smokeOnlyAlarmId': new FormControl(), // FormControl('')
            'smokeOnlyAlarmTypeId': new FormControl(), // FormControl('')
            'burglarAlarmId': new FormControl(), // FormControl('')
            'burglarAlarmTypeId': new FormControl(), // FormControl('')
            'woodStoveOrWoodBurningFirePlace': new FormControl(false),
            'woodStoveLocation': new FormControl(), // FormControl('')
            'woodStoveUsage': new FormControl(), // FormControl('')
            'policyPremiumCredits': new FormControl(), // FormControl([])
            'wildfireCredits': new FormControl() // FormControl([])
        });

        this.propertyForms.general.get('stateId').valueChanges.subscribe(id => {
            if (id) {
                this.getCities(id).then(
                    cities => this.cities = cities
                )
            } else {
                this.cities = [];
            }
        });

        this.propertyForms.interiorDetail = this.fb.group({
            'flooringTypes': new FormControl(), // FormControl([])
            'kitchenBathCabinets': new FormControl(), // FormControl([])
            'kitchenBathCounters': new FormControl(), // FormControl([])
            'qualityClassUpgrades': new FormControl(), // FormControl([])
            'interiorDetailComment': new FormControl(), // FormControl('')
            'typeOfPlumbings': new FormControl(), // FormControl([])
            'electricalServiceAmperage': new FormControl(), // FormControl('')
            'waterHeaterLocation': new FormControl(), // FormControl('')
            'laundryLocation': new FormControl() // FormControl('')
        });

        this.propertyForms.homeDetail = this.fb.group({
            'architecturalStyleId': new FormControl(), // FormControl('')
            'framingTypeId': new FormControl(), // FormControl('')
            'constructionQualityId': new FormControl(), // FormControl('')
            'homeShapeId': new FormControl(), // FormControl('')
            'primaryExteriorWallCoveringId': new FormControl(), // FormControl('')
            'secondaryExteriorWallCoveringId': new FormControl(), // FormControl('')
            'primaryRoofCoveringId': new FormControl(), // FormControl('')
            'secondaryRoofCoveringId': new FormControl(), // FormControl('')
            'roofShapeId': new FormControl(), // FormControl(''),
            'roofPitchId': new FormControl(), // FormControl('')
            'foundationTypeId': new FormControl(), // FormControl('')
            'numberofStories': new FormControl(), // FormControl(0),
            'slopeOfSiteId': new FormControl(), // FormControl('')
            'locales': new FormControl() // FormControl([])
        });

        this.propertyForms.buildingConcern = this.fb.group({
            'exteriorBuildingConcernDetails': new FormControl(), // FormControl([])
            'roofConcernDetails': new FormControl(), // FormControl([])
            'electricalConcernDetails': new FormControl(), // FormControl([])
            'plumbingConcernDetails': new FormControl(), // FormControl([])
            'otherStructureConcernDetails': new FormControl(), // FormControl([])
            'surroundingAreaConcernDetails': new FormControl() // FormControl([])
        });

        this.propertyForms.detachedStructure = this.fb.group({
            'outbuildingDetails': new FormControl(), // FormControl([])
            'outbuildingTypeOrConstruction': new FormControl(), // FormControl('')
            'outbuildingConcernOrComment': new FormControl(), // FormControl('')
            'otherDetachedStructuresDetails': new FormControl() // FormControl([])
        });

        this.propertyForms.additionalExposure = this.fb.group({
            'trampoline': new FormControl(false),
            'safetyNetting': new FormControl(false),
            'bracingBolting': new FormControl(false),
            'skateboardRamp': new FormControl(false),
            'otherAttractiveNuisance': new FormControl(false),
            'otherAttractiveNuisanceComment': new FormControl(), // FormControl('')
            'adjacentExposure': new FormControl(false),
            'adjacentExposureComment': new FormControl(), // FormControl('')
            'dog': new FormControl(false),
            'numberofDog': new FormControl(), // FormControl(0),
            'dogBreed': new FormControl(), // FormControl('')
            'dogTemperamentId': new FormControl(), // FormControl('')
            'biteHistory': new FormControl(false),
            'businessAgricultureonPremises': new FormControl(false),
            'businessAgricultureType': new FormControl(), // FormControl('')
            'customerOnSiteId': new FormControl(), // FormControl('')
            'employee10HoursPerWeekId': new FormControl(), // FormControl('')
            'horsesFarmAnimalsonPremise': new FormControl(false),
            'horsesFarmAnimalCount': new FormControl(), // FormControl(0),
            'horsesFarmAnimalType': new FormControl(), // FormControl('')
            'daycareonSite': new FormControl(false),
            'bearInvasionConcern': new FormControl(false),
            'bearInvasionConcernDetails': new FormControl(), // FormControl([])
            'additionalConcern': new FormControl(false),
            'additionalComment': new FormControl() // FormControl('')
        });

        this.propertyForms.highValueKitchen = this.fb.group({
            'kitchenCabinetId': new FormControl(), // FormControl('')
            'kitchenCountertopId': new FormControl(), // FormControl('')
            'kitchenBacksplashMaterial': new FormControl(), // FormControl('')
            'kitchenIsland': new FormControl(false),
            'islandCabinetMaterial': new FormControl(), // FormControl('')
            'islandCountertopMaterial': new FormControl(), // FormControl('')
            'appliances': new FormControl(), // FormControl([])
        });

        this.propertyForms.highValueBath = this.fb.group({
            'numberofFullBath': new FormControl(), // FormControl(0),
            'numberofHalfBath': new FormControl(), // FormControl(0),
            'bathroomFloors': new FormControl(), // FormControl([])
            'bathroomVanities': new FormControl(), // FormControl([])
            'bathroomCounters': new FormControl(), // FormControl([])
            'bathroomFixtures': new FormControl(), // FormControl([])
            'tubsAndShowers': new FormControl() // FormControl([])
        });

        this.propertyForms.highValueFloorToCeiling = this.fb.group({
            'floorCoverings': new FormControl(), // FormControl([])
            'averageWallHeight': new FormControl(), // FormControl('')
            'ceilings': new FormControl(), // FormControl([])
            'interiorWallCoverings': new FormControl(), // FormControl([])
            'wallTrims': new FormControl(), // FormControl([])
            'windowStyles': new FormControl(), // FormControl([])
            'windowBrands': new FormControl(), // FormControl([])
            'numberofChimney': new FormControl(), // FormControl(0),
            'chimneyTypeId': new FormControl() // FormControl('')
        });

        this.propertyForms.highValueInteriorFeature = this.fb.group({
            'interiorDoorTypes': new FormControl(), // FormControl([])
            'doorHardwares': new FormControl(), // FormControl([])
            'roomWithCabinetrys': new FormControl(), // FormControl([])
            'lightingTypes': new FormControl(), // FormControl([])
            'numberofFireplace': new FormControl(), // FormControl(0),
            'fireplaceTypes': new FormControl(), // FormControl([])
            'staircases': new FormControl(), // FormControl([])
            'miscellaneousExtraFeatures': new FormControl() // FormControl([])
        });

        return this.propertyForms;
    }

    setFormValues(existingIO: InspectionOrder) {
        if (existingIO) {
            if (existingIO.property) {
                Utils.updateFormGroup(this.propertyForms.general, existingIO.property.general)
                Utils.updateFormGroup(this.propertyForms.interiorDetail, existingIO.property.interiorDetail)
                Utils.updateFormGroup(this.propertyForms.homeDetail, existingIO.property.homeDetail)
                Utils.updateFormGroup(this.propertyForms.buildingConcern, existingIO.property.buildingConcern)
                Utils.updateFormGroup(this.propertyForms.detachedStructure, existingIO.property.detachedStructure)
                Utils.updateFormGroup(this.propertyForms.additionalExposure, existingIO.property.additionalExposure)
                Utils.updateFormGroup(this.propertyForms.highValueKitchen, existingIO.property.highValueKitchen)
                Utils.updateFormGroup(this.propertyForms.highValueBath, existingIO.property.highValueBath)
                Utils.updateFormGroup(this.propertyForms.highValueFloorToCeiling, existingIO.property.highValueFloorToCeiling)
                Utils.updateFormGroup(this.propertyForms.highValueInteriorFeature, existingIO.property.highValueInteriorFeature)
                   
                //General
                this.recentlyRenovated = existingIO.property.general.recentlyRenovated;
                if(!this.recentlyRenovated) {
                    this.propertyForms.general.get('contractorName').setValue('');
                    this.propertyForms.general.get('contractorPhone').setValue('');
                }

                this.preUpdates = existingIO.property.general.pre1970Updates;
                if(!this.preUpdates){
                    this.propertyForms.general.get('pre1970UpdatesDescription').setValue('');
                  }

                this.septicTank = existingIO.property.general.septicTank;
                if(!this.septicTank){
                    this.propertyForms.general.get('lastServiceDate').setValue('');
                  }

                this.priorLoss = existingIO.property.general.priorLoss;
                if(!this.priorLoss){
                    this.propertyForms.general.get('priorLossDescription').setValue('');
                    this.propertyForms.general.get('problemResolved').setValue(false);
                  }

                this.woodPlace = existingIO.property.general.woodStoveOrWoodBurningFirePlace;
                if(!this.woodPlace){
                    this.propertyForms.general.get('woodStoveLocation').setValue('');
                    this.propertyForms.general.get('woodStoveUsage').setValue('');
                  }

                this.domesticHelp = (existingIO.property.general.domesticHelpTypeId == "YE");
                if (!this.domesticHelp){
                    this.propertyForms.general.get('domesticHelpTypes').setValue(null);
                  }

                this.fireAlarm = (existingIO.property.general.fireAlarmId == "Y");
                if (!this.fireAlarm){
                    this.propertyForms.general.get('fireAlarmTypeId').setValue(null);
                  }

                this.smokeAlarm = (existingIO.property.general.smokeOnlyAlarmId == "Y");
                if (!this.smokeAlarm){
                    this.propertyForms.general.get('smokeOnlyAlarmTypeId').setValue(null);
                  }

                this.burglarAlarm = (existingIO.property.general.burglarAlarmId == "Y");
                if (!this.burglarAlarm){
                    this.propertyForms.general.get('burglarAlarmTypeId').setValue(null);
                  }

                //Additional Exposure
                this.trampoline = existingIO.property.additionalExposure.trampoline;
                if (!this.trampoline) {
                    this.propertyForms.additionalExposure.get('safetyNetting').setValue(false);
                    this.propertyForms.additionalExposure.get('bracingBolting').setValue(false);
                  }

                this.otherNuisance = existingIO.property.additionalExposure.otherAttractiveNuisance;
                if (!this.otherNuisance) {
                    this.propertyForms.additionalExposure.get('otherAttractiveNuisanceComment').setValue('');
                  }

                this.adjacentExposure = existingIO.property.additionalExposure.adjacentExposure;
                if (!this.adjacentExposure) {
                    this.propertyForms.additionalExposure.get('adjacentExposureComment').setValue('');
                  }

                this.dogs = existingIO.property.additionalExposure.dog;
                if (!this.dogs) {
                    this.propertyForms.additionalExposure.get('numberofDog').setValue('');
                    this.propertyForms.additionalExposure.get('dogBreed').setValue('');
                    this.propertyForms.additionalExposure.get('dogTemperamentId').setValue(null);
                    this.propertyForms.additionalExposure.get('biteHistory').setValue(false);
                  }

                this.businessPremises = existingIO.property.additionalExposure.businessAgricultureonPremises;
                if (!this.businessPremises) {
                    this.propertyForms.additionalExposure.get('businessAgricultureType').setValue('');
                    this.propertyForms.additionalExposure.get('customerOnSiteId').setValue(null);
                    this.propertyForms.additionalExposure.get('employee10HoursPerWeekId').setValue(null);
                  }

                this.animalsOnPremises = existingIO.property.additionalExposure.horsesFarmAnimalsonPremise;
                if (!this.animalsOnPremises) {
                    this.propertyForms.additionalExposure.get('horsesFarmAnimalCount').setValue('');
                    this.propertyForms.additionalExposure.get('horsesFarmAnimalType').setValue('');
                  }

                this.bearInvasion = existingIO.property.additionalExposure.bearInvasionConcern;
                if (!this.bearInvasion) {
                    this.propertyForms.additionalExposure.get('bearInvasionConcernDetails').setValue(null);
                  }

                this.additionalConcern = existingIO.property.additionalExposure.additionalConcern;
                if (!this.additionalConcern) {
                    this.propertyForms.additionalExposure.get('additionalComment').setValue('');
                  }

                //High Value Kitchen
                this.kitchenIsland = existingIO.property.highValueKitchen.kitchenIsland;
                if (!this.kitchenIsland) {
                    this.propertyForms.highValueKitchen.get('islandCabinetMaterial').setValue('');
                    this.propertyForms.highValueKitchen.get('islandCountertopMaterial').setValue('');
                  }

                //Interior Feature
                this.isNumOfFirePlaces = (existingIO.property.highValueInteriorFeature.numberofFireplace > this.numberOfFirePlaces);
                if(!this.isNumOfFirePlaces) {
                    this.propertyForms.highValueInteriorFeature.get('fireplaceTypes').setValue(null);
                  }
            }
        }
    }

    valueChanges(value: string, field: string, fieldType: string, formName: string ) {
        if(this.wildFireService.isWildFireRequired){
            if(!this.wildFireService.isInitiated) {
                this.prefilledVaules[fieldType] = value;
            }
            else {
                this.wildFireService.wildfireAssessmentForms[formName].get(field).setValue(value);
            }
        }
    }

    clearValue(value: string) {
        switch(value) {
            //General
            case 'recentlyRenovated':
            if(!this.recentlyRenovated){
              this.propertyForms.general.get('contractorName').setValue('');
              this.propertyForms.general.get('contractorPhone').setValue('');
            }
            break;
            case 'preUpdates':
            if(!this.preUpdates){
              this.propertyForms.general.get('pre1970UpdatesDescription').setValue('');
            }
            break;
            case 'septicTank':
            if(!this.septicTank){
              this.propertyForms.general.get('lastServiceDate').setValue('');
            }
            break;
            case 'priorLoss':
            if(!this.priorLoss){
              this.propertyForms.general.get('priorLossDescription').setValue('');
              this.propertyForms.general.get('problemResolved').setValue(false);
            }
            break;
            case 'woodPlace':
            if(!this.woodPlace){
              this.propertyForms.general.get('woodStoveLocation').setValue('');
              this.propertyForms.general.get('woodStoveUsage').setValue('');
            }
            break;

            //Additional Exposure
            case 'trampoline':
            if (!this.trampoline) {
              this.propertyForms.additionalExposure.get('safetyNetting').setValue(false);
              this.propertyForms.additionalExposure.get('bracingBolting').setValue(false);
            }
            break;
            case 'otherNuisance':
            if (!this.otherNuisance) {
              this.propertyForms.additionalExposure.get('otherAttractiveNuisanceComment').setValue('');
            }
            break;
            case 'adjacentExposure':
            if (!this.adjacentExposure) {
              this.propertyForms.additionalExposure.get('adjacentExposureComment').setValue('');
            }
            break;
            case 'dogs':
            if (!this.dogs) {
              this.propertyForms.additionalExposure.get('numberofDog').setValue('');
              this.propertyForms.additionalExposure.get('dogBreed').setValue('');
              this.propertyForms.additionalExposure.get('dogTemperamentId').setValue(null);
              this.propertyForms.additionalExposure.get('biteHistory').setValue(false);
            }
            break;
            case 'businessPremises':
            if (!this.businessPremises) {
              this.propertyForms.additionalExposure.get('businessAgricultureType').setValue('');
              this.propertyForms.additionalExposure.get('customerOnSiteId').setValue(null);
              this.propertyForms.additionalExposure.get('employee10HoursPerWeekId').setValue(null);
            }
            break;
            case 'animalsOnPremises':
            if (!this.animalsOnPremises) {
              this.propertyForms.additionalExposure.get('horsesFarmAnimalCount').setValue('');
              this.propertyForms.additionalExposure.get('horsesFarmAnimalType').setValue('');
            }
            break;
            case 'bearInvasion':
            if (!this.bearInvasion) {
              this.propertyForms.additionalExposure.get('bearInvasionConcernDetails').setValue(null);
            }
            break;
            case 'additionalConcern':
            if (!this.additionalConcern) {
              this.propertyForms.additionalExposure.get('additionalComment').setValue('');
            }
            break;

            //High Value Kitchen
            case 'kitchenIsland':
            if (!this.kitchenIsland) {
              this.propertyForms.highValueKitchen.get('islandCabinetMaterial').setValue('');
              this.propertyForms.highValueKitchen.get('islandCountertopMaterial').setValue('');
            }
            break;
            default:
            break;
        }
        
    }

    //#region get key values
    //#region General
    getStates(): Promise<SelectItem[]> {
        return this.stateService.getStateList()
            .then(data => Utils.convertEnumerableListToSelectItemList(data));
    }

    getCities(stateId: string): Promise<SelectItem[]> {
        return this.cityService.getCityList(stateId)
            .then(data => {
                let list: SelectItem[] = [];
                data.forEach(item => {
                    list.push({
                        value: item.id,
                        label: item.name
                    });
                })

                return list;
            });
    }

    getOccupancyTypes(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.OccupancyType");
    }

    getDomesticHelp(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("DomesticHelp");
    }

    getDomesticHelpTypes(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("DomesticHelpType");
    }

    getFireAlarms(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("FireAlarm");
    }

    getFireAlarmTypes(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("FireAlarmType");
    }

    getSmokeOnlyAlarms(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("SmokeOnlyAlarm");
    }

    getSmokeOnlyAlarmTypes(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("SmokeOnlyAlarmType");
    }

    getBurglarAlarms(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("BurglarAlarm");
    }

    getBurglarAlarmTypes(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("BurglarAlarmType");
    }

    getPolicyPremiumCredits(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.PolicyPremiumCredit");
    }

    getWildfireCredits(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.WildfireCredit");
    }
    //#endregion General

    //#region InteriorDetail    
    getFlooringTypes(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.FlooringType");
    }

    getKitchenBathCabinets(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.KitchenBathCabinet");
    }

    getKitchenBathCounters(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.KitchenBathCounter");
    }

    getQualityClassUpgrades(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.QualityClassUpgrade");
    }

    getTypeOfPlumbings(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.TypeOfPlumbing");
    }
    //#endregion InteriorDetail    

    //#region HomeDetail
    getArchitecturalStyles(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.ArchitecturalStyle");
    }

    getFramingTypes(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.FramingType");
    }

    getConstructionQualities(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.ConstructionQuality");
    }

    getHomeShapes(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.HomeShape");
    }

    getPrimaryExteriorWallCoverings(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.PrimaryExteriorWallCovering");
    }

    getSecondaryExteriorWallCoverings(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.SecondaryExteriorWallCovering");
    }

    getPrimaryRoofCoverings(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.PrimaryRoofCovering");
    }

    getSecondaryRoofCoverings(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.SecondaryRoofCovering");
    }

    getRoofShapes(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.RoofShape");
    }
    getRoofPitch(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.RoofPitch");
    }

    getFoundationType(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.FoundationType");
    }

    getSlopeOfSites(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.SlopeOfSite");
    }
    getLocales(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.Locale");
    }
    //#endregion HomeDetail

    //#region BuildingConcern    
    getExteriorBuildingConcernDetails(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.ExteriorBuildingConcernDetail");
    }

    getRoofConcernDetails(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.RoofConcernDetail");
    }

    getElectricalConcernDetails(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.ElectricalConcernDetail");
    }

    getPlumbingConcernDetails(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.PlumbingConcernDetail");
    }

    getOtherStructureConcernDetails(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.OtherStructureConcernDetail");
    }

    getSurroundingAreaConcernDetails(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.SurroundingAreaConcernDetail");
    }
    //#endregion BuildingConcern    

    //#region DetachedStructure
    getOutbuildingDetails(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.OutbuildingDetail");
    }
    getOtherDetachedStructuresDetails(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.OtherDetachedStructuresDetail");
    }
    //#endregion DetachedStructure    

    //#region AdditionalExposure    
    getDogTemperaments(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.DogTemperament");
    }
    getCustomerOnSites(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.CustomerOnSite");
    }
    getEmployee10HoursPerWeeks(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.Employee10HoursPerWeek");
    }
    getBearInvasionConcernDetails(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.BearInvasionConcernDetail");
    }
    //#endregion AdditionalExposure   

    //#region HighValueKitchen    
    getKitchenCabinets(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.KitchenCabinet");
    }
    getKitchenCountertop(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.KitchenCountertop");
    }
    getApplianceTypes(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("ApplianceType");
    }
    getApplianceBrand(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.ApplianceBrand");
    }
    //#endregion HighValueKitchen   

    //#region HighValueBath    
    getBathroomFloors(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.BathroomFloor");
    }
    getBathroomVanities(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.BathroomVanity");
    }
    getBathroomCounters(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.BathroomCounter");
    }
    getBathroomFixtures(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.BathroomFixture");
    }
    getTubsAndShowers(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.TubAndShower");
    }
    //#endregion HighValueBath   

    //#region HighValueFloorToCeiling    
    getFloorCoverings(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.FloorCovering");
    }
    getCeilings(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.Ceiling");
    }
    getInteriorWallCoverings(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.InteriorWallCovering");
    }
    getWallTrims(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.WallTrim");
    }
    getWindowStyles(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.WindowStyle");
    }
    getWindowBrands(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.WindowBrand");
    }
    getChimneyTypes(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.ChimneyType");
    }
    //#endregion HighValueFloorToCeiling  

    //#region HighValueInteriorFeature 
    getInteriorDoorTypes(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.InteriorDoorType");
    }
    getDoorHardwares(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.DoorHardware");
    }
    getRoomWithCabinetrys(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.RoomWithCabinetry");
    }
    getLightingTypes(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.LightingType");
    }
    getFireplaceTypes(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.FireplaceType");
    }
    getStaircases(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.Staircase");
    }
    getMiscellaneousExtraFeatures(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.MiscellaneousExtraFeature");
    }
    //#endregion HighValueInteriorFeature   

    //#endregion get key values

    getIOProperty(id: string) {
        return this.http.get(`${Constants.ApiUrl}/ioproperty/${id}`)
            .map(responseData => {
                if (!!!responseData) {
                    this.propertyTabValues = null;
                    return responseData;
                }

                let data = (responseData as any);

                this.propertyTabValues = data;

                // general
                let general = data.general;
                if (general) {
                    general.domesticHelpTypes = Utils.genericTypeArrayToStringOfIds("domesticHelpTypeId", general.domesticHelpTypes);
                    general.policyPremiumCredits = Utils.genericTypeArrayToStringOfIds("policyPremiumCreditId", general.policyPremiumCredits);
                    general.wildfireCredits = Utils.genericTypeArrayToStringOfIds("wildfireCreditId", general.wildfireCredits);
                }

                // interiorDetail
                let interiorDetail = data.interiorDetail;
                if (interiorDetail) {
                    interiorDetail.flooringTypes = Utils.genericTypeArrayToStringOfIds("flooringTypeId", interiorDetail.flooringTypes);
                    interiorDetail.kitchenBathCabinets = Utils.genericTypeArrayToStringOfIds("kitchenBathCabinetId", interiorDetail.kitchenBathCabinets);
                    interiorDetail.kitchenBathCounters = Utils.genericTypeArrayToStringOfIds("kitchenBathCounterId", interiorDetail.kitchenBathCounters);
                    interiorDetail.qualityClassUpgrades = Utils.genericTypeArrayToStringOfIds("qualityClassUpgradeId", interiorDetail.qualityClassUpgrades);
                    interiorDetail.typeOfPlumbings = Utils.genericTypeArrayToStringOfIds("typeOfPlumbingId", interiorDetail.typeOfPlumbings);
                }

                let homeDetail = data.homeDetail;
                if (homeDetail) {
                    homeDetail.locales = Utils.genericTypeArrayToStringOfIds("localeId", homeDetail.locales);
                }

                let buildingConcern = data.buildingConcern;
                if (buildingConcern) {
                    buildingConcern.exteriorBuildingConcernDetails = Utils.genericTypeArrayToStringOfIds("exteriorBuildingConcernDetailId", buildingConcern.exteriorBuildingConcernDetails);
                    buildingConcern.roofConcernDetails = Utils.genericTypeArrayToStringOfIds("roofConcernDetailId", buildingConcern.roofConcernDetails);
                    buildingConcern.electricalConcernDetails = Utils.genericTypeArrayToStringOfIds("electricalConcernDetailId", buildingConcern.electricalConcernDetails);
                    buildingConcern.plumbingConcernDetails = Utils.genericTypeArrayToStringOfIds("plumbingConcernDetailId", buildingConcern.plumbingConcernDetails);
                    buildingConcern.otherStructureConcernDetails = Utils.genericTypeArrayToStringOfIds("otherStructureConcernDetailId", buildingConcern.otherStructureConcernDetails);
                    buildingConcern.surroundingAreaConcernDetails = Utils.genericTypeArrayToStringOfIds("surroundingAreaConcernDetailId", buildingConcern.surroundingAreaConcernDetails);
                }

                let detachedStructure = data.detachedStructure;
                if (detachedStructure) {
                    detachedStructure.outbuildingDetails = Utils.genericTypeArrayToStringOfIds("outbuildingDetailId", detachedStructure.outbuildingDetails);
                    detachedStructure.otherDetachedStructuresDetails = Utils.genericTypeArrayToStringOfIds("otherDetachedStructuresDetailId", detachedStructure.otherDetachedStructuresDetails);
                }

                let additionalExposure = data.additionalExposure;
                if (additionalExposure) {
                    additionalExposure.bearInvasionConcernDetails = Utils.genericTypeArrayToStringOfIds("bearInvasionConcernDetailId", additionalExposure.bearInvasionConcernDetails);
                }

                // no formatting needed
                // let highValueKitchen = data.highValueKitchen;
                // if(highValueKitchen) {
                //     // highValueKitchen.appliances = Utils.genericTypeArrayToStringOfIds("applianceTypeId", highValueKitchen.applianceTypes);
                // }

                let highValueBath = data.highValueBath;
                if (highValueBath) {
                    highValueBath.bathroomFloors = Utils.genericTypeArrayToStringOfIds("bathroomFloorId", highValueBath.bathroomFloors);
                    highValueBath.bathroomVanities = Utils.genericTypeArrayToStringOfIds("bathroomVanityId", highValueBath.bathroomVanities);
                    highValueBath.bathroomCounters = Utils.genericTypeArrayToStringOfIds("bathroomCounterId", highValueBath.bathroomCounters);
                    highValueBath.bathroomFixtures = Utils.genericTypeArrayToStringOfIds("bathroomFixtureId", highValueBath.bathroomFixtures);
                    highValueBath.tubsAndShowers = Utils.genericTypeArrayToStringOfIds("tubAndShowerId", highValueBath.tubsAndShowers);
                }

                let highValueFloorToCeiling = data.highValueFloorToCeiling;
                if (highValueFloorToCeiling) {
                    highValueFloorToCeiling.floorCoverings = Utils.genericTypeArrayToStringOfIds("floorCoveringId", highValueFloorToCeiling.floorCoverings);
                    highValueFloorToCeiling.ceilings = Utils.genericTypeArrayToStringOfIds("ceilingId", highValueFloorToCeiling.ceilings);
                    highValueFloorToCeiling.interiorWallCoverings = Utils.genericTypeArrayToStringOfIds("interiorWallCoveringId", highValueFloorToCeiling.interiorWallCoverings);
                    highValueFloorToCeiling.wallTrims = Utils.genericTypeArrayToStringOfIds("wallTrimId", highValueFloorToCeiling.wallTrims);
                    highValueFloorToCeiling.windowStyles = Utils.genericTypeArrayToStringOfIds("windowStyleId", highValueFloorToCeiling.windowStyles);
                    highValueFloorToCeiling.windowBrands = Utils.genericTypeArrayToStringOfIds("windowBrandId", highValueFloorToCeiling.windowBrands);
                }

                let highValueInteriorFeature = data.highValueInteriorFeature;
                if (highValueInteriorFeature) {
                    highValueInteriorFeature.interiorDoorTypes = Utils.genericTypeArrayToStringOfIds("interiorDoorTypeId", highValueInteriorFeature.interiorDoorTypes);
                    highValueInteriorFeature.doorHardwares = Utils.genericTypeArrayToStringOfIds("doorHardwareId", highValueInteriorFeature.doorHardwares);
                    highValueInteriorFeature.roomWithCabinetrys = Utils.genericTypeArrayToStringOfIds("roomWithCabinetryId", highValueInteriorFeature.roomWithCabinetrys);
                    highValueInteriorFeature.lightingTypes = Utils.genericTypeArrayToStringOfIds("lightingTypeId", highValueInteriorFeature.lightingTypes);
                    highValueInteriorFeature.fireplaceTypes = Utils.genericTypeArrayToStringOfIds("fireplaceTypeId", highValueInteriorFeature.fireplaceTypes);
                    highValueInteriorFeature.staircases = Utils.genericTypeArrayToStringOfIds("staircaseId", highValueInteriorFeature.staircases);
                    highValueInteriorFeature.miscellaneousExtraFeatures = Utils.genericTypeArrayToStringOfIds("miscellaneousExtraFeatureId", highValueInteriorFeature.miscellaneousExtraFeatures);
                }

                return data;
            })
            .catch(this.commonService.handleObservableHttpError);
    }

    getPropertyTabValue() {
        return this.propertyTabValues;
    }

    getPropertyValues(): InspectionOrderProperty {
        if (!!!this.propertyForms) return;

        let property = new InspectionOrderProperty();

        let propertyGeneralFormValues = Object.assign({}, this.propertyForms.general.value);
        property.general = propertyGeneralFormValues;
        property.general.domesticHelpTypes = Utils.stringArrayToGenericTypeWithIdOnly("domesticHelpTypeId", propertyGeneralFormValues.domesticHelpTypes);
        property.general.policyPremiumCredits = Utils.stringArrayToGenericTypeWithIdOnly("policyPremiumCreditId", propertyGeneralFormValues.policyPremiumCredits);
        property.general.wildfireCredits = Utils.stringArrayToGenericTypeWithIdOnly("wildfireCreditId", propertyGeneralFormValues.wildfireCredits);

        let propertyInteriorDetailFormValues = Object.assign({}, this.propertyForms.interiorDetail.value);
        property.interiorDetail = propertyInteriorDetailFormValues;
        property.interiorDetail.flooringTypes = Utils.stringArrayToGenericTypeWithIdOnly("flooringTypeId", propertyInteriorDetailFormValues.flooringTypes);
        property.interiorDetail.kitchenBathCabinets = Utils.stringArrayToGenericTypeWithIdOnly("kitchenBathCabinetId", propertyInteriorDetailFormValues.kitchenBathCabinets);
        property.interiorDetail.kitchenBathCounters = Utils.stringArrayToGenericTypeWithIdOnly("kitchenBathCounterId", propertyInteriorDetailFormValues.kitchenBathCounters);
        property.interiorDetail.qualityClassUpgrades = Utils.stringArrayToGenericTypeWithIdOnly("qualityClassUpgradeId", propertyInteriorDetailFormValues.qualityClassUpgrades);
        property.interiorDetail.typeOfPlumbings = Utils.stringArrayToGenericTypeWithIdOnly("typeOfPlumbingId", propertyInteriorDetailFormValues.typeOfPlumbings);

        let propertyHomeDetailFormValues = Object.assign({}, this.propertyForms.homeDetail.value);
        property.homeDetail = propertyHomeDetailFormValues;
        property.homeDetail.locales = Utils.stringArrayToGenericTypeWithIdOnly("localeId", propertyHomeDetailFormValues.locales);

        let propertyBuildingConcernFormValues = Object.assign({}, this.propertyForms.buildingConcern.value);
        property.buildingConcern = propertyBuildingConcernFormValues;
        property.buildingConcern.exteriorBuildingConcernDetails = Utils.stringArrayToGenericTypeWithIdOnly("exteriorBuildingConcernDetailId", propertyBuildingConcernFormValues.exteriorBuildingConcernDetails);
        property.buildingConcern.roofConcernDetails = Utils.stringArrayToGenericTypeWithIdOnly("roofConcernDetailId", propertyBuildingConcernFormValues.roofConcernDetails);
        property.buildingConcern.electricalConcernDetails = Utils.stringArrayToGenericTypeWithIdOnly("electricalConcernDetailId", propertyBuildingConcernFormValues.electricalConcernDetails);
        property.buildingConcern.plumbingConcernDetails = Utils.stringArrayToGenericTypeWithIdOnly("plumbingConcernDetailId", propertyBuildingConcernFormValues.plumbingConcernDetails);
        property.buildingConcern.otherStructureConcernDetails = Utils.stringArrayToGenericTypeWithIdOnly("otherStructureConcernDetailId", propertyBuildingConcernFormValues.otherStructureConcernDetails);
        property.buildingConcern.surroundingAreaConcernDetails = Utils.stringArrayToGenericTypeWithIdOnly("surroundingAreaConcernDetailId", propertyBuildingConcernFormValues.surroundingAreaConcernDetails);

        let propertyDetachedStructureFormValues = Object.assign({}, this.propertyForms.detachedStructure.value);
        property.detachedStructure = propertyDetachedStructureFormValues;
        property.detachedStructure.outbuildingDetails = Utils.stringArrayToGenericTypeWithIdOnly("outbuildingDetailId", propertyDetachedStructureFormValues.outbuildingDetails);
        property.detachedStructure.otherDetachedStructuresDetails = Utils.stringArrayToGenericTypeWithIdOnly("otherDetachedStructuresDetailId", propertyDetachedStructureFormValues.otherDetachedStructuresDetails);

        let propertyAdditionalExposureFormValues = Object.assign({}, this.propertyForms.additionalExposure.value);
        property.additionalExposure = propertyAdditionalExposureFormValues;
        property.additionalExposure.bearInvasionConcernDetails = Utils.stringArrayToGenericTypeWithIdOnly("bearInvasionConcernDetailId", propertyAdditionalExposureFormValues.bearInvasionConcernDetails);

        property.highValueKitchen = Object.assign({}, this.propertyForms.highValueKitchen.value);

        let propertyHighValueBathFormValues = Object.assign({}, this.propertyForms.highValueBath.value);
        property.highValueBath = propertyHighValueBathFormValues;
        property.highValueBath.bathroomFloors = Utils.stringArrayToGenericTypeWithIdOnly("bathroomFloorId", propertyHighValueBathFormValues.bathroomFloors);
        property.highValueBath.bathroomVanities = Utils.stringArrayToGenericTypeWithIdOnly("bathroomVanityId", propertyHighValueBathFormValues.bathroomVanities);
        property.highValueBath.bathroomCounters = Utils.stringArrayToGenericTypeWithIdOnly("bathroomCounterId", propertyHighValueBathFormValues.bathroomCounters);
        property.highValueBath.bathroomFixtures = Utils.stringArrayToGenericTypeWithIdOnly("bathroomFixtureId", propertyHighValueBathFormValues.bathroomFixtures);
        property.highValueBath.tubsAndShowers = Utils.stringArrayToGenericTypeWithIdOnly("tubAndShowerId", propertyHighValueBathFormValues.tubsAndShowers);

        let propertyHighValueFloorToCeilingFormValues = Object.assign({}, this.propertyForms.highValueFloorToCeiling.value);
        property.highValueFloorToCeiling = propertyHighValueFloorToCeilingFormValues;
        property.highValueFloorToCeiling.floorCoverings = Utils.stringArrayToGenericTypeWithIdOnly("floorCoveringId", propertyHighValueFloorToCeilingFormValues.floorCoverings);
        property.highValueFloorToCeiling.ceilings = Utils.stringArrayToGenericTypeWithIdOnly("ceilingId", propertyHighValueFloorToCeilingFormValues.ceilings);
        property.highValueFloorToCeiling.interiorWallCoverings = Utils.stringArrayToGenericTypeWithIdOnly("interiorWallCoveringId", propertyHighValueFloorToCeilingFormValues.interiorWallCoverings);
        property.highValueFloorToCeiling.wallTrims = Utils.stringArrayToGenericTypeWithIdOnly("wallTrimId", propertyHighValueFloorToCeilingFormValues.wallTrims);
        property.highValueFloorToCeiling.windowStyles = Utils.stringArrayToGenericTypeWithIdOnly("windowStyleId", propertyHighValueFloorToCeilingFormValues.windowStyles);
        property.highValueFloorToCeiling.windowBrands = Utils.stringArrayToGenericTypeWithIdOnly("windowBrandId", propertyHighValueFloorToCeilingFormValues.windowBrands);

        let propertyHighValueInteriorFeatureFormValues = Object.assign({}, this.propertyForms.highValueInteriorFeature.value);
        property.highValueInteriorFeature = propertyHighValueInteriorFeatureFormValues;
        property.highValueInteriorFeature.interiorDoorTypes = Utils.stringArrayToGenericTypeWithIdOnly("interiorDoorTypeId", propertyHighValueInteriorFeatureFormValues.interiorDoorTypes);
        property.highValueInteriorFeature.doorHardwares = Utils.stringArrayToGenericTypeWithIdOnly("doorHardwareId", propertyHighValueInteriorFeatureFormValues.doorHardwares);
        property.highValueInteriorFeature.roomWithCabinetrys = Utils.stringArrayToGenericTypeWithIdOnly("roomWithCabinetryId", propertyHighValueInteriorFeatureFormValues.roomWithCabinetrys);
        property.highValueInteriorFeature.lightingTypes = Utils.stringArrayToGenericTypeWithIdOnly("lightingTypeId", propertyHighValueInteriorFeatureFormValues.lightingTypes);
        property.highValueInteriorFeature.fireplaceTypes = Utils.stringArrayToGenericTypeWithIdOnly("fireplaceTypeId", propertyHighValueInteriorFeatureFormValues.fireplaceTypes);
        property.highValueInteriorFeature.staircases = Utils.stringArrayToGenericTypeWithIdOnly("staircaseId", propertyHighValueInteriorFeatureFormValues.staircases);
        property.highValueInteriorFeature.miscellaneousExtraFeatures = Utils.stringArrayToGenericTypeWithIdOnly("miscellaneousExtraFeatureId", propertyHighValueInteriorFeatureFormValues.miscellaneousExtraFeatures);

        return property;
    }
}