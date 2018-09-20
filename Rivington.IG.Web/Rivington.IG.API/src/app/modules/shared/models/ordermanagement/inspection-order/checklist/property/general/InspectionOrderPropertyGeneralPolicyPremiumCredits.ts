import { PolicyPremiumCredit } from "./policy-premium-credit";

export class InspectionOrderPropertyGeneralPolicyPremiumCredits {
    policyPremiumCreditId?: string;
    /*[ForeignKey(nameof(PolicyPremiumCreditId))]*/
    policyPremiumCredit?: PolicyPremiumCredit;
    public constructor(init?:Partial<InspectionOrderPropertyGeneralPolicyPremiumCredits>) {
        Object.assign(this, init);
    }
}