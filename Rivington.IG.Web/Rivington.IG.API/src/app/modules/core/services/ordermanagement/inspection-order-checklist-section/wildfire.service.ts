import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { FormBuilder, FormControl, FormGroup } from "@angular/forms";
import { SelectItem } from "primeng/components/common/selectitem";
import { Observable } from "rxjs/Observable";
import Utils from "../../../../shared/Utils";
import { Constants } from "../../../../shared/constants";
import { InspectionOrder } from "../../../../shared/models/ordermanagement/inspection-order";
import { CommonService } from "../../common.service";
import { InspectionOrderWildfireAssessment } from "../../../../shared/models/ordermanagement/inspection-order/checklist/wildfire";
import { InspectionOrderChecklistPropertyService } from "./property.service";
import { InspectionOrderProperty } from "../../../../shared/models/ordermanagement/inspection-order/checklist/property";
import { InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails } from "../../../../shared/models/ordermanagement/inspection-order/checklist/wildfire/exterior-siding/InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails";

export interface IInspectionOrderChecklistWildFireServiceForms {
    roof?: FormGroup;
    foundationToFrame?: FormGroup;
    exteriorSiding?: FormGroup;
    windows?: FormGroup;
    decksAndBalconies?: FormGroup;
    fencingAndOtherAttachments?: FormGroup;
    surroundings?: FormGroup;
    accessAndFireProtection?: FormGroup;
    externalFuelSource?: FormGroup;
}

@Injectable()
export class InspectionOrderChecklistWildFireService {
    public externalFuelSource: boolean;
    public addressHardToRead: boolean;
    public timelyResponseConcern: boolean;
    public fencingWithin30Feet: boolean;
    public combustibleUnderDBP: boolean;
    public combustibleOnDBP: boolean;
    public pdbCovered: boolean;
    public attachedPDorB: boolean;
    public sidingCondition: boolean;
    arrayExteriorSiding: InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails[];
    public isWildFireRequired: boolean;
    isModifiedPrimaryIdTrue: boolean;
    primaryRoofId: string;
    propertyTab: InspectionOrderProperty;
    wildfireAssessmentForms: IInspectionOrderChecklistWildFireServiceForms;

    constructor(private http: HttpClient,
        private commonService: CommonService,
        public fb: FormBuilder
    ) {
    }

