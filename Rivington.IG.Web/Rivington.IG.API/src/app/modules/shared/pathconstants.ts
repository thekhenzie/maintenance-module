export const PathConstants = {
    Root: {
        Forbidden: "forbidden"
    },
    Account: {
        Login: "account/login",
        InsuredLogin: "account/login/insured",
        InsuredReportLogin: "account/login/insured/report"
    },
    Dashboard: {
        Index: "dashboard"
    },
    OrderManagement: {
        Index: "order-management",
        InspectionOrder: {
            Create: {
                Info: "/order-management/inspection-order/create/info",
                GetPolicy: "/order-management/inspection-order/create/get-policy"
            },
            InsuredMitigation: "/order-management/inspection-order/mitigation/insured",
            InsuredReport: "/order-management/inspection-order/report/insured"
        }
    },
    UserManagement: {
        Index: "user-management"
    },
    Report: {
        Insured: "reporting/order-management/inspection-order/insured"
    }
};