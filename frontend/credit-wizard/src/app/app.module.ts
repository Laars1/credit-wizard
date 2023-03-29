import { SigninComponent } from './core/sign-in/sign-in.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavigationBarComponent } from './shared/components/navigation-bar/navigation-bar.component';
import { MaterialModule } from './material.module';
import { AuthInterceptor } from './shared/auth/auth.interceptor';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SemesterListComponent } from './core/semester/semester-list/semester-list.component';


@NgModule({
  declarations: [AppComponent, SemesterListComponent, NavigationBarComponent, SigninComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    NgbModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports: [],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
