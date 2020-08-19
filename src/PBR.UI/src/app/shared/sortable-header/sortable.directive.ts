import {
  Directive,
  EventEmitter,
  Input,
  Output,
  HostListener,
  HostBinding,
} from '@angular/core';
import { SortDirection, SortColumn } from '../appsettings';


const rotate: { [key: string]: SortDirection } = {
  asc: 'desc',
  desc: '',
  '': 'asc',
};

export interface SortEvent {
  column: SortColumn;
  direction: SortDirection;
}

@Directive({
  selector: 'th[sortable]',
})
export class NgbdSortableHeaderDirective {
  @Input() sortable: SortColumn = '';
  @Input() direction: SortDirection = '';
  @Output() sort = new EventEmitter<SortEvent>();

  @HostBinding('class.asc') get asc() {
    return this.direction === 'asc';
  }
  @HostBinding('class.desc') get desc() {
    return this.direction === 'desc';
  }
  @HostListener('click') rotate() {
    {
      this.direction = rotate[this.direction];
      this.sort.emit({ column: this.sortable, direction: this.direction });
    }
  }
}
