import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  constructor(private translate: TranslateService) {
    translate.setDefaultLang('pt');
  }

  languageList = [
    { code: 'pt', name: 'PT', icon: '1f1f5-1f1f9' },
    { code: 'en', name: 'EN', icon: '1f1fa-1f1f8' },
  ];

  dropdownIsVisible = false;

  switchDropdown() {
    this.dropdownIsVisible = !this.dropdownIsVisible;
  }

  changeLang(lang: string) {
    this.translate.use(lang);
    this.switchDropdown();
  }
}
