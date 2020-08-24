import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {
  AccordionAnchorDirective,
  AccordionDirective,
  AccordionLinkDirective
} from './accordion';
import { ToggleFullScreenDirective } from './fullscreen/toggle-fullscreen.directive';
import { CardRefreshDirective } from './card/card-refresh.directive';
import { CardToggleDirective } from './card/card-toggle.directive';
import { SpinnerComponent } from './spinner/spinner.component';
import { CardComponent } from './card/card.component';
import { ModalAnimationComponent } from './modal-animation/modal-animation.component';
import { ModalBasicComponent } from './modal-basic/modal-basic.component';
import { DataFilterPipe } from './element/data-filter.pipe';
import { MenuItems } from './menu-items/menu-items';
import { ParentRemoveDirective } from './element/parent-remove.directive';
import {
  PERFECT_SCROLLBAR_CONFIG,
  PerfectScrollbarConfigInterface,
  PerfectScrollbarModule
} from 'ngx-perfect-scrollbar';
import { ClickOutsideModule } from 'ng-click-outside';
import { NgbdSortableHeaderDirective } from './sortable-header/sortable.directive';
import { ToastService } from './toaster/toaster.service';
import { ToastyModule } from 'ng2-toasty';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true
};

@NgModule({
  imports: [
    CommonModule,
    PerfectScrollbarModule,
    ClickOutsideModule,
    NgbModule,
    ToastyModule.forRoot()
  ],
  declarations: [
    AccordionAnchorDirective,
    AccordionLinkDirective,
    AccordionDirective,
    ToggleFullScreenDirective,
    CardRefreshDirective,
    CardToggleDirective,
    SpinnerComponent,
    CardComponent,
    ModalAnimationComponent,
    ModalBasicComponent,
    DataFilterPipe,
    ParentRemoveDirective,
    NgbdSortableHeaderDirective
  ],
  exports: [
    AccordionAnchorDirective,
    AccordionLinkDirective,
    AccordionDirective,
    ToggleFullScreenDirective,
    CardRefreshDirective,
    CardToggleDirective,
    SpinnerComponent,
    CardComponent,
    ModalAnimationComponent,
    ModalBasicComponent,
    DataFilterPipe,
    ParentRemoveDirective,
    NgbModule,
    PerfectScrollbarModule,
    ClickOutsideModule,
    NgbdSortableHeaderDirective
  ],
  providers: [
    MenuItems,
    {
      provide: PERFECT_SCROLLBAR_CONFIG,
      useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
    },
    ToastService
  ],
  schemas: [NO_ERRORS_SCHEMA]
})
export class SharedModule {}