    initiateFormValues(): IInspectionOrderChecklistWildFireServiceForms {
        this.wildfireAssessmentForms = {}
        this.wildfireAssessmentForms.roof = this.fb.group({
            'primaryRoofCoveringId': new FormControl(),
            'secondaryRoofCoveringId': new FormControl(),
            'otherRoofCoverings': new FormControl(),
            'roofShapeId': new FormControl(),
            'roofPitchId': new FormControl(),
            'roofConcernDetails': new FormControl(),
            'combustibleMaterialsOnRoof': new FormControl(false),
            'combustibleMaterialsonRoofComment': new FormControl(),
            'roofVentings': new FormControl(),
            'ventingOpeningAllowEmberEntry': new FormControl(false),
            'ventingMeshCoveringSizeComment': new FormControl(),
            'gutterTypes': new FormControl(),
            'gutterComment': new FormControl(),
            'eavesTypeId': new FormControl(),
            'eavesAllowEmberEntry': new FormControl(false),
            'eavesComment': new FormControl(),
        });

        this.wildfireAssessmentForms.foundationToFrame = this.fb.group({
            'openingsEmberEntry': new FormControl(false),
            'openingsEmberEntryComment': new FormControl(),
            'elevatedwithCombustibleMaterial': new FormControl(false),
            'elevatedwithCombustibleMaterialsComment': new FormControl(),
            'foundationTypeId': new FormControl(),
            'foundationComment': new FormControl(),
            'framingTypeId': new FormControl(),
        });

        this.wildfireAssessmentForms.exteriorSiding = this.fb.group({
            'primaryExteriorWallCoveringId': new FormControl(),
            'secondaryExteriorWallCoveringId': new FormControl(),
            'otherWallCoverings': new FormControl(),
            'nonCombustibleSiding': new FormControl(false),
            'sidingConditionConcernDetails': new FormControl(),
            'sidingConditionComment': new FormControl(),
        });

        this.wildfireAssessmentForms.windows = this.fb.group({
            'windowSusceptibletoFlame': new FormControl(false),
            'windowGlassTypes': new FormControl(),
            'windowFramingTypes': new FormControl(),
            'windowStyles': new FormControl(),
            'windowScreenTypes': new FormControl(),
            'interiorWindowCoveringTypes': new FormControl(),
            'exteriorWindowCoveringTypes': new FormControl(),
            'windowConcernsDetails': new FormControl(),
            'windowNote': new FormControl(),
        });

        this.wildfireAssessmentForms.decksAndBalconies = this.fb.group({
            'attachedPorcheDeckorBalcony': new FormControl(false),
            'porchDeckBalconyConstructions': new FormControl(),
            'porchDeckBalconyCovered': new FormControl(false),
            'coveringMaterial': new FormControl(),
            'deckConditionConcernsDetails': new FormControl(),
            'attachedStructuresComment': new FormControl(),
            'combustibleMaterialsONDeckBalconyPorch': new FormControl(false),
            'combustiblesONDeckBalconyPorchDescription': new FormControl(),
            'combustibleMaterialsUNDERDeckBalconyPorch': new FormControl(false),
            'combustiblesUNDERDeckBalconyPorchDescription': new FormControl()
        });

        this.wildfireAssessmentForms.fencingAndOtherAttachments = this.fb.group({
            'fencingWithin30Feet': new FormControl(false),
            'fencingTypes': new FormControl(),
            'fenceConditionConcernDetails': new FormControl(),
            'fenceComment': new FormControl(),
            'otherAttachmentTypes': new FormControl(),
            'outbuildingDetails': new FormControl(),
            'otherDetachedStructuresDetails': new FormControl()
        });

        this.wildfireAssessmentForms.surroundings = this.fb.group({
            'combustible05Feet': new FormControl(false),
            'combustible05FeetComment': new FormControl(),
            'combustible530Feet': new FormControl(false),
            'combustible530FeetComment': new FormControl(),
            'combustible30100Feet': new FormControl(false),
            'combustible30100FeetComment': new FormControl(),
            'additionalStructuresContributor': new FormControl(false),
            'additionalStructuresContributorComment': new FormControl(),
            'topographicalEnvironmentalContributor': new FormControl(false),
            'topographicalEnvironmentalContributorComment': new FormControl(),
            'volatileVegetationBeyond100Feet': new FormControl(false),
            'volatileVegetationBeyond100FeetComment': new FormControl(),
            'neighboringResidence': new FormControl(false),
            'neighboringResidenceComment': new FormControl()
        });

        this.wildfireAssessmentForms.accessAndFireProtection = this.fb.group({
            'timelyResponseConcern': new FormControl(false),
            'timelyResponseConcernComment': new FormControl(),
            'addressHardtoRead': new FormControl(false),
            'addressReadabilityComment': new FormControl(),
            'bridgeConcern': new FormControl(false),
            'bridgeConcernComment': new FormControl(),
            'respondingFireDepartment': new FormControl(),
            'fireDepartmentStaffingId': new FormControl(),
            'fireDepartmentDistancetoHome': new FormControl(),
            'fireDepartmentTravelTimetoHome': new FormControl(),
            'nearestFireHydrant': new FormControl(),
            'alternateWaterSourceIfNoHydrant': new FormControl()
        });

        this.wildfireAssessmentForms.externalFuelSource = this.fb.group({
            'externalFuelSource': new FormControl(false),
            'externalFuelSourceTypes': new FormControl(),
            'externalFuelSourceDistanceFromHome': new FormControl(),
            'woodStoveOrFireplace': new FormControl(false),
            'woodStorageLocation': new FormControl(),
            'firePeventiveMeasure': new FormControl()
        });

        return this.wildfireAssessmentForms;
    }

