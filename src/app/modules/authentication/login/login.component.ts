import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/interfaces/login';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  title: string
  loginForm = this.fb.group({
    email: ['', Validators.required],
    password: ['', Validators.required],
  })
  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    if(localStorage.getItem('token'))
    {
      this.title = "Login status: logged in";
    }
    else
    {
      this.title = "Login status: not logged in";
    }

  }

  onLogin() {
    var newUser: Login = this.loginForm.value;

    console.log(newUser);
    this.authService.login(newUser).subscribe();
    
    // window.location.reload();
  }

  gotoServices(){
    this.router.navigate(['/servicesauto']);
  }

  onLogout() {

    this.authService.logout();

    // window.location.reload();
  }
}
