import { ErrorInterceptor } from './shared/security/error.interceptor';
import { SigninComponent } from './core/sign-in/sign-in.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavigationBarComponent } from './shared/components/navigation-bar/navigation-bar.component';
import { MaterialModule } from './material.module';
import { AuthInterceptor } from './shared/security/auth.interceptor';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SemesterListComponent } from './core/semester/semester-list/semester-list.component';
import { ToastrModule } from 'ngx-toastr';
import { FooterComponent } from './shared/components/footer/footer.component';
import { ModulesListComponent } from './core/modules/modules-list/modules-list-component';

@NgModule({
  declarations: [
    AppComponent,
    SemesterListComponent,
    NavigationBarComponent,
    SigninComponent,
    FooterComponent,
    ModulesListComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    HttpClientModule,
    AppRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  exports: [],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [
    AppComponent,
  ],
})
export class AppModule {}
