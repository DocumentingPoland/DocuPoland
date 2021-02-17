import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Docu Poland';
  submission: any;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getSubmissions();
  }

  getSubmissions() {
    this.http.get("http://localhost:5000/api/submissions").subscribe(response => {
      this.submission = response;
    }, error => {
      console.log(error);
    })
  }
}
