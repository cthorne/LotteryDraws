import { LotteriesCompany } from './lotteries-company.model';

export class GetOpenLotteriesDrawsRequest {
    CompanyId: LotteriesCompany;
    MaxDrawCount: number;
    OptionalProductFilter: string[];
}
