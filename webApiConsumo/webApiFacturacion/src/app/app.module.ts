import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { SideNavOuterToolbarModule, SideNavInnerToolbarModule, SingleCardModule } from './layouts';
import { FooterModule, ResetPasswordFormModule, CreateAccountFormModule, ChangePasswordFormModule, LoginFormModule } from './shared/components';
import { AuthService, ScreenService, AppInfoService } from './shared/services';
import { UnauthenticatedContentModule } from './unauthenticated-content';
import { AppRoutingModule } from './app-routing.module';
import { DetallefacturaComponent } from './shared/components/detallefactura/detallefactura.component';
import { DxButtonModule, DxDataGridModule, DxSelectBoxModule } from 'devextreme-angular';
import { HttpClientModule } from '@angular/common/http';
import { FacturaComponent } from './pages/factura/factura.component';
import { CategoriasComponent } from './pages/categorias/categorias.component';
import { TiposComponent } from './pages/tipos/tipos.component';
import { ClientesComponent } from './pages/clientes/clientes.component';

@NgModule({
  declarations: [
    AppComponent,
    DetallefacturaComponent,
    FacturaComponent,
    CategoriasComponent,
    TiposComponent,
    ClientesComponent
  ],
  imports: [
    BrowserModule,
    SideNavOuterToolbarModule,
    SideNavInnerToolbarModule,
    SingleCardModule,
    FooterModule,
    ResetPasswordFormModule,
    CreateAccountFormModule,
    ChangePasswordFormModule,
    LoginFormModule,
    UnauthenticatedContentModule,
    AppRoutingModule,
    BrowserModule,
    DxDataGridModule,
    DxSelectBoxModule,
    DxButtonModule,
    HttpClientModule
  ],
  providers: [AuthService, ScreenService, AppInfoService],
  bootstrap: [AppComponent]
  
})
export class AppModule { }
