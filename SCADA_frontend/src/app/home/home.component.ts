import { Component, ElementRef, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements AfterViewInit {

  constructor(private elRef: ElementRef) {}  // Inject ElementRef to access DOM

  ngAfterViewInit(): void {
    // Get all the buttons
    const buttons = this.elRef.nativeElement.querySelectorAll('.menu-button');

    // Loop through each button
    buttons.forEach((button: HTMLButtonElement) => {
      button.addEventListener('click', function() {
        // Remove active class from all buttons
        buttons.forEach((btn: HTMLButtonElement) => btn.classList.remove('active'));
        
        // Add active class to the clicked button
        this.classList.add('active');
      });
    });
  }
}
