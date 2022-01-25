import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appLineHover]'
})
export class LineHoverDirective {

  constructor(
    public el: ElementRef,
  ) { }

  @HostListener('mouseenter') onMouseEnter() {
    this.highlight('LightGray');
  }

  @HostListener('mouseleave') onMouseLeave() {
    this.highlight('');
  }

  private highlight(color: string) {
    this.el.nativeElement.style.backgroundColor = color;
  }


}
