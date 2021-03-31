import {  OnInit } from '@angular/core';
import { NgModule, Component, enableProdMode, ChangeDetectionStrategy } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { HttpClient, HttpClientModule, HttpHeaders, HttpParams } from '@angular/common/http';

import { DxDataGridModule, DxSelectBoxModule, DxButtonModule } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import { formatDate } from 'devextreme/localization';
import { Observable } from 'rxjs/internal/Observable';

if(!/localhost/.test(document.location.host)) {
    enableProdMode();
}


var URL = "https://localhost:44398";
@Component({
  selector: 'app-detallefactura',
  templateUrl: './detallefactura.component.html',
  styleUrls: ['./detallefactura.component.scss']
})
export class DetallefacturaComponent {
  dataSource: any;
  productsData: any;
  shippersData: any;
  refreshModes: string[];
  refreshMode: string;
  requests: string[] = [];

  constructor(private http: HttpClient) {
      this.refreshMode = "reshape";
      this.refreshModes = ["full", "reshape", "repaint"];

      this.dataSource = new CustomStore({
          key: "pk_id_detallefactura",
          load: () => this.sendRequest(URL + "/api/detalle"),

          insert: (values) => this.sendRequest(URL + "/api/detalle", "POST", {
              values: JSON.stringify(values)
          }),
          update: (key, values) => this.sendRequest(URL + "/api/detalle", "PUT", {
              key: key,
              values: JSON.stringify(values)
          }),
          remove: (key) => this.sendRequest(URL + "/api/detalle", "DELETE", {
              key: key
          })
      });

    this.productsData = new CustomStore({
          key: "pk_id_producto",
          load: () => this.sendRequest(URL + "/api/productos")
      });


              

     /* this.productsData = {
          paginate: true,
          store: new CustomStore({
              key: "pk_id_producto",
              loadMode: "raw",ad: () => this.sendRequest(URL + "/api/productos")
          })
      };*/

      /*this.shippersData = new CustomStore({
          key: "pk_id_categoria",
          loadMode: "raw",
          load: () => this.sendRequest(URL + "/api/categoriaProductos")
      });*/
  }
  ngOnInit(): void {
   
  }


  sendRequest(url: string, method: string = "GET", data: any = {}): any {
    this.logRequest(method, url, data);

    let httpParams = new HttpParams({ fromObject: data });
    let httpOptions = { withCredentials: true, body: httpParams };
    let result:any;



    
    switch(method) {
        case "GET":
            result = this.http.get(url, httpOptions);
            break;
        case "PUT":
            result = this.http.put(url, httpParams, httpOptions);
            break;
        case "POST":
            result = this.http.post(url, httpParams, httpOptions);
            break;
        case "DELETE":
            result = this.http.delete(url, httpOptions);
            break;
    }


   
    return result
        .toPromise()
        .then((data: any) => {
            console.log(data.items);
            return method === "GET" ? {data} : data;
            
        })
        .catch((e: { error: { Message: any; }; }) => {
            throw e && e.error && e.error.Message;
        });
}

  logRequest(method: string, url: string, data?: any): void {
      var args = Object.keys(data || {}).map(function(key) {
          return key ;
      }).join(" ");

      var time = formatDate(new Date(), "HH:mm:ss");

      this.requests.unshift([time, method, url.slice(URL.length), args].join(" "))
  }

  clearRequests() {
      this.requests = [];
  }

 
}
