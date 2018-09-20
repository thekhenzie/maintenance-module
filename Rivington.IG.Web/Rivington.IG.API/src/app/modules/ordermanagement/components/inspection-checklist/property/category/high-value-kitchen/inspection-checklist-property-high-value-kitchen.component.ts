import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { SelectItem, Dialog } from 'primeng/primeng';
import { CommonService } from '../../../../../../core/services/common.service';
import { InspectionOrderChecklistPropertyService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/property.service';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { InspectionOrderPropertyHighValueKitchenAppliances } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-kitchen/InspectionOrderPropertyHighValueKitchenAppliances';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { Table } from 'primeng/table';
import { Column } from '../../../../../../shared/components/pArtTable/models/column';
import { PrimeTableUtils } from '../../../../../../shared/PrimeTableUtils';
import Utils from '../../../../../../shared/Utils';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-property-high-value-kitchen',
  templateUrl: './inspection-checklist-property-high-value-kitchen.component.html',
  styleUrls: ['./inspection-checklist-property-high-value-kitchen.component.css'],
  providers: [ConfirmationService]
})
export class InspectionChecklistPropertyHighValueKitchenComponent extends BaseComponent implements OnInit {
  kitchenCabinets: SelectItem[];
  kitchenCountertops: SelectItem[];
  applianceTypes: SelectItem[];
  applianceBrands: SelectItem[];

  appliance: Appliance = {
    table: {
      noRecordColspan: 0,
      totalRecord: 0,
      data: []
    },
    showApplianceFormModal: false,
    isAddAppliance: false,
    currentIndex: -1
  };

  public dialogErrorMessage: string;
  public doShowErrorDialog: boolean = false;

  constructor(
    public ioChecklistPropertyService: InspectionOrderChecklistPropertyService,
    public fb: FormBuilder,
    private commonService: CommonService,
    private route: ActivatedRoute,
    private conf: ConfirmationService,
    public ioService: InspectionOrderService,
  ) {
    super();
  }

  @ViewChild('applianceTable') public applianceTable: Table;
  @ViewChild('applianceDialog') public applianceDialog: Dialog;

  ngOnInit() {
    
    this.ioChecklistPropertyService.getKitchenCabinets().takeUntil(this.stop$).subscribe(data => this.kitchenCabinets = data);
    this.ioChecklistPropertyService.getKitchenCountertop().takeUntil(this.stop$).subscribe(data => this.kitchenCountertops = data);
    this.ioChecklistPropertyService.getApplianceTypes().takeUntil(this.stop$).subscribe(data => this.applianceTypes = data);
    this.ioChecklistPropertyService.getApplianceBrand().takeUntil(this.stop$).subscribe(data => this.applianceBrands = data);

    this.appliance.form = this.fb.group({
      'applianceTypeId': new FormControl('', Validators.required),
      'applianceBrandId': new FormControl('', Validators.required),
      'numberofAppliance': new FormControl(0, [Validators.required, Validators.min(1)])
    });

    this.applianceTable.columns = [
      new Column({ field: "item", header: "Item", sortable: false, width: '50' }),
      new Column({ field: "applianceTypeId", sortable: false, visible: false }),
      new Column({ field: "applianceType", header: "Type", sortable: false }),
      new Column({ field: "applianceBrandId", sortable: false, visible: false }),
      new Column({ field: "applianceBrand", header: "Brand", sortable: false, width: '200' }),
      new Column({ field: "numberofAppliance", header: "Number of Appliances", sortable: false, width: '180px' }),
      new Column({ field: "action", sortable: false, width: '200' })
    ];

    this.appliance.table.noRecordColspan = this.applianceTable.columns.filter(c => c.visible).length;
    PrimeTableUtils.setDefaults(this.applianceTable);
    this.applianceTable.paginator = false;

    let appliances = this.ioChecklistPropertyService.propertyForms.highValueKitchen.get("appliances");
    let appliancesValue = (appliances.value || []).slice();
    appliances.setValue(null);

    appliances.valueChanges.takeUntil(this.stop$).subscribe(data => {
      this.appliance.table.data = data || [];
      this.appliance.table.totalRecord = data.length;
    });

    appliances.setValue(appliancesValue);
  }

  setPropertyFieldValue(value, fieldname) {
    this.ioChecklistPropertyService[value] = this.ioChecklistPropertyService.propertyForms.highValueKitchen.get(fieldname).value;

    this.ioChecklistPropertyService.clearValue(value);
  }

