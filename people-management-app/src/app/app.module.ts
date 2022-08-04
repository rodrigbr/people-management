import { NgModule } from '@angular/core';
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

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PageUserComponent,
    NavComponent,
    UserComponent,
    CEPPipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatToolbarModule,
    CommonModule,
    NgbModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatIconModule,
    MatMenuModule,
    RouterModule,
    MatTableModule,
    HttpClientModule,
    NgxMaskModule.forRoot({
      dropSpecialCharacters: true, // ao salvar, não vai manter a mascara
    }),
  ],
  providers: [
    UserResolver,
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
