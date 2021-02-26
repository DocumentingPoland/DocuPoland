import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerMode = false;
  users: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getUsers();
  }

  registerToggle() {
    this.registerMode = ! this.registerMode;
  }

  getUsers() {
    this.http.get("http://localhost:5000/api/user").subscribe(response => {
      this.users = response;
    }, error => {
      console.log(error);
    })
  }

}
