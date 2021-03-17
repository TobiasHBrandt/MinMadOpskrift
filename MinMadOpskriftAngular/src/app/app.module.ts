import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ForsideComponent } from './forside/forside.component';
import { OpretBrugerComponent } from './opret-bruger/opret-bruger.component';
import { OpretOpskriftComponent } from './opret-opskrift/opret-opskrift.component';

@NgModule({
  declarations: [
    AppComponent,
    ForsideComponent,
    OpretBrugerComponent,
    OpretOpskriftComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
