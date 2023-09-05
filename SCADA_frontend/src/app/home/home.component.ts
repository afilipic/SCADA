import { Component, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { TagService } from '../services/tag.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements AfterViewInit {

  value = ''; // Sample initial value, fetch from backend or set appropriately
  highLimit = '';
  lowLimit = '';
  driver = '';
  editing: boolean = false;
    cardNumber: string = '70 345'; // Default value, you can get this from your API or elsewhere


  activeContext: string = 'trending'; // default context
  title: string = 'Inputs'; // default title
  @ViewChild('editModal', { static: false }) editModal!: ElementRef;
  @ViewChild('confirmationModal', { static: false }) confirmationModal!: ElementRef;
 
  

  constructor(private elRef: ElementRef, private tagService : TagService) {} 

  ngAfterViewInit(): void {
    // This will ensure the modal element is available after view initialization.
    console.log(this.confirmationModal);

 
  
      this.tagService.getAllAI().subscribe({
        next: (result) => {
      
          console.log(result)
        },
        error:(error) => {
          console.log(error)
        }
      })
    

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
  toggleEdit(): void {
    this.editing = !this.editing;
}

saveValue(): void {
  // Here, you can make an API call to update the value if needed.
  // After saving, you might want to turn off editing mode:
  this.editing = false;
}

  showContext(context: string) {
    this.activeContext = context;
    if (context === 'trending') {
      this.title = 'Inputs';
    } else if (context === 'dbManager') {
      this.title = 'Outputs';
    }
  }
  showConfirmation(): void {
    this.confirmationModal.nativeElement.style.display = 'block';
  }

  confirmDelete(): void {
    console.log("Item deleted!");
    this.confirmationModal.nativeElement.style.display = 'none';
  }

  cancelAction(): void {
    this.confirmationModal.nativeElement.style.display = 'none';
  }

  showCreateForm(): void {
    this.editModal.nativeElement.style.display = 'block';
  }

  hideEditForm(): void {
    this.editModal.nativeElement.style.display = 'none';
  }

  edit(): void {
    // Logic to edit the data.
    // If you're making an API call to update the data, do it here.
    console.log('Edited value:', this.value, this.highLimit, this.lowLimit);

    this.hideEditForm();
  }
}
