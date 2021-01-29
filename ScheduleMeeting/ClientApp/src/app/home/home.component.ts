import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatSelect } from '@angular/material/select';
import { Router, ActivatedRoute } from '@angular/router';
import { Company } from '../models/company.model';
import { Country } from '../models/country.model';
import { User } from '../models/user.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

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

  countryMultiFilterCtrl: FormControl = new FormControl();


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
        this.country_list = result.country_list;
        this.filtered_country_list = this.country_list.slice();
      }
    });
  }
}
