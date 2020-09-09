import { LotteriesCompany } from './lotteries-company.model';
import { LotteriesProduct } from './lotteries-product.model';

export class GetOpenLotteriesDrawsRequest {
    CompanyId: LotteriesCompany;
    MaxDrawCount: number;
    OptionalProductFilter: LotteriesProduct[];
}
