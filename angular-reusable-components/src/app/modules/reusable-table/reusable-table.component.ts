import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

interface TableColumn {
  header: string;
  field: string;
}

@Component({
  selector: 'app-reusable-table',
  templateUrl: './reusable-table.component.html',
  styleUrls: ['./reusable-table.component.scss'],
  standalone: true,
  imports: [CommonModule],
})
export class ReusableTableComponent {
  @Input() data: any[] = []; // Data to display in the table
  @Input() columns: TableColumn[] = []; // Table column definitions
}
