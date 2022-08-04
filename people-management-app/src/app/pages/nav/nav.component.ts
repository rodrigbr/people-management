import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  public isUserPage: boolean = false;

  constructor(
    private router: Router) { }

  ngOnInit() {
    if (this.router.url.indexOf("/users") === -1 ) {
      this.isUserPage = false;
    } else {
      this.isUserPage = true;
    }
  } 
}
