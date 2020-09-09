import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DrawTypes } from '../models/draw-types.model';
import { TattsSvcErrorInfo } from '../models/tatts-svc-error-info.model';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public test: OpenLotteriesDraw[];
  public test2: OpenLotteriesDraw[];
  public selectedProduct;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<GetOpenLotteriesDrawsResponse>(baseUrl + 'weatherforecast/GetAll').subscribe(result => {
      this.test = result.openLotteriesDraws;
    }, error => console.error(error));

    /*http.post<GetOpenLotteriesDrawsResponse>(baseUrl + 'weatherforecast/Get', ).subscribe(result => {
      this.test2 = result.openLotteriesDraws;
    }, error => console.error(error));*/
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

/* 
enum DrawTypes {
  Undefined = "Undefined",
  BaseWeek = "BaseWeek",
  Jackpot = "Jackpot",
  Superdraw = "Superdraw",
  Megadraw = "Megadraw",
  DoubleDivs = "DoubleDivs",
  TripleDivs = "TripleDivs",
  FourTimesDivs = "FourTimesDivs",
  DoubleDivsPlus1 = "DoubleDivsPlus1",
  TripleDivsPlus1 = "TripleDivsPlus1",
  FourTimesDivsPlus1 = "FourTimesDivsPlus1",
  CashCadeNextDiv = "CashCadeNextDiv",
  CashCadeAllDivs = "CashCadeAllDivs"
}
 */
enum LotteriesProduct {
  None = "None",
  TattsLotto = "TattsLotto",
  OzLotto = "OzLotto",
  Powerball = "Powerball",
  Super66 = "Super66",
  Pools = "Pools",
  MonWedLotto = "MonWedLotto",
  LuckyLotteries2 = "LuckyLotteries2",
  LuckyLotteries5 = "LuckyLotteries5",
  LottoStrike = "LottoStrike",
  WedLotto = "WedLotto",
  Keno = "Keno",
  CoinToss = "CoinToss",
  SetForLife = "SetForLife744",
  MultiProduct = "MultiProduct",
  InstantScratchIts = "InstantScratchIts",
  TwoDollarCasket = "TwoDollarCasket",
  BonusDraws = "BonusDraws"
}

enum LotteriesCompany {
  None = "None",
        Tattersalls = "Tattersalls",
        GoldenCasket = "GoldenCasket",
        NSWLotteries = "NSWLotteries",
        NTLotteries = "NTLotteries",
        SALotteries = "SALotteries"
}

interface GetOpenLotteriesDrawsRequest {
  CompanyId: LotteriesCompany,
  MaxDrawCount: number,
  OptionalProductFilter: string[]
}

interface OpenLotteriesDraw {
  productId: LotteriesProduct,
  drawNumber: number,
  drawDisplayName: string,
  drawDate: Date,
  drawLogoUrl: string,
  drawType: DrawTypes,
  div1Amount: number,
  isDiv1Estimated: boolean,
  isDiv1Unknown: boolean,
  drawCloseDateTimeUTC: Date,
  drawEndSellDateTimeUTC: Date,
  drawCountDownTimerSeconds: number
}

interface GetOpenLotteriesDrawsResponse {
  openLotteriesDraws: OpenLotteriesDraw[],
  errorInfo: TattsSvcErrorInfo,
  success: boolean
}