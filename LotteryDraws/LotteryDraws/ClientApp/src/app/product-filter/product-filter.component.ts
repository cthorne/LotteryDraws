import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { LotteriesProduct } from '../models/lotteries-product.model';

@Component({
  selector: 'app-product-filter',
  templateUrl: './product-filter.component.html',
  styleUrls: ['./product-filter.component.css']
})
export class ProductFilterComponent implements OnInit {
  @Input() selectedProduct: number;
  @Output() productChangedEvent = new EventEmitter<Array<number>>();
  public LotteriesProducts;
  constructor() { 
    this.LotteriesProducts = Object.values(LotteriesProduct).filter(value => typeof value === 'string') as string[];
  }

  ngOnInit() {
  }

  onValueChanged(value: Array<number>) {
    this.productChangedEvent.emit(value)
  }

}
