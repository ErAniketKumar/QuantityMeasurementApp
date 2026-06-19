import { Router } from '@angular/router';
import { AuthService } from './auth.service';

declare const google: any;

export function initGoogleAuth(
  clientId: string,
  authService: AuthService,
  router: Router,
  onError?: (msg: string) => void,
) {
  google.accounts.id.initialize({
    client_id: clientId,
    callback: (response: any) => {
      const idToken = response.credential;

      authService.googleAuth(idToken).subscribe({
        next: (res) => {
          localStorage.setItem('token', res.token);
          router.navigate(['/dashboard']);
        },
        error: (err) => {
          console.error(err);
          onError?.('Google authentication failed');
        },
      });
    },
  });
}
