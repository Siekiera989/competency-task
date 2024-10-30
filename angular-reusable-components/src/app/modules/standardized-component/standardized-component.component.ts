import { CommonModule } from '@angular/common';
import { Component, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-standardized-component',
  template: `
    <div class="shared-component-content">
      <p>This component uses styles from SharedStylesModule.</p>
    </div>
  `,
  styleUrls: ['./standardized-component.component.scss'],
  encapsulation: ViewEncapsulation.Emulated,
  standalone: true,
  imports: [CommonModule],
})
export class StandardizedComponent {}