    public isInitiated: boolean = false;

    setFormValues(existingIO: InspectionOrder) {
        if (existingIO) {
            if (existingIO.wildfireAssessment) {
                Utils.updateFormGroup(this.wildfireAssessmentForms.roof, existingIO.wildfireAssessment.roof)
                Utils.updateFormGroup(this.wildfireAssessmentForms.foundationToFrame, existingIO.wildfireAssessment.foundationToFrame)
                Utils.updateFormGroup(this.wildfireAssessmentForms.exteriorSiding, existingIO.wildfireAssessment.exteriorSiding)
                Utils.updateFormGroup(this.wildfireAssessmentForms.windows, existingIO.wildfireAssessment.window)
                Utils.updateFormGroup(this.wildfireAssessmentForms.decksAndBalconies, existingIO.wildfireAssessment.deckAndBalcony)
                Utils.updateFormGroup(this.wildfireAssessmentForms.fencingAndOtherAttachments, existingIO.wildfireAssessment.fencingAndOtherAttachment)
                Utils.updateFormGroup(this.wildfireAssessmentForms.surroundings, existingIO.wildfireAssessment.surrounding)
                Utils.updateFormGroup(this.wildfireAssessmentForms.accessAndFireProtection, existingIO.wildfireAssessment.accessAndFireProtection)
                Utils.updateFormGroup(this.wildfireAssessmentForms.externalFuelSource, existingIO.wildfireAssessment.externalFuelSource)
            }

            //Exterior Siding
            if (existingIO.wildfireAssessment.exteriorSiding.sidingConditionConcernDetails) {
                this.sidingCondition = false;
            }
            else {
                let sidingString = existingIO.wildfireAssessment.exteriorSiding.sidingConditionConcernDetails.toString();
                let arraySidingString = sidingString.split(",");
                if (arraySidingString.includes("N")) {
                    this.sidingCondition = true;
                }
                else {
                    this.sidingCondition = false;
                }
            }

            if(this.sidingCondition) {
                this.wildfireAssessmentForms.exteriorSiding.get('sidingConditionComment').setValue('');
              }

            //Decks & Balconies
            this.attachedPDorB = existingIO.wildfireAssessment.deckAndBalcony.attachedPorcheDeckorBalcony;
            if(!this.attachedPDorB){
                this.wildfireAssessmentForms.decksAndBalconies.get('porchDeckBalconyConstructions').setValue(null);
                this.wildfireAssessmentForms.decksAndBalconies.get('porchDeckBalconyCovered').setValue(false);
                this.wildfireAssessmentForms.decksAndBalconies.get('deckConditionConcernsDetails').setValue(null);
                this.wildfireAssessmentForms.decksAndBalconies.get('combustibleMaterialsONDeckBalconyPorch').setValue(false);
                this.wildfireAssessmentForms.decksAndBalconies.get('combustibleMaterialsUNDERDeckBalconyPorch').setValue(false);
                this.wildfireAssessmentForms.decksAndBalconies.get('coveringMaterial').setValue('');
                this.pdbCovered = this.wildfireAssessmentForms.decksAndBalconies.get('coveringMaterial').value;
                this.wildfireAssessmentForms.decksAndBalconies.get('combustiblesONDeckBalconyPorchDescription').setValue('');
                this.combustibleOnDBP = this.wildfireAssessmentForms.decksAndBalconies.get('combustibleMaterialsONDeckBalconyPorch').value;
                this.wildfireAssessmentForms.decksAndBalconies.get('combustiblesUNDERDeckBalconyPorchDescription').setValue('');
                this.combustibleUnderDBP = this.wildfireAssessmentForms.decksAndBalconies.get('combustibleMaterialsUNDERDeckBalconyPorch').value;
              }

            this.pdbCovered = existingIO.wildfireAssessment.deckAndBalcony.porchDeckBalconyCovered;
            if(!this.pdbCovered){
                this.wildfireAssessmentForms.decksAndBalconies.get('coveringMaterial').setValue('');
            }

            this.combustibleOnDBP = existingIO.wildfireAssessment.deckAndBalcony.combustibleMaterialsONDeckBalconyPorch;
            if(!this.combustibleOnDBP){
                this.wildfireAssessmentForms.decksAndBalconies.get('combustiblesONDeckBalconyPorchDescription').setValue('');
            }

            this.combustibleUnderDBP = existingIO.wildfireAssessment.deckAndBalcony.combustibleMaterialsUNDERDeckBalconyPorch;
            if(!this.combustibleUnderDBP){
                this.wildfireAssessmentForms.decksAndBalconies.get('combustiblesUNDERDeckBalconyPorchDescription').setValue('');
            }   

            //Fencing & Other Attachment
            this.fencingWithin30Feet = existingIO.wildfireAssessment.fencingAndOtherAttachment.fencingWithin30Feet;
            if(!this.fencingWithin30Feet){
                this.wildfireAssessmentForms.fencingAndOtherAttachments.get('fencingTypes').setValue(null);
                this.wildfireAssessmentForms.fencingAndOtherAttachments.get('fenceConditionConcernDetails').setValue(null);
            }

            //Access & Fire Protection
            this.timelyResponseConcern = existingIO.wildfireAssessment.accessAndFireProtection.timelyResponseConcern;
            if(!this.timelyResponseConcern){
                this.wildfireAssessmentForms.accessAndFireProtection.get('timelyResponseConcernComment').setValue('');
            }
            
            this.addressHardToRead = existingIO.wildfireAssessment.accessAndFireProtection.addressHardtoRead;
            if(!this.addressHardToRead){
                this.wildfireAssessmentForms.accessAndFireProtection.get('addressReadabilityComment').setValue('');
            }

            //External Fuel Source
            this.externalFuelSource = existingIO.wildfireAssessment.externalFuelSource.externalFuelSource;
            if(!this.externalFuelSource){
                this.wildfireAssessmentForms.externalFuelSource.get('externalFuelSourceTypes').setValue(null);
                this.wildfireAssessmentForms.externalFuelSource.get('externalFuelSourceDistanceFromHome').setValue('');
            }
            
        }
    }

