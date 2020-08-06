import {Injectable, PipeTransform} from '@angular/core';
import {BehaviorSubject, Observable, of, Subject} from 'rxjs';

import {Account} from './iaccount';
import {ACCOUNTS} from './accounts';
import {DecimalPipe} from '@angular/common';
import {debounceTime, delay, switchMap, tap} from 'rxjs/operators';
import {SortColumn, SortDirection} from './sortable.directive';

interface SearchResult {
  accounts: Account[];
  total: number;
}

interface State {
  page: number;
  pageSize: number;
  searchTerm: string;
  sortColumn: SortColumn;
  sortDirection: SortDirection;
}

const compare = (v1: string | number, v2: string | number) => v1 < v2 ? -1 : v1 > v2 ? 1 : 0;

function sort(accounts: Account[], column: SortColumn, direction: string): Account[] {
  if (direction === '' || column === '') {
    return accounts;
  } else {
    return [...accounts].sort((a, b) => {
      const res = compare(a[column], b[column]);
      return direction === 'asc' ? res : -res;
    });
  }
}

function matches(account: Account, term: string, pipe: PipeTransform) {
  return account.accountName.toLowerCase().includes(term.toLowerCase())
    || account.userName.toLowerCase().includes(term.toLowerCase())
    || pipe.transform(account.clientId).includes(term)
    || account.isActive.toLowerCase().includes(term.toLowerCase())
    || account.lastUpdated.toLowerCase().includes(term.toLowerCase())
}

@Injectable({providedIn: 'root'})
export class AccountService {
  private _loading$ = new BehaviorSubject<boolean>(true);
  private _search$ = new Subject<void>();
  private _accounts$ = new BehaviorSubject<Account[]>([]);
  private _total$ = new BehaviorSubject<number>(0);

  private _state: State = {
    page: 1,
    pageSize: 4,
    searchTerm: '',
    sortColumn: '',
    sortDirection: ''
  };

  constructor(private pipe: DecimalPipe) {
    this._search$.pipe(
      tap(() => this._loading$.next(true)),
      debounceTime(200),
      switchMap(() => this._search()),
      delay(200),
      tap(() => this._loading$.next(false))
    ).subscribe(result => {
      this._accounts$.next(result.accounts);
      this._total$.next(result.total);
    });

    this._search$.next();
  }

  get accounts$() { return this._accounts$.asObservable(); }
  get total$() { return this._total$.asObservable(); }
  get loading$() { return this._loading$.asObservable(); }
  get page() { return this._state.page; }
  get pageSize() { return this._state.pageSize; }
  get searchTerm() { return this._state.searchTerm; }

  set page(page: number) { this._set({page}); }
  set pageSize(pageSize: number) { this._set({pageSize}); }
  set searchTerm(searchTerm: string) { this._set({searchTerm}); }
  set sortColumn(sortColumn: SortColumn) { this._set({sortColumn}); }
  set sortDirection(sortDirection: SortDirection) { this._set({sortDirection}); }

  private _set(patch: Partial<State>) {
    Object.assign(this._state, patch);
    this._search$.next();
  }

  private _search(): Observable<SearchResult> {
    const {sortColumn, sortDirection, pageSize, page, searchTerm} = this._state;

    // 1. sort
    let accounts = sort(ACCOUNTS, sortColumn, sortDirection);

    // 2. filter
    accounts = accounts.filter(account => matches(account, searchTerm, this.pipe));
    const total = accounts.length;

    // 3. paginate
    accounts = accounts.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({accounts, total});
  }
}