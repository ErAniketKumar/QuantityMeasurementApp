import { Component } from '@angular/core';
import {
  ReactiveFormsModule,
  FormGroup,
  FormControl,
  Validators,
  AbstractControl,
  ValidationErrors,
} from '@angular/forms';
import { RouterLink, Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { initGoogleAuth } from '../../../services/google-auth.helper';
import { environment } from '../../../../environment/environment';

export function passwordMatchValidator(
  control: AbstractControl,
): ValidationErrors | null {
  const password = control.get('password')?.value;
  const rePassword = control.get('rePassword')?.value;

  return password === rePassword ? null : { passwordMismatch: true };
}
declare const google: any;

@Component({
  selector: 'app-register',
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  constructor(
    private authService: AuthService,
    private router: Router,
  ) {}

  errorMessage = '';

  registerForm = new FormGroup(
    {
      name: new FormControl('', [
        Validators.required,
        Validators.maxLength(50),
      ]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(6),
      ]),
      rePassword: new FormControl('', [
        Validators.required,
        Validators.minLength(6),
      ]),
    },
    {
      validators: passwordMatchValidator,
    },
  );

  HandleRegisterFormSubmit() {
    if (this.registerForm.invalid) {
      return;
    }

    const payload = {
      name: this.registerForm.value.name!,
      email: this.registerForm.value.email!,
      password: this.registerForm.value.password!,
    };

    this.authService.register(payload).subscribe({
      next: (response) => {
        console.log(response);
        this.errorMessage = '';

        this.router.navigate(['/dashboard']);
      },
      error: (error) => {
        console.log(error);
        this.errorMessage =
          error.error?.message || 'Registration failed. Please try again.';
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
