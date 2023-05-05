import { AuthService } from 'src/app/shared/services/api/auth.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';

/**
 * Component which provides the navigation bar of the application
 */
@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent implements OnInit {

  constructor(public authService: AuthService) { }

  ngOnInit(): void {
  }

  /**
   * Logout the current user from the application
   */
  logout() {
    this.authService.logout()
  }
}
