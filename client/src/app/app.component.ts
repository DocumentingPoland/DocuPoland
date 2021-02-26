import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { error } from 'protractor';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Docu Poland';
  submission: any;
  user: any;

  constructor(private http: HttpClient, private accountService: AccountService) {}

  ngOnInit() {
    this.setCurrentUser();
    this.getSubmissions();

  }

  getSubmissions() {
    this.http.get("http://localhost:5000/api/submissions").subscribe(response => {
      this.submission = response;
    }, error => {
      console.log(error);
    })
  }




  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user')!);
    this.accountService.setCurrentUser(user);

  }
}

