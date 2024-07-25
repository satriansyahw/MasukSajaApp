// src/app/app.module.ts
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component'; // Remove this if using standalone components

@NgModule({
    declarations: [
        // AppComponent, // Remove this if using standalone components
    ],
    imports: [
        BrowserModule,
    ],
    providers: [],
    bootstrap: [AppComponent] // Remove this if using standalone components
})
export class AppModule { }
