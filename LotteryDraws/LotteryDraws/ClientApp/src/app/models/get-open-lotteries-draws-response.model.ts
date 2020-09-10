import { OpenLotteriesDraw } from './open-lotteries-draw.model';
import { TattsSvcErrorInfo } from './tatts-svc-error-info.model';

export class GetOpenLotteriesDrawsResponse {
    openLotteriesDraws: OpenLotteriesDraw[];
    errorInfo: TattsSvcErrorInfo;
    success: boolean;
}
