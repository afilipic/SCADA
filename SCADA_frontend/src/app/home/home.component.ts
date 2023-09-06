import { Component, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { TagService } from '../services/tag.service';
import { AITag, AOTag, DITag, DOTag, Tag, TagLog } from '../models/Tag';
import { FormControl, FormGroup } from '@angular/forms';
import { ReportService } from '../services/report.service';
import { Period } from '../models/Period';
import { Alarm } from '../models/Alarm';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements AfterViewInit {

  createTag = 'ANALOG';
  createTag2 = 'INPUT'
  editing: boolean = false;
  editId : string = "";
  idTag = '';
  deleteType : string = "";

  report = 1;

  alarms : Alarm[] = [];

  alarmReport : Alarm[] =[];
  tagReport : TagLog[] = [];
  tagAIReport : AITag[] = []
  tagDIReport : DITag[] = []

  analogInputs!: AITag[]
  digitalInputs!: DITag[]
  analogOutputs!: AOTag[]
  digitalOutputs!: DOTag[]

  activeContext: string = 'trending'; // default context
  title: string = 'Inputs'; // default title
  @ViewChild('editModal', { static: false }) editModal!: ElementRef;
  @ViewChild('confirmationModal', { static: false }) confirmationModal!: ElementRef;
 
  newTag!: FormGroup;
  private sortDirections: { [key: string]: boolean } = {};

  constructor(private elRef: ElementRef, private tagService : TagService, private reportService : ReportService) {} 


  ngOnInit(): void{

    this.tagService.startConnection()

    this.tagService.addReceiveTagListener((message: string) => {
        this.getTags();
    });

    this.tagService.addReceiveAlarmListener((message: Alarm) => {


      this.alarms.push(message)
      setTimeout(() => {
        // Clear the alarms array after 5 seconds
        this.alarms = [];
      }, 5000); // 5000 milliseconds = 5 seconds

  });
  

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




  getAlarmsPeriod(from: string, to: string){
    var period : Period ={
      from : from,
      to : to,
    }
    this.reportService.getAlarmPeriod(period).subscribe(response => {
      console.log('Successfully', response);

      this.alarmReport = response;
      this.tagAIReport = []
      this.tagDIReport = []
      this.tagReport = []
    }, error => {
      console.error('Error:', error);
    });
  }

  getAlarmsPriority(p : string){
    this.reportService.getAlarmPriority(p).subscribe(response => {
      console.log('Successfully', response);
      this.alarmReport = response;
      this.tagAIReport = []
      this.tagDIReport = []
      this.tagReport = []
    }, error => {
      console.error('Error:', error);
    });
  }

  getTagsPeriod(from : string, to : string){
    var period : Period ={
      from : from,
      to : to ,
    }
    this.reportService.getAllValuesByPeriod(period).subscribe(response => {
      console.log('Successfully', response);
      this.alarmReport = [];
      this.tagAIReport = []
      this.tagDIReport = []
      this.tagReport = response
    }, error => {
      console.error('Error:', error);
    });
  }

  getTagsId(tagId : string){
    this.reportService.getAllValuesByTagId(tagId).subscribe(response => {
      console.log('Successfully', response);
      this.alarmReport = [];
      this.tagAIReport = []
      this.tagDIReport = []
      this.tagReport = response
    }, error => {
      console.error('Error:', error);
    });
  }


  getTagsAI(){
    this.reportService.getLastAIValues().subscribe(response => {
      console.log('Successfully', response);
      this.alarmReport = [];
      this.tagAIReport = response
      this.tagDIReport = []
      this.tagReport = []
    }, error => {
      console.error('Error:', error);
    });
  }

  getTagsDI(){
    this.reportService.getLastDIValues().subscribe(response => {
      console.log('Successfully', response);
      this.alarmReport = [];
      this.tagAIReport = []
      this.tagDIReport = response
      this.tagReport = []
    }, error => {
      console.error('Error:', error);
    });
  }

  showReport( chosen : number){
    this.report = chosen;
    this.alarmReport = [];
    // this.tagAIReport = []
    // this.tagDIReport = []
  
    if (chosen == 5){

      this.getTagsDI()
    }
    if (chosen == 6){

      this.getTagsAI()

    }

  }

  sortColumn(sortBy: string, list: any[]) {
    if (!list || list.length <= 1) {
      // No sorting needed for an empty or single-item list
      return;
    }
  
    // Determine the current sort direction for the clicked column
    const isAscending = this.isAscending(sortBy);
  
    switch (sortBy) {
      case 'id':
        // Sort by the 'id' column
        list.sort((a, b) => {
          // Replace 'id' with the actual property you want to sort by
          const aValue = a.id;
          const bValue = b.id;
          return isAscending ? aValue.localeCompare(bValue) : bValue.localeCompare(aValue);
        });
        break;
      case 'value':
        // Sort by the 'value' column
        list.sort((a, b) => {
          // Replace 'value' with the actual property you want to sort by
          const aValue = a.value;
          const bValue = b.value;
          return isAscending ? aValue - bValue : bValue - aValue;
        });
        break;
        case 'limit':
          // Sort by the 'value' column
          list.sort((a, b) => {
            // Replace 'value' with the actual property you want to sort by
            const aValue = a.limit;
            const bValue = b.limit;
            return isAscending ? aValue - bValue : bValue - aValue;
          });
          break;
          case 'priority':
            // Sort by the 'value' column
            list.sort((a, b) => {
              // Replace 'value' with the actual property you want to sort by
              const aValue = a.priority;
              const bValue = b.priority;
              return isAscending ? aValue - bValue : bValue - aValue;
            });
            break;
      case 'time':
        // Sort by the 'time' column
        list.sort((a, b) => {
          // Replace 'time' with the actual property you want to sort by (e.g., timestamp)
          const aValue = new Date(a.scanTime).getTime();
          const bValue = new Date(b.scanTime).getTime();
          return isAscending ? aValue - bValue : bValue - aValue;
        });
        break;
        case 'time2':
          // Sort by the 'time' column
          list.sort((a, b) => {
            // Replace 'time' with the actual property you want to sort by (e.g., timestamp)
            const aValue = new Date(a.timeStamp).getTime();
            const bValue = new Date(b.timeStamp).getTime();
            return isAscending ? aValue - bValue : bValue - aValue;
          });
          break;

      default:
        // Handle an unsupported sortBy value or don't do anything
        break;
    }
  }
  
  private isAscending(sortBy: string): boolean {
    // Track the current sort direction for each column
    if (this.sortDirections[sortBy] === undefined) {
      this.sortDirections[sortBy] = true; // Default to ascending for the first click
    } else {
      this.sortDirections[sortBy] = !this.sortDirections[sortBy]; // Toggle between ascending and descending
    }
    return this.sortDirections[sortBy];
  }

}