    clearValue(value: string) {
        switch(value) {
            //Decks & Balconies
            case 'attachedPDorB':
            if(!this.attachedPDorB){
              this.wildfireAssessmentForms.decksAndBalconies.get('porchDeckBalconyConstructions').setValue(null);
              this.wildfireAssessmentForms.decksAndBalconies.get('porchDeckBalconyCovered').setValue(false);
              this.wildfireAssessmentForms.decksAndBalconies.get('deckConditionConcernsDetails').setValue(null);
              this.wildfireAssessmentForms.decksAndBalconies.get('combustibleMaterialsONDeckBalconyPorch').setValue(false);
              this.wildfireAssessmentForms.decksAndBalconies.get('combustibleMaterialsUNDERDeckBalconyPorch').setValue(false);
              this.wildfireAssessmentForms.decksAndBalconies.get('coveringMaterial').setValue('');
              this.pdbCovered = this.wildfireAssessmentForms.decksAndBalconies.get('coveringMaterial').value;
              this.wildfireAssessmentForms.decksAndBalconies.get('combustiblesONDeckBalconyPorchDescription').setValue('');
              this.combustibleOnDBP = this.wildfireAssessmentForms.decksAndBalconies.get('combustibleMaterialsONDeckBalconyPorch').value;
              this.wildfireAssessmentForms.decksAndBalconies.get('combustiblesUNDERDeckBalconyPorchDescription').setValue('');
              this.combustibleUnderDBP = this.wildfireAssessmentForms.decksAndBalconies.get('combustibleMaterialsUNDERDeckBalconyPorch').value;
            }
            break;
            case 'pdbCovered':
            if(!this.pdbCovered){
                this.wildfireAssessmentForms.decksAndBalconies.get('coveringMaterial').setValue('');
            }
            break;
            case 'combustibleOnDBP':
            if(!this.combustibleOnDBP){
                this.wildfireAssessmentForms.decksAndBalconies.get('combustiblesONDeckBalconyPorchDescription').setValue('');
            }
            case 'combustibleUnderDBP':
            if(!this.combustibleUnderDBP){
                this.wildfireAssessmentForms.decksAndBalconies.get('combustiblesUNDERDeckBalconyPorchDescription').setValue('');
            }
            break;

            //Fencing & Other Attachment
            case 'fencingWithin30Feet':
            if(!this.fencingWithin30Feet){
                this.wildfireAssessmentForms.fencingAndOtherAttachments.get('fencingTypes').setValue(null);
                this.wildfireAssessmentForms.fencingAndOtherAttachments.get('fenceConditionConcernDetails').setValue(null);
            }
            break;

            //Access & Fire Protection
            case 'timelyResponseConcern':
            if(!this.timelyResponseConcern){
                this.wildfireAssessmentForms.accessAndFireProtection.get('timelyResponseConcernComment').setValue('');
            }
            break;
            case 'addressHardToRead':
            if(!this.addressHardToRead){
                this.wildfireAssessmentForms.accessAndFireProtection.get('addressReadabilityComment').setValue('');
            }
            break;

            //External Fuel Source
            case 'externalFuelSource':
            if(!this.externalFuelSource){
                this.wildfireAssessmentForms.externalFuelSource.get('externalFuelSourceTypes').setValue(null);
                this.wildfireAssessmentForms.externalFuelSource.get('externalFuelSourceDistanceFromHome').setValue('');
            }
            default:
            break;
        }
    }

