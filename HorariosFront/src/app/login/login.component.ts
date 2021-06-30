import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public invalidLogin: boolean = true;

  constructor(private router: Router, private http: HttpClient) { }

  ngOnInit(): void {
  }

  login(form: NgForm) {
    const credentials = {
      "username": form.value.username,
      "pass": form.value.password
    };

    this.http.post(
      "https://localhost:5001/api/auth/login",
      credentials
    ).subscribe(
      (response: any) => {
        const token = response.token;
        localStorage.setItem("jwt", token);
        this.invalidLogin = false;
        this.router.navigate(["/"]);
      },
      (error: any) => {
        console.log("Error", error);
        this.invalidLogin = true;
      }
    );
  }

}
