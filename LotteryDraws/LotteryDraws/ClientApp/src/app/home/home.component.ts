import { Component, Inject } from '@angular/core';
import { ProductFilterComponent} from '../product-filter/product-filter.component';
import { HttpClient } from '@angular/common/http';
import { GetOpenLotteriesDrawsRequest } from '../models/get-open-lotteries-draw-request.model';
import { LotteriesCompany } from '../models/lotteries-company.model';
import { LotteriesProduct } from '../models/lotteries-product.model';
import { GetOpenLotteriesDrawsResponse } from '../models/get-open-lotteries-draws-response.model';
import { OpenLotteriesDraw } from '../models/open-lotteries-draw.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  selectedProduct: Array<number>;
  selectedCompany;
  public test: OpenLotteriesDraw[];
  public test2: OpenLotteriesDraw[];
  http:HttpClient;
  baseUrl: string;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    /*http.get<GetOpenLotteriesDrawsResponse>(baseUrl + 'weatherforecast/GetAll').subscribe(result => {
      this.test = result.openLotteriesDraws;
    }, error => console.error(error));
    */
   this.http = http;
   this.baseUrl = baseUrl;
    let request = new GetOpenLotteriesDrawsRequest();
    request.CompanyId = LotteriesCompany.NSWLotteries;
    request.MaxDrawCount = 20;
    request.OptionalProductFilter = this.selectedProduct;

    http.post<GetOpenLotteriesDrawsResponse>(baseUrl + 'weatherforecast/Post', request).subscribe(result => {
      this.test = result.openLotteriesDraws;
    }, error => console.error(error));
  }
  updateValues(value: Array<number>) {
    this.selectedProduct = value;
    this.recallC();
  }

  updateCompanyValues(value: number) {
    this.selectedCompany = value;
    this.recallC();
  }

  recallC() {
    let request = new GetOpenLotteriesDrawsRequest();
    request.CompanyId = this.selectedCompany;
    request.MaxDrawCount = 20;
    request.OptionalProductFilter = this.selectedProduct;
    this.http.post<GetOpenLotteriesDrawsResponse>(this.baseUrl + 'weatherforecast/Post2', request).subscribe(result => {
      this.test = result.openLotteriesDraws;
    }, error => console.error(error));
  }
}
