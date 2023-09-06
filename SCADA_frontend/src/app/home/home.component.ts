import { Component, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { TagService } from '../services/tag.service';
import { AITag, AOTag, DITag, DOTag, Tag } from '../models/Tag';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements AfterViewInit {


  tagsList! : Tag[];
  value = ''; // Sample initial value, fetch from backend or set appropriately
  cardNumber: string = '70 345'; // Default value, you can get this from your API or elsewhere
  highLimit = '';
  lowLimit = '';
  driver = '';
  idTag = '';


  editing: boolean = false;
  editId : string = "";
  deleteType : string = "";

  analogInputs!: AITag[]
  digitalInputs!: DITag[]
  analogOutputs!: AOTag[]
  digitalOutputs!: DOTag[]

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
          this.analogInputs = result
          console.log(this.analogInputs[0])
        },
        error:(error) => {
          console.log(error)
        }
      })

      this.tagService.getAllDI().subscribe({
        next: (result) => {
          this.digitalInputs = result
          console.log(this.analogInputs[0])
        },
        error:(error) => {
          console.log(error)
        }
      })

      this.tagService.getAllAO().subscribe({
        next: (result) => {
          this.analogOutputs = result
          console.log(this.analogInputs[0])
        },
        error:(error) => {
          console.log(error)
        }
      })
      this.tagService.getAllDO().subscribe({
        next: (result) => {
          this.digitalOutputs = result
          console.log(this.analogInputs[0])
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
  toggleEdit(id : string): void {
    this.editing = !this.editing;
    this.editId = id;
}

saveValue(tag:Tag, type : string): void {
  this.editing = false;

 
  this.tagService.editTag(tag.id, tag.value, type).subscribe(response => {
    console.log('Successfully', response);
  }, error => {
    console.error('Error:', error);
  });
  
}

  showContext(context: string) {
    this.activeContext = context;
    if (context === 'trending') {
      this.title = 'Inputs';
    } else if (context === 'dbManager') {
      this.title = 'Outputs';
    }else if (context === 'reports') {
      this.title = 'Reports';
    }
  }


  showConfirmation(id:string, type : string): void {
    this.deleteType = type;
    this.confirmationModal.nativeElement.style.display = 'block';
    this.idTag = id;

  }

  confirmDelete(idTag:string): void {
    console.log("Item deleted!");
    this.confirmationModal.nativeElement.style.display = 'none';
   
      this.tagService.deleteTag(idTag, this.deleteType).subscribe(response => {
        console.log('Tag deleted successfully:', response);
        // Handle success - maybe update the UI or show a user feedback.
      }, error => {
        console.error('Error deleting tag:', error);
        // Handle error - maybe show an error message to the user.
      });
    
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

  switch (id : string, type: string) {
     this.tagService.switch(id, type).subscribe(response => {
    console.log('Successfully', response);
  }, error => {
    console.error('Error:', error);
  });
  }
}
