import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, ElementRef, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatSelect } from '@angular/material/select';
import { Router, ActivatedRoute } from '@angular/router';
import { Company } from '../models/company.model';
import { Country } from '../models/country.model';
import { User } from '../models/user.model';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit, AfterViewInit {

  constructor(
    private httpClient: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }






  _baseUrl: string;
  selected_countries: Country[] = [];
  selected_companies: Company[] = [];
  user_list: User[] = [];
  country_list: Country[] = [];
  filtered_country_list: Country[] = [];
  company_list: Company[] = [];
  filtered_company_list: Company[] = [];
  search_company_list: Company[] = [];
  countryMultiFilterCtrl: FormControl = new FormControl();
  companyMultiFilterCtrl: FormControl = new FormControl();
  @ViewChild('countrySelect') countrySelect: MatSelect;
  @ViewChild('companySelect') companySelect: MatSelect;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  displayedColumns: string[] = ['company', 'country', 'city', 'delegate'];
  dataSource = new MatTableDataSource<Company>(this.search_company_list);



  ngOnInit(): void{
    this.getDropDownListItems();
    this.countryMultiFilterCtrl.valueChanges.subscribe((srh_txt: string) => {
      if(srh_txt.length == 0){
        this.filtered_country_list = this.country_list.slice();
        return;
      }
      srh_txt = srh_txt.toUpperCase();
      this.filtered_country_list = [];
      this.filtered_country_list = this.country_list.filter(val => {
        if(val.country_name.toUpperCase().includes(srh_txt) == true){
          return val;
        }
      });
    });



    this.companyMultiFilterCtrl.valueChanges.subscribe((srh_text: string) => {
      if(srh_text.length == 0){
        this.filtered_company_list = this.company_list.slice();
        return;
      }

      srh_text = srh_text.toUpperCase();
      this.filtered_company_list = [];
      this.filtered_company_list = this.company_list.filter(val => {
        if(val.name.toUpperCase().includes(srh_text) == true){
          return val;
        }
      });
    });
  }




  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }


  // openCountrySelect(event_data){
  //   this.show_country_selected_list = false;
  //   console.log(this.show_country_selected_list);
  //   this.selectedCountryCtr.value
  // }


  // closeCountrySelect(event_data){
  //   this.show_country_selected_list = true;
  //   console.log(this.show_country_selected_list);
  // }


  countrySelectOpenChanged(event_data){
    console.log(event_data);
    if(event_data){
      document.getElementById('countrySelect').hidden = true;
    }
    else{
      document.getElementById('countrySelect').hidden = false;
    }
  }




  getDropDownListItems(){
    this.httpClient.get<{
      success: boolean,
      error: boolean,
      error_msg: string,
      country_list: Country[],
      company_list: Company[],
      user_list: User[]
    }>(this._baseUrl + 'api/schedule/GetDropDownList').subscribe(result => {
      if(result.success){
        this.user_list = result.user_list;
        this.company_list = result.company_list;
        this.filtered_company_list = result.company_list.slice();
        this.country_list = result.country_list;
        this.filtered_country_list = this.country_list.slice();
      }
    });
  }




  countrySelectionChanged(event_data){
    //console.log(this.countrySelect.value);
    this.searchCompanies();
  }


  companySelectionChanged(evetn_data){
    this.searchCompanies();
  }


  searchCompanies(){

    this.selected_companies = [];
    this.selected_countries = [];
    if(this.countrySelect.value != undefined){
      this.selected_countries = this.countrySelect.value;
    }
    if(this.companySelect.value != undefined){
      this.selected_companies = this.companySelect.value;
    }


    if(this.selected_companies.length > 0 || this.selected_countries.length > 0){
      let scids:number[] = [];
      let scounids:number[] = [];
      this.selected_companies.forEach(val => {
        scids.push(val.id);
      });
      this.selected_countries.forEach(val => {
        scounids.push(val.id);
      });

      var post_data = {
        company_ids: scids,
        country_ids: scounids
      }

      var pd_str = JSON.stringify(post_data);

      this.httpClient.post<{
        success: boolean,
        error: boolean,
        error_msg: string,
        company_list: Company[]
      }>(this._baseUrl + 'api/schedule/SearchCompanies', {json_data: pd_str}).subscribe(result => {
        console.log(result);
        if(result.success){
          this.search_company_list = result.company_list;
          this.dataSource = new MatTableDataSource<Company>(this.search_company_list);
        }
      });
    }
    else{
      this.search_company_list = [];
      this.dataSource = new MatTableDataSource<Company>(this.search_company_list);
    }



  }




}
