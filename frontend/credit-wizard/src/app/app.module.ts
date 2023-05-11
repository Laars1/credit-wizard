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
import { ToastrModule } from 'ngx-toastr';
import { FooterComponent } from './shared/components/footer/footer.component';
import { InformationsModule } from './shared/components/informations/informations.module';
import { DashboardModule } from './core/dashboard/dashboard.module';
import { DegreeModule } from './core/degree/degree.module';
import { ModulModule } from './core/modul/modul.module';
import { SemesterplannerModule } from './core/semesterplanner/semesterplanner.module';
import { SemesterplannermodulModule } from './core/semesterplannermodul/semesterplannermodul.module';
import { SemesterModule } from './core/semester/semester.module';

@NgModule({
  declarations: [
    AppComponent,
    NavigationBarComponent,
    SigninComponent,
    FooterComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    MaterialModule,
    DashboardModule,
    DegreeModule,
    InformationsModule,
    ModulModule,
    SemesterplannerModule,
    SemesterplannermodulModule,
    SemesterModule
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
