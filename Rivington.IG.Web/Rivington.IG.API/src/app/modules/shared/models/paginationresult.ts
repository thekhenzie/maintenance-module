export interface IPaginationResult<T> {
    results: Array<T>;
    pageNo: number;
    recordPage: number;
    totalRecords: number;
}