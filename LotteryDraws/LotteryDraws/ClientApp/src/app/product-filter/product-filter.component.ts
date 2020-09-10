import { Component, OnInit } from '@angular/core';
import { LotteriesProduct } from '../models/lotteries-product.model';
import { stringify } from 'querystring';

@Component({
  selector: 'app-product-filter',
  templateUrl: './product-filter.component.html',
  styleUrls: ['./product-filter.component.css']
})
export class ProductFilterComponent implements OnInit {
  selectedProduct: number;
  public LotteriesProducts;
  constructor() { 
    this.LotteriesProducts = Object.values(LotteriesProduct).filter(value => typeof value === 'string') as string[];
    this.selectedProduct = 0; // None
  }

  ngOnInit() {
  }

}
