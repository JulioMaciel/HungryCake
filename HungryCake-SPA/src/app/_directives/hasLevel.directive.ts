import { Directive, Input, ViewContainerRef, TemplateRef, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Directive({
  selector: '[appUserLevel]'
})
export class HasLevelDirective implements OnInit {
  @Input() appUserLevel: number;
  isVisible = false;

  constructor(private viewContainerRef: ViewContainerRef, private templateRef: TemplateRef<any>, private authService: AuthService) { }

  ngOnInit() {
    const userLevel = this.authService.decodedToken.level as number;

    // if no roles clear the viewContainerRef
    if (!userLevel || userLevel === 3) {
      this.viewContainerRef.clear();
    }

    // if user has role need then render the element
    if (this.authService.levelMatch(this.appUserLevel)) {
      if (!this.isVisible) {
        this.isVisible = true;
        this.viewContainerRef.createEmbeddedView(this.templateRef);
      } else {
        this.isVisible = false;
        this.viewContainerRef.clear();
      }
    }
  }

}
