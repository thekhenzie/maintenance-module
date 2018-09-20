import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { InspectionOrderChecklistWildFireService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/wildfire.service';
import { SelectItem } from 'primeng/components/common/selectitem';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-wildfire-decks-and-balconies',
  templateUrl: './inspection-checklist-wildfire-decks-and-balconies.component.html',
  styleUrls: ['./inspection-checklist-wildfire-decks-and-balconies.component.css']
})
export class InspectionChecklistWildfireDecksAndBalconiesComponent extends BaseComponent implements OnInit {
  deckConditionConcernDetails: SelectItem[];
  porchDeckBalconyConstruction: SelectItem[];

  constructor(public wildFireService: InspectionOrderChecklistWildFireService,
    public ioService: InspectionOrderService) {
    super();
   }

  ngOnInit() {
    this.wildFireService.getPorchDeckBalconyConstruction().takeUntil(this.stop$).subscribe(data => this.porchDeckBalconyConstruction = data);
    this.wildFireService.getDeckConditionConernsDetails().takeUntil(this.stop$).subscribe(data => this.deckConditionConcernDetails = data);
  }

  setWildFireValue(value, fieldname) {
    this.wildFireService[value] = this.wildFireService.wildfireAssessmentForms.decksAndBalconies.get(fieldname).value;

    this.wildFireService.clearValue(value);
  }
}
