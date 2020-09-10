import { Component, OnInit } from '@angular/core';
import { LotteriesCompany } from '../models/lotteries-company.model';

@Component({
  selector: 'app-company-filter',
  templateUrl: './company-filter.component.html',
  styleUrls: ['./company-filter.component.css']
})
export class CompanyFilterComponent implements OnInit {

  selectedCompany: string;
  public LotteriesCompanies;
  constructor() { 
    this.LotteriesCompanies = Object.values(LotteriesCompany).filter(value => typeof value === 'string') as string[];
    this.selectedCompany = 'None';
  }

  ngOnInit() {
  }

}
