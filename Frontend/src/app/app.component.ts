import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  currentRoute!: string;

  languageList = [
    { code: 'pt', name: 'PT', icon: '1f1f5-1f1f9' },
    { code: 'en', name: 'EN', icon: '1f1fa-1f1f8' },
  ];

  dropdownIsVisible = false;

  constructor(private translate: TranslateService, private router: Router) {
    translate.setDefaultLang('pt');

    this.router.events.subscribe((event: any) => {
      if (event instanceof NavigationEnd) {
        this.currentRoute = event.url;
      }
    });
  }

  switchDropdown() {
    this.dropdownIsVisible = !this.dropdownIsVisible;
  }

  changeLang(lang: string) {
    this.translate.use(lang);
    this.switchDropdown();
  }
}