    getPrimaryRoofCovering(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.PrimaryRoofCovering");
    }

    getSecondaryRoofCovering(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.SecondaryRoofCovering");
    }

    getOtherRoofCovering(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.OtherRoofCovering");
    }

    getRoofShape(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.RoofShape");
    }

    getRoofPitch(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.RoofPitch");
    }

    getRoofConcernsDetails(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.RoofConcernDetail");
    }

    getRoofVenting(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.RoofVenting");
    }

    getGutterType(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.GutterType");
    }

    getEavesType(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.EavesType");
    }

    getFoundationType(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.FoundationType");
    }

    getFramingType(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.FramingType");
    }

    getPrimaryExteriorWallCovering(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.PrimaryExteriorWallCovering");
    }

    getSecondaryExteriorWallCovering(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.SecondaryExteriorWallCovering");
    }

    getOtherWallExteriorWallCovering(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.OtherWallCovering");
    }

    getSidingConditionConcernDetail(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.SidingConditionConcernDetail");
    }

    getWindowGlassType(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.WindowGlassType");
    }

    getWindowFramingType(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.WindowFramingType");
    }

    getWindowStyle(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.WindowStyle");
    }

    getWindowScreenType(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.WindowScreenType");
    }

    getInteriorWindowCoveringType(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.InteriorWindowCoveringType");
    }

    getExteriorWindowCoveringType(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.ExteriorWindowCoveringType");
    }

    getWindowConcernDetails(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.WindowConcernDetail");
    }

    getPorchDeckBalconyConstruction(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.PorchDeckBalconyConstruction");
    }

    getDeckConditionConernsDetails(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.DeckConditionConcernDetail ");
    }

    getFencingType(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.FencingType ");
    }

    getFenceConditionConcernsDetails(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.FenceConditionConcernDetail ");
    }

    getOtherAttachmentTypes(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.OtherAttachmentType ");
    }

    getOutbuildingDetails(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.OutbuildingDetail ");
    }

    getOtherDetachedStructuresDetails(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.OtherDetachedStructuresDetail ");
    }

