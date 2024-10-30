import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StandardizedComponent } from '../standardized-component/standardized-component.component';
import { ReusableTableComponent } from '../reusable-table/reusable-table.component';

@NgModule({
  declarations: [],
  imports: [CommonModule, StandardizedComponent, ReusableTableComponent],
  exports: [StandardizedComponent, ReusableTableComponent],
})
export class SharedStylesModule {}
