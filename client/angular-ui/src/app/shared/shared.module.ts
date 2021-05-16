import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LogoComponent } from './components/logo/logo.component';
import { MaterialModule } from '../material/material.module';
import { TreeComponent } from './components/tree/tree.component';
import { ModalComponent } from './components/modal/modal.component';



@NgModule({
  declarations: [LogoComponent, TreeComponent, ModalComponent],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [MaterialModule, LogoComponent, TreeComponent]
})
export class SharedModule { }
