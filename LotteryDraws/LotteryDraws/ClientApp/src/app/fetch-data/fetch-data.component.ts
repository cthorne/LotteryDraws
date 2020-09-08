import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public test: OpenLotteriesDraw[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<GetOpenLotteriesDrawsResponse>(baseUrl + 'weatherforecast').subscribe(result => {
      this.test = result.openLotteriesDraws;
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}


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
  ProductId: LotteriesProduct,
  DrawNumber: number,
  DrawDisplayName: string,
  DrawDate: Date,
  DrawLogoUrl: string,
  DrawType: DrawTypes,
  Div1Amount: number,
  IsDiv1Estimated: boolean,
  IsDiv1Unknown: boolean,
  DrawCloseDateTimeUTC: Date,
  DrawEndSellDateTimeUTC: Date,
  DrawCountDownTimerSeconds: number
}

interface TattsSvcErrorInfo {
  SystemId: number,
  ErrorNo: number,
  DisplayMessage: string,
  ContactSupport: boolean,
  SupportErrorReference: string
}

interface GetOpenLotteriesDrawsResponse {
  openLotteriesDraws: OpenLotteriesDraw[],
  errorInfo: TattsSvcErrorInfo,
  success: boolean
}