    getFireDepartmentStaffing(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.FireDepartmentStaffing ");
    }

    getExternalFuelSourceType(): Observable<SelectItem[]> {
        return this.commonService.getSelectItemList("OrderManagement.ExternalFuelSourceType ");
    }

    getIOWildFire(id: string) {
        return this.http.get(`${Constants.ApiUrl}/iowildfire/${id}`)
            .map(responseData => {
                if (!!!responseData) return responseData;

                let data = (responseData as any);

                // roof
                let roof = data.roof;
                if (roof) {
                    roof.otherRoofCoverings = Utils.genericTypeArrayToStringOfIds("otherRoofCoveringId", roof.otherRoofCoverings);
                    roof.roofConcernDetails = Utils.genericTypeArrayToStringOfIds("roofConcernDetailId", roof.roofConcernDetails);
                    roof.roofVentings = Utils.genericTypeArrayToStringOfIds("roofVentingId", roof.roofVentings);
                    roof.gutterTypes = Utils.genericTypeArrayToStringOfIds("gutterTypeId", roof.gutterTypes);
                }

                // foundatio to frame
                let foundationToFrame = data.foundationToFrame;

                // exterior siding
                let exteriorSiding = data.exteriorSiding;
                if (exteriorSiding) {
                    exteriorSiding.otherWallCoverings = Utils.genericTypeArrayToStringOfIds("otherWallCoveringId", exteriorSiding.otherWallCoverings);
                    exteriorSiding.sidingConditionConcernDetails = Utils.genericTypeArrayToStringOfIds("sidingConditionConcernDetailId", exteriorSiding.sidingConditionConcernDetails);
                }

                // window 
                let window = data.window;
                if (window) {
                    window.windowGlassTypes = Utils.genericTypeArrayToStringOfIds("windowGlassTypeId", window.windowGlassTypes);
                    window.windowFramingTypes = Utils.genericTypeArrayToStringOfIds("windowFramingTypeId", window.windowFramingTypes);
                    window.windowStyles = Utils.genericTypeArrayToStringOfIds("windowStyleId", window.windowStyles);
                    window.windowScreenTypes = Utils.genericTypeArrayToStringOfIds("windowScreenTypeId", window.windowScreenTypes);
                    window.interiorWindowCoveringTypes = Utils.genericTypeArrayToStringOfIds("interiorWindowCoveringTypeId", window.interiorWindowCoveringTypes);
                    window.exteriorWindowCoveringTypes = Utils.genericTypeArrayToStringOfIds("exteriorWindowCoveringTypeId", window.exteriorWindowCoveringTypes);
                    window.windowConcernsDetails = Utils.genericTypeArrayToStringOfIds("windowConcernDetailId", window.windowConcernsDetails);
                }

                // decks and balconies
                let deckAndBalcony = data.deckAndBalcony;
                if (deckAndBalcony) {
                    deckAndBalcony.porchDeckBalconyConstructions = Utils.genericTypeArrayToStringOfIds("porchDeckBalconyConstructionId", deckAndBalcony.porchDeckBalconyConstructions);
                    deckAndBalcony.deckConditionConcernsDetails = Utils.genericTypeArrayToStringOfIds("deckConditionConcernDetailId", deckAndBalcony.deckConditionConcernsDetails);
                }

                // fencing and other attachments
                let fencingAndOtherAttachment = data.fencingAndOtherAttachment;
                if (fencingAndOtherAttachment) {
                    fencingAndOtherAttachment.fencingTypes = Utils.genericTypeArrayToStringOfIds("fencingTypeId", fencingAndOtherAttachment.fencingTypes);
                    fencingAndOtherAttachment.fenceConditionConcernDetails = Utils.genericTypeArrayToStringOfIds("fenceConditionConcernDetailId", fencingAndOtherAttachment.fenceConditionConcernDetails);
                    fencingAndOtherAttachment.otherAttachmentTypes = Utils.genericTypeArrayToStringOfIds("otherAttachmentTypeId", fencingAndOtherAttachment.otherAttachmentTypes);
                    fencingAndOtherAttachment.outbuildingDetails = Utils.genericTypeArrayToStringOfIds("outbuildingDetailId", fencingAndOtherAttachment.outbuildingDetails);
                    fencingAndOtherAttachment.otherDetachedStructuresDetails = Utils.genericTypeArrayToStringOfIds("otherDetachedStructuresDetailId", fencingAndOtherAttachment.otherDetachedStructuresDetails);
                }

                // external fuel source
                let externalFuelSource = data.externalFuelSource;
                if (externalFuelSource) {
                    externalFuelSource.externalFuelSourceTypes = Utils.genericTypeArrayToStringOfIds("externalFuelSourceTypeId", externalFuelSource.externalFuelSourceTypes);
                }

                return data;
            })
            .catch(this.commonService.handleObservableHttpError);
    }

