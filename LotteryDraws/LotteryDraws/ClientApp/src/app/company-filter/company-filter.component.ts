import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { LotteriesCompany } from '../models/lotteries-company.model';

@Component({
  selector: 'app-company-filter',
  templateUrl: './company-filter.component.html',
  styleUrls: ['./company-filter.component.css']
})
export class CompanyFilterComponent implements OnInit {
  @Output() companyChangedEvent = new EventEmitter<number>();
  @Input() selectedCompany: number;

  public LotteriesCompanies;
  constructor() { 
    this.LotteriesCompanies = Object.values(LotteriesCompany).filter(value => typeof value === 'string') as string[];
    this.selectedCompany = 0; // None
  }

  ngOnInit() {
  }

  onValueChanged(value: number) {
    this.companyChangedEvent.emit(value)
  }
}