  showApplianceFormModal(isShow: boolean = true) {
    this.appliance.showApplianceFormModal = isShow;
    if (isShow) {

    } else {
      this.appliance.currentIndex = -1;
    }
  }

  addApplianceClickEvent() {
    this.appliance.isAddAppliance = true;
    this.appliance.form.reset();
    this.appliance.form.markAsPristine();
    this.showApplianceFormModal();
  }

  editApplianceClickEvent(index, rowData) {
    this.appliance.isAddAppliance = false;
    this.appliance.currentIndex = index;

    Utils.updateFormGroup(this.appliance.form, rowData);
    this.appliance.form.markAsPristine();

    this.showApplianceFormModal(true);
  }

  deleteApplianceClickEvent(index, item) {
    // this.conf.confirm({
    //   message: 'Do you want to discard changes?',
    //   // accept: fnCancel
    // });
    this.appliance.table.data.splice(index, 1);
  }

  cancelApplianceClickEvent() {
    let form = this.appliance.form;
    let fnCancel = () => {
      this.showApplianceFormModal(false);
      form.markAsPristine();
    }

    let fnShowConfirm = () => {
      this.conf.confirm({
        message: 'Do you want to discard changes?',
        accept: fnCancel
      });
    }

    if (this.appliance.isAddAppliance) {
      if (form.dirty && (form.value.applianceBrandId || form.value.applianceTypeId || form.value.numberofAppliance)) {
        fnShowConfirm();
      }
      else {
        fnCancel();
      }
    }
    else {
      if (form.dirty) {
        fnShowConfirm();
      }
      else {
        fnCancel();
      }
    }
  }
  
  saveAppliance() {
    let currentAppliance: InspectionOrderPropertyHighValueKitchenAppliances = Object.assign({}, this.appliance.form.value);
    currentAppliance = Object.assign(currentAppliance, {
      applianceType: {
        id: currentAppliance.applianceTypeId,
        name: Utils.getLabelOfSelectItemByValue(this.applianceTypes, currentAppliance.applianceTypeId)
      },
      applianceBrand: {
        id: currentAppliance.applianceBrandId,
        name: Utils.getLabelOfSelectItemByValue(this.applianceBrands, currentAppliance.applianceBrandId)
      }
    })

    let fnNoOfApplianceIsValid = () => {
      return currentAppliance.numberofAppliance;
    }

    let appliances = this.appliance.table.data;
    let APPLIANCE_ALREADY_EXIST = "Appliance already exist.";
    if (this.appliance.isAddAppliance) {
      // check duplicates
      let hasMatch = appliances.some((rowData) => {
        return (rowData.applianceTypeId === currentAppliance.applianceTypeId &&
          rowData.applianceBrandId === currentAppliance.applianceBrandId);
      })

      if(hasMatch) {
        Utils.showError(APPLIANCE_ALREADY_EXIST);
        return;
      } else {
        appliances.push(currentAppliance);
      }
    }
    else {
      // check duplicates
      let hasDuplicate = false;
      for (let i = 0, appliancesLength = appliances.length; i < appliancesLength; i++) {
        let rowData = appliances[i];
        if(i !== this.appliance.currentIndex && 
          rowData.applianceTypeId === currentAppliance.applianceTypeId &&
          rowData.applianceBrandId === currentAppliance.applianceBrandId) {
            hasDuplicate = true;
            break;
        }
      }

      if(hasDuplicate) {
        Utils.showError(APPLIANCE_ALREADY_EXIST);
        return;
      }

      appliances[this.appliance.currentIndex] = currentAppliance;
    }

    this.ioChecklistPropertyService.propertyForms.highValueKitchen.get("appliances").setValue(appliances);
    this.showApplianceFormModal(false);
  }

  showErrorDialog(message: string) {
    this.dialogErrorMessage = message;
    this.doShowErrorDialog = true;
  }

  hasError(fb: FormGroup, name: string) {
    var e = this.getFormControl(fb, name);
    return e && (e.dirty || e.touched) && !e.valid;
  }

  getFormControl(fb: FormGroup, name: string) {
    return fb.get(name);
  }

  onDialogShowEvent() {
    setTimeout(() =>{
      this.applianceDialog.center.bind(this.applianceDialog)
    }, 0)
  }
}

export class Appliance {
  form?: FormGroup;
  table?: {
    data?: InspectionOrderPropertyHighValueKitchenAppliances[],
    noRecordColspan?: number,
    totalRecord?: number
  }
  isAddAppliance?: boolean;
  showApplianceFormModal?: boolean;
  currentIndex?: number;
}