import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerMode = false;

  constructor() { }

  ngOnInit(): void {
  }

  // reg toggle
  registerToggle() {
    this.registerMode = ! this.registerMode;
  }

  // cancel register mode
  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }

}
