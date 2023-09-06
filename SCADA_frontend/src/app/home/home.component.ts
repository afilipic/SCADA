import { Component, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { TagService } from '../services/tag.service';
import { AITag, AOTag, DITag, DOTag, Tag } from '../models/Tag';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements AfterViewInit {

  createTag = 'ANALOG';
  createTag2 = 'INPUT'

  // tagsList! : Tag[];
  // value = ''; // Sample initial value, fetch from backend or set appropriately
  // cardNumber: string = '70 345'; // Default value, you can get this from your API or elsewhere
  // highLimit = '';
  // lowLimit = '';
  // driver = '';
  // units = ''


  editing: boolean = false;
  editId : string = "";
  idTag = '';
  deleteType : string = "";

  analogInputs!: AITag[]
  digitalInputs!: DITag[]
  analogOutputs!: AOTag[]
  digitalOutputs!: DOTag[]

  activeContext: string = 'trending'; // default context
  title: string = 'Inputs'; // default title
  @ViewChild('editModal', { static: false }) editModal!: ElementRef;
  @ViewChild('confirmationModal', { static: false }) confirmationModal!: ElementRef;
 
  newTag!: FormGroup;

  constructor(private elRef: ElementRef, private tagService : TagService) {} 


  ngOnInit(): void{
    
    this.newTag = new FormGroup({
      id: new FormControl(''),
      address: new FormControl(''),
      description : new FormControl(''),
      value: new FormControl(''),
      units: new FormControl(''),
      lowLimit : new FormControl(''),
      highLimit : new FormControl(''),
    });
  }
  ngAfterViewInit(): void {  
      this.getTags();


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


  getTags(){
    this.tagService.getAllAI().subscribe({
      next: (result) => {
        this.analogInputs = result
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
      },
      error:(error) => {
        console.log(error)
      }
    })
    this.tagService.getAllDO().subscribe({
      next: (result) => {
        this.digitalOutputs = result
      },
      error:(error) => {
        console.log(error)
      }
    })
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

  create(): void {

    const tag: AITag  = this.newTag.value;

    if(this.createTag == 'ANALOG' && this.createTag2 == 'INPUT'){
      this.createAI(tag)
    }
    if(this.createTag == 'ANALOG' && this.createTag2 == 'OUTPUT'){
      this.createAO(tag)
    }
    if(this.createTag == 'DIGITAL' && this.createTag2 == 'INPUT'){
      this.createDI(tag)
    }
    if(this.createTag == 'DIGITAL' && this.createTag2 == 'OUTPUT'){
      this.createDO(tag)
    }
    this.hideEditForm();
  }

  createTagType(type : string){
    this.createTag = type;

  }

  createTagType2(type : string){
    this.createTag2 = type;
  }

  switch (id : string, type: string) {
     this.tagService.switch(id, type).subscribe(response => {
    console.log('Successfully', response);
  }, error => {
    console.error('Error:', error);
  });
  }


  createDI(tag : AITag){

    var newTag : DITag ={
      driverType: 0,
      scanTime: new Date,
      isScanning: true,
      id: tag.id,
      description: tag.description,
      address: tag.address,
      value: tag.value
    }
    console.log(newTag)
    this.tagService.addDI(newTag).subscribe(response => {
      console.log('Successfully', response);
    }, error => {
      console.error('Error:', error);
    });
  }

  createAI(tag : AITag){

    tag.isScanning = true;
    tag.scanTime = new Date;
    tag.driverType = 0;
    console.log(tag)
    this.tagService.addAI(tag).subscribe(response => {
      console.log('Successfully', response);
    }, error => {
      console.error('Error:', error);
    });
  }

  createDO(tag : AITag){


    var newTag : DOTag ={
      initialValue: tag.value,
      id: tag.id,
      description: tag.description,
      address: tag.address,
      value: tag.value
    }
    console.log(newTag)
    this.tagService.addDO(newTag).subscribe(response => {
      console.log('Successfully', response);
    }, error => {
      console.error('Error:', error);
    });
  }

  createAO(tag : AITag){

    var newTag : AOTag ={
      lowLimit: tag.lowLimit,
      highLimit: tag.highLimit,
      units: tag.units,
      initialValue: tag.value,
      id: tag.id,
      description: tag.description,
      address: tag.address,
      value: tag.value
    }
    console.log(newTag)

     
  this.tagService.addAO(newTag).subscribe(response => {
    console.log('Successfully', response);
  }, error => {
    console.error('Error:', error);
  });

  }


}
