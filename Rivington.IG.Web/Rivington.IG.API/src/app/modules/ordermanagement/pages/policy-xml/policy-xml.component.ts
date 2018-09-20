import { Component, OnInit } from "@angular/core";
import { BaseComponent } from "../../../shared/BaseComponent";
import { FormGroup, FormBuilder, FormControl } from "@angular/forms";
import { PolicyService } from "../../../core/services/ordermanagement/policy.service";
import { Router } from "@angular/router";
import Utils from "../../../shared/Utils";



@Component({
  selector: 'app-policy-xml',
  templateUrl: './policy-xml.component.html',
  styleUrls: ['./policy-xml.component.css']
})
export class PolicyXmlComponent extends BaseComponent implements OnInit {

  policyXmlForm: FormGroup;
  xmlStringValue: string;

  constructor(
    public fb: FormBuilder,
    private policyService: PolicyService,
    private router: Router) {
    super();
  }
  ngOnInit() {
    this.policyXmlForm = this.fb.group({
      'policyXml': new FormControl(`<Envelope xmlns="http://schemas.xmlsoap.org/soap/envelope/">
      <Body>
        <PolicyRequest xmlns="https://RivPartners.com">
          <Header><![CDATA[<Header><Sender>TOPAWS</Sender><Password>Ti3#1%J489&amp;gu</Password><Version>1.6</Version></Header>]]></Header>>
          <Data>
            <![CDATA[<?xml version="1.0" encoding="UTF-8"?>
            <Data xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" skipDupCheck="Y">
            <Order>
              <AccountNumber>601683</AccountNumber>
            </Order>
            <Policy>
              <PolicyNumber>FIR 0106358-03</PolicyNumber>
              <InsuredName>NORMAN ASDAS CHUNG</InsuredName>
              <MailingAddress>
                <Street1>21600 BELSHIRE AVE # 1</Street1>
                <City>HAWAIIAN GDNS</City>
                <State>CA</State>
                <ZipCode>90716</ZipCode>
                <Country>US</Country>
              </MailingAddress>
              <HomePhone>
                <PhoneNumber />
              </HomePhone>
              <EffectiveDate>2018-03-20</EffectiveDate>
              <Coverage>480111</Coverage>
            </Policy>
            <Property>
              <LegalAddress>
                <Street1>9302 GRINDLAY ST</Street1>
                <City>CYPRESS</City>
                <State>CA</State>
                <ZipCode>90630</ZipCode>
              </LegalAddress>
              <YearBuilt>1969</YearBuilt>
              <NumberOfFamilies>1</NumberOfFamilies>
            </Property>
            <Agent>
              <Id>0000507</Id>
              <Name>Abram Interstate Insurance Services</Name>
              <Phone>
                <PhoneNumber>9167807000</PhoneNumber>
              </Phone>
              <Fax>9167807000</Fax>
              <Email>service@abraminterstate.com</Email>
              <Address>
                <Street1>2211 PLAZA DR. #100</Street1>
                <City>ROCKLIN</City>
                <State>CA</State>
                <ZipCode>95765</ZipCode>
              </Address>
            </Agent>
            <SecondaryAgent>
            <Id>080367-000</Id>
            <Name>ALEX ZHONG INSURANCE SERVICES</Name>
            <Phone>
              <PhoneNumber>6262894886</PhoneNumber>
            </Phone>
            <Fax>6265513148</Fax>
            <Email>ALEXZHONGINSURANCESERVICES@YAHOO.COM</Email>
            <Address>
              <Street1>2330 W. MAIN STREET</Street1>
              <City>ALHAMBRA</City>
              <State>CA</State>
              <ZipCode>91801</ZipCode>
            </Address>
          </SecondaryAgent>
          <Supplements>
            <Roof>N</Roof>
            <Brush>N</Brush>
            <Earthquake>N</Earthquake>
            <Sinkhole>N</Sinkhole>
            <EHP>N</EHP>
            <WBS>N</WBS>
            <Mold>N</Mold>
            <Hurricane>N</Hurricane>
            <FireProtection>N</FireProtection>
            <InteriorConditions>N</InteriorConditions>
            <UnprotectedDwelling>N</UnprotectedDwelling>
            <WaterIntrusion>N</WaterIntrusion>
          </Supplements>
          </Data>]]>
        </Data>
      </PolicyRequest>
    </Body>
</Envelope>`)
    });
  }

  confirmPushPolicy() {

    this.xmlStringValue = this.policyXmlForm.value.policyXml;

    Utils.blockUI();
    this.policyService.PostInpsectionOrderFromPolicyXML(this.xmlStringValue)
      .subscribe(res => {
        this.router.navigate(["/order-management"]);
      },
      err => {
        Utils.unblockUI();
        Utils.showGenericHttpErrorResponse(err);
      });
  }
}
