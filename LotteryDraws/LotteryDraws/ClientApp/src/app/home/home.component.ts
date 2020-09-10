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
  selectedCompany: number = 0;
  maxDrawCount: number = 100;
  error: boolean = false;
  public drawData: OpenLotteriesDraw[];
  http: HttpClient;
  baseUrl: string;
  errorText: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
   this.http = http;
   this.baseUrl = baseUrl;    
  }

  updateValues(value: Array<number>) {
    this.selectedProduct = value;
    this.repopulate();
  }

  updateCompanyValues(value: number) {
    this.selectedCompany = value;
    this.repopulate();
  }

  repopulate() {
    let request = new GetOpenLotteriesDrawsRequest();
    request.CompanyId = this.selectedCompany;
    request.MaxDrawCount = this.maxDrawCount;
    request.OptionalProductFilter = this.selectedProduct;
    this.http.post<GetOpenLotteriesDrawsResponse>(this.baseUrl + 'OpenLotteriesDraws/Post', request).subscribe(result => {
      if (!result.success)
      {
        this.genericErrorHandling(result);
      } else {
      this.error = false;
      this.drawData = result.openLotteriesDraws;
      }
    }, error => this.errorHandling(error));
  }

  resetInput() {
    this.selectedCompany = 0;
    this.selectedProduct = null;

    this.repopulate();
  }

  genericErrorHandling(result) {
    this.error = true;
    this.drawData = null;
    console.error(result);
    if (this.selectedCompany)
    {
    this.errorText = 'An error has occurred. Please reload the page or view the console for more info.';
    } else {
      this.errorText = 'Please choose a company, as it is required';
    }
  }
  errorHandling(error) {
    console.error(error);
    this.error = true;
    this.drawData = null;
    this.errorText = 'An error has occurred in the UI. Please reload the page or view the console for more info.';
  }
}
