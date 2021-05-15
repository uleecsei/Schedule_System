import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LogoComponent } from './components/logo/logo.component';
import { MaterialModule } from '../material/material.module';
import { TreeComponent } from './components/tree/tree.component';



@NgModule({
  declarations: [LogoComponent, TreeComponent],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [MaterialModule, LogoComponent, TreeComponent]
})
export class SharedModule { }
