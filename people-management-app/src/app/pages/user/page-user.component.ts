import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserRead } from 'src/app/components/user/models/user-read.model';
import { SubscriptionCancel } from 'src/app/subsctiption-cancel';

@Component({
  selector: 'app-page-user',
  templateUrl: './page-user.component.html',
  styleUrls: ['./page-user.component.scss']
})
export class PageUserComponent extends SubscriptionCancel implements OnInit {

  public users: UserRead[] = [];

  constructor(private activatedRoute: ActivatedRoute) {
    super();
  }

  ngOnInit() {
    this.activatedRoute.data.subscribe((response) => {
      this.users = response.userList;
    });
  }
}
