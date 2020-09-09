import { LotteriesProduct } from './lotteries-product.model';
import { DrawTypes } from './draw-types.model';

export class OpenLotteriesDraw {
    productId: LotteriesProduct;
    drawNumber: number;
    drawDisplayName: string;
    drawDate: Date;
    drawLogoUrl: string;
    drawType: DrawTypes;
    div1Amount: number;
    isDiv1Estimated: boolean;
    isDiv1Unknown: boolean;
    drawCloseDateTimeUTC: Date;
    drawEndSellDateTimeUTC: Date;
    drawCountDownTimerSeconds: number;
}
