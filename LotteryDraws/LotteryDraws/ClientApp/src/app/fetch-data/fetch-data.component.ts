import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DrawTypes } from '../models/draw-types.model';
import { TattsSvcErrorInfo } from '../models/tatts-svc-error-info.model';
import { LotteriesProduct } from '../models/lotteries-product.model';
import { LotteriesCompany } from '../models/lotteries-company.model';
import { OpenLotteriesDraw } from '../models/open-lotteries-draw.model';
import { GetOpenLotteriesDrawsResponse } from '../models/get-open-lotteries-draws-response.model';
import { GetOpenLotteriesDrawsRequest } from '../models/get-open-lotteries-draw-request.model';

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
    /*http.get<GetOpenLotteriesDrawsResponse>(baseUrl + 'weatherforecast/GetAll').subscribe(result => {
      this.test = result.openLotteriesDraws;
    }, error => console.error(error));
    */
    let request = new GetOpenLotteriesDrawsRequest();
    request.CompanyId = LotteriesCompany.NSWLotteries;
    request.MaxDrawCount = 20;
    request.OptionalProductFilter = [LotteriesProduct.SetForLife];

    http.post<GetOpenLotteriesDrawsResponse>(baseUrl + 'weatherforecast/Post', request).subscribe(result => {
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
