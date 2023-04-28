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
import { DashboardComponent } from './core/dashboard/dashboard.component';
import { UserInformationComponent } from './core/dashboard/user-information/user-information.component';
import { DegreeProgressComponent } from './core/dashboard/degree-progress/degree-progress.component';
import { DashboardProgressBarComponent } from './core/dashboard/dashboard-progress-bar/dashboard-progress-bar.component';
import { SemesterplannerOverviewComponent } from './core/dashboard/semesterplanner-overview/semesterplanner-overview.component';
import { SemesterplannerContentComponent } from './core/dashboard/semesterplanner-content/semesterplanner-content.component';
import { SemesterplannerDeleteDialogComponent } from './core/semesterplanner/semesterplanner-delete-dialog/semesterplanner-delete-dialog.component';
import { InformationsModule } from './shared/components/informations/informations.module';
import { SemesterPlannerFormDialogComponent } from './core/semesterplanner/semesterplanner-form-dialog/semesterplanner-form-dialog.component';
import { ModulListComponent } from './core/modul/modul-list/modul-list-component';
import { DegreeListComponent } from './core/degree/degree-list/degree-list-component';
import { ModulDetailDialogComponent } from './core/modul/modul-detail-dialog/modul-detail-dialog.component';
import { SemesterplannermodulFormDialogComponent } from './core/semesterplannermodul/semesterplannermodul-form-dialog/semesterplannermodul-form-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    SemesterListComponent,
    NavigationBarComponent,
    SigninComponent,
    FooterComponent,
    DashboardComponent,
    UserInformationComponent,
    DegreeProgressComponent,
    DashboardProgressBarComponent,
    SemesterplannerOverviewComponent,
    SemesterplannerContentComponent,
    ModulDetailDialogComponent,
    SemesterplannerDeleteDialogComponent,
    SemesterPlannerFormDialogComponent,
    ModulListComponent,
    DegreeListComponent,
    SemesterplannermodulFormDialogComponent
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
    InformationsModule
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
