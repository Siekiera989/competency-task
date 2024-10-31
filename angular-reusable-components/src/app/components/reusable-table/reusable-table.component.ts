import { CommonModule } from '@angular/common';
import { Component, Input, Signal, signal } from '@angular/core';

export interface TableColumn {
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
  // Signals to store data and columns
  private _data = signal<Array<Record<string, any>>>([]);
  private _columns = signal<TableColumn[]>([]);

  // Computed properties to expose the values as observables
  data: Signal<Array<Record<string, any>>> = this._data.asReadonly();
  columns: Signal<TableColumn[]> = this._columns.asReadonly();

  // Setters to update signals based on parent inputs
  @Input() set dataInput(value: Array<Record<string, any>>) {
    this._data.set(value);
  }

  @Input() set columnsInput(value: TableColumn[]) {
    this._columns.set(value);
  }
}
