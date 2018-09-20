import { Table } from "primeng/table";

export const PrimeTableUtils = {
    setDefaults(pTable: Table) {
        if (!!!pTable) return;

        pTable.sortMode = "multiple";

        pTable.lazy = true;
      
        pTable.paginator = true;
        pTable.rows = 10;
        pTable.pageLinks = 5;
        pTable.rowsPerPageOptions = [10,20,50,100];
      
        pTable.responsive = true;
        pTable.loadingIcon = "fa-spinner";
    }
};