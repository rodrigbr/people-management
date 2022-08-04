import { Injectable } from '@angular/core';
import { Resolve } from "@angular/router";
import { Observable } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { SubscriptionCancel } from 'src/app/subsctiption-cancel';
import { UserQuery } from '../models/user-query.model';
import { UserRead } from '../models/user-read.model';
import { UserService } from '../services/user.service';

@Injectable()
export class UserResolver extends SubscriptionCancel implements Resolve<UserRead[]> {
    filter = new UserQuery();
    constructor(private userService: UserService) {
        super();
    }

    resolve(): Observable<UserRead[]> {
        this.filter.pageSize = 10;
        this.filter.pageIndex = 1;
        return this.userService.getList(this.filter).pipe(takeUntil(this.destroy$));
    }
}