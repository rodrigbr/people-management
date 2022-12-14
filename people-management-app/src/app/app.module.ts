import { NgModule, LOCALE_ID } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule, DatePipe } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxMaskModule } from 'ngx-mask';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatMenuModule } from '@angular/material/menu';
import { RouterModule } from '@angular/router';
import { PageUserComponent } from './pages/user/page-user.component';
import { NavComponent } from './pages/nav/nav.component';
import { UserComponent } from './components/user/user.component';
import { MatTableModule } from '@angular/material/table';
import { UserResolver } from './components/user/guards/user.resolver';
import { HttpClientModule } from '@angular/common/http';
import { CEPPipe } from './pipes/cep.pipe';
import { UserModalComponent } from './components/user/modals/user-modal/user-modal.component';
import { UserSchoolRecordModalComponent } from './components/user/modals/user-school-record-modal/user-school-record-modal.component';
import { UserSchoolingModalComponent } from './components/user/modals/user-schooling-modal/user-schooling-modal.component';
import { ValidationsFormService } from './components/user/services/validations-form.service';
import { CalendarModule } from 'primeng/calendar';
import localePt from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatNativeDateModule} from '@angular/material/core';
import {MatPaginatorModule} from '@angular/material/paginator';

registerLocaleData(localePt);

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PageUserComponent,
    NavComponent,
    UserComponent,
    CEPPipe,
    UserModalComponent,
    UserSchoolRecordModalComponent,
    UserSchoolingModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatToolbarModule,
    CalendarModule,
    CommonModule,
    NgbModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatIconModule,
    MatFormFieldModule,
    MatMenuModule,
    RouterModule,
    MatTableModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatPaginatorModule,
    HttpClientModule,
    NgxMaskModule.forRoot({
      dropSpecialCharacters: true, // ao salvar, n??o vai manter a mascara
    }),
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'pt-BR' },
    UserResolver,
    DatePipe,
    ValidationsFormService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
