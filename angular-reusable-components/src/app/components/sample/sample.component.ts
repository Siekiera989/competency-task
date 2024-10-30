import { Component } from '@angular/core';
import { ReusableTableComponent } from '../../modules/reusable-table/reusable-table.component';
import { StandardizedComponent } from '../../modules/standardized-component/standardized-component.component';

@Component({
  selector: 'app-sample',
  templateUrl: './sample.component.html',
  styleUrls: ['./sample.component.scss'],
  standalone: true,
  imports: [ReusableTableComponent, StandardizedComponent],
})
export class SampleComponent {
  // Sample data to display in the table
  tableData = [
    { name: 'John Doe', age: 30, email: 'john@example.com' },
    { name: 'Jane Smith', age: 25, email: 'jane@example.com' },
    { name: 'Alice Johnson', age: 28, email: 'alice@example.com' },
  ];

  // Column definitions for the table
  columns = [
    { header: 'Name', field: 'name' },
    { header: 'Age', field: 'age' },
    { header: 'Email', field: 'email' },
  ];
}