    getWildfireAssessmentValues(): InspectionOrderWildfireAssessment {
        if (!!!this.wildfireAssessmentForms) return;

        let wildfire = new InspectionOrderWildfireAssessment();

        // roof
        let wildFireRoofFormValues = Object.assign({}, this.wildfireAssessmentForms.roof.value);
        wildfire.roof = wildFireRoofFormValues;
        wildfire.roof.otherRoofCoverings = Utils.stringArrayToGenericTypeWithIdOnly("otherRoofCoveringId", wildFireRoofFormValues.otherRoofCoverings);
        wildfire.roof.roofConcernDetails = Utils.stringArrayToGenericTypeWithIdOnly("roofConcernDetailId", wildFireRoofFormValues.roofConcernDetails);
        wildfire.roof.roofVentings = Utils.stringArrayToGenericTypeWithIdOnly("roofVentingId", wildFireRoofFormValues.roofVentings);
        wildfire.roof.gutterTypes = Utils.stringArrayToGenericTypeWithIdOnly("gutterTypeId", wildFireRoofFormValues.gutterTypes);

        // foundation to frame
        let wildFireFoundationToFrameFormValues = Object.assign({}, this.wildfireAssessmentForms.foundationToFrame.value);
        wildfire.foundationToFrame = wildFireFoundationToFrameFormValues;

        // exterior siding
        let wildFireExteriorSidingFormValues = Object.assign({}, this.wildfireAssessmentForms.exteriorSiding.value);
        wildfire.exteriorSiding = wildFireExteriorSidingFormValues;
        wildfire.exteriorSiding.otherWallCoverings = Utils.stringArrayToGenericTypeWithIdOnly("otherWallCoveringId", wildFireExteriorSidingFormValues.otherWallCoverings);
        wildfire.exteriorSiding.sidingConditionConcernDetails = Utils.stringArrayToGenericTypeWithIdOnly("sidingConditionConcernDetailId", wildFireExteriorSidingFormValues.sidingConditionConcernDetails);

        // window
        let wildFireWindowFormValues = Object.assign({}, this.wildfireAssessmentForms.windows.value);
        wildfire.window = wildFireWindowFormValues;
        wildfire.window.windowGlassTypes = Utils.stringArrayToGenericTypeWithIdOnly("windowGlassTypeId", wildFireWindowFormValues.windowGlassTypes);
        wildfire.window.windowFramingTypes = Utils.stringArrayToGenericTypeWithIdOnly("windowFramingTypeId", wildFireWindowFormValues.windowFramingTypes);
        wildfire.window.windowStyles = Utils.stringArrayToGenericTypeWithIdOnly("windowStyleId", wildFireWindowFormValues.windowStyles);
        wildfire.window.windowScreenTypes = Utils.stringArrayToGenericTypeWithIdOnly("windowScreenTypeId", wildFireWindowFormValues.windowScreenTypes);
        wildfire.window.interiorWindowCoveringTypes = Utils.stringArrayToGenericTypeWithIdOnly("interiorWindowCoveringTypeId", wildFireWindowFormValues.interiorWindowCoveringTypes);
        wildfire.window.exteriorWindowCoveringTypes = Utils.stringArrayToGenericTypeWithIdOnly("exteriorWindowCoveringTypeId", wildFireWindowFormValues.exteriorWindowCoveringTypes);
        wildfire.window.windowConcernsDetails = Utils.stringArrayToGenericTypeWithIdOnly("windowConcernDetailId", wildFireWindowFormValues.windowConcernsDetails);

        // decks and balconies
        let wildFireDeclAndBalconyFormValues = Object.assign({}, this.wildfireAssessmentForms.decksAndBalconies.value);
        wildfire.deckAndBalcony = wildFireDeclAndBalconyFormValues;
        wildfire.deckAndBalcony.porchDeckBalconyConstructions = Utils.stringArrayToGenericTypeWithIdOnly("porchDeckBalconyConstructionId", wildFireDeclAndBalconyFormValues.porchDeckBalconyConstructions);
        wildfire.deckAndBalcony.deckConditionConcernsDetails = Utils.stringArrayToGenericTypeWithIdOnly("deckConditionConcernDetailId", wildFireDeclAndBalconyFormValues.deckConditionConcernsDetails);

        // fencing and other attachments
        let wildFireFencingAndOtherAttachmentFormValues = Object.assign({}, this.wildfireAssessmentForms.fencingAndOtherAttachments.value);
        wildfire.fencingAndOtherAttachment = wildFireFencingAndOtherAttachmentFormValues;
        wildfire.fencingAndOtherAttachment.fencingTypes = Utils.stringArrayToGenericTypeWithIdOnly("fencingTypeId", wildFireFencingAndOtherAttachmentFormValues.fencingTypes);
        wildfire.fencingAndOtherAttachment.fenceConditionConcernDetails = Utils.stringArrayToGenericTypeWithIdOnly("fenceConditionConcernDetailId", wildFireFencingAndOtherAttachmentFormValues.fenceConditionConcernDetails);
        wildfire.fencingAndOtherAttachment.otherAttachmentTypes = Utils.stringArrayToGenericTypeWithIdOnly("otherAttachmentTypeId", wildFireFencingAndOtherAttachmentFormValues.otherAttachmentTypes);
        wildfire.fencingAndOtherAttachment.outbuildingDetails = Utils.stringArrayToGenericTypeWithIdOnly("outbuildingDetailId", wildFireFencingAndOtherAttachmentFormValues.outbuildingDetails);
        wildfire.fencingAndOtherAttachment.otherDetachedStructuresDetails = Utils.stringArrayToGenericTypeWithIdOnly("otherDetachedStructuresDetailId", wildFireFencingAndOtherAttachmentFormValues.otherDetachedStructuresDetails);

        // surrounding
        let wildFireSurroundingFormValues = Object.assign({}, this.wildfireAssessmentForms.surroundings.value);
        wildfire.surrounding = wildFireSurroundingFormValues;

        // access and fire protection
        let wildFireAccessAndFireProtectionFormValues = Object.assign({}, this.wildfireAssessmentForms.accessAndFireProtection.value);
        wildfire.accessAndFireProtection = wildFireAccessAndFireProtectionFormValues;

        // external fuel source
        let wildFireExternalFuelSourceFormValues = Object.assign({}, this.wildfireAssessmentForms.externalFuelSource.value);
        wildfire.externalFuelSource = wildFireExternalFuelSourceFormValues;
        wildfire.externalFuelSource.externalFuelSourceTypes = Utils.stringArrayToGenericTypeWithIdOnly("externalFuelSourceTypeId", wildFireExternalFuelSourceFormValues.externalFuelSourceTypes);

        if (this.primaryRoofId && !this.isModifiedPrimaryIdTrue) {
            wildfire.roof.primaryRoofCoveringId = this.primaryRoofId;
        }

        return wildfire;
    }
}