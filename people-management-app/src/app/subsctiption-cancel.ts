import { Component, OnDestroy } from '@angular/core';
import { ReplaySubject } from 'rxjs';

@Component({
  template: ''
})
export abstract class SubscriptionCancel implements OnDestroy {

  protected destroy$: ReplaySubject<boolean> = new ReplaySubject<boolean>();

  public ngOnDestroy(): void {
      this.destroy$.next(true);
      this.destroy$.complete();
      this.destroy$.unsubscribe();
  }
}
