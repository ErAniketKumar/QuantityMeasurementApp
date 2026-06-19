import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { environment } from '../../../../environment/environment';
import { initGoogleAuth } from '../../../services/google-auth.helper';

declare const google: any;

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent implements OnInit {
  constructor(
    private authService: AuthService,
    private router: Router,
  ) {}

  errorMessage = '';

  loginForm: any = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(6),
    ]),
  });

  handleLoginSubmit() {
    if (this.loginForm.invalid) {
      return;
    }

    const payload = {
      email: this.loginForm.value.email!,
      password: this.loginForm.value.password!,
    };

    this.authService.login(payload).subscribe({
      next: (response) => {
        console.log(response);
        this.errorMessage = '';
        localStorage.setItem('token', response.token);
        this.router.navigate(['/dashboard']);
      },
      error: (error) => {
        console.log(error);
        this.errorMessage = this.errorMessage =
          error.error?.message || 'Invalid email or password';
      },
    });
  }

  ngOnInit(): void {
    initGoogleAuth(
      environment.googleClientId,
      this.authService,
      this.router,
      (msg) => (this.errorMessage = msg),
    );

    google.accounts.id.renderButton(document.getElementById('googleBtn'), {
      theme: 'outline',
      size: 'large',
      width: '300',
    });
  }
}
