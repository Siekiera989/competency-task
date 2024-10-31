import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {
  ReusableTableComponent,
  TableColumn,
} from './components/reusable-table/reusable-table.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, ReusableTableComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'angular-reusable-components';

  columns = signal<TableColumn[]>([
    { header: 'ID', field: 'id' },
    { header: 'Name', field: 'name' },
    { header: 'Age', field: 'age' },
  ]);

  data = signal<Array<Record<string, any>>>([
    { id: 1, name: 'John Doe', age: 30 },
    { id: 2, name: 'Jane Smith', age: 25 },
    { id: 3, name: 'Alice Johnson', age: 40 },
  ]);
}
