import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service'
import { User, UserDTO } from '../../models/user.model';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';

@Component({
  selector: 'app-createhealthrecord',
  templateUrl: './createhealthrecord.component.html',
  styleUrl: './createhealthrecord.component.css'
})
export class CreatehealthrecordComponent implements OnInit {
  patients: User[] = [];
  selectedPatient: string | null =null ; // To store the selected patient
  patientData: any;
  healthCondition: string = '';
  bloodPressure: number | null = null;
  heartRate: number | null = null;
  cholestrol: number | null = null;
  glucoseLevel: number | null = null;
  bmi: number | null = null;

  physicianFirstName = '';
  physicianLastName = '';
  addressLine1 = '';
  selectedMonth1: string | null = null;
  selectedDay1: number | null = null;
  selectedYear1: number | null = null;

  dateForm!: FormGroup;  // Define the form group
  patientNameForm!: FormGroup;

  months: string[] = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
  days: number[] = Array.from({ length: 31 }, (v, k) => k + 1);
  years: number[] = Array.from({ length: 100 }, (v, k) => 2024 - k);

  healthRecordForm!: FormGroup;

  constructor(private apiService: ApiService, private fb: FormBuilder) {
    const today = new Date();

    this.selectedMonth1 = this.months[today.getMonth()]; // Get the current month (0-11)
    this.selectedDay1 = today.getDate(); // Get the current day of the month (1-31)
    this.selectedYear1 = today.getFullYear(); // Get the current year
  }

  ngOnInit(): void {
    // Assuming role '2' is for patients
    const patientRole = 2;
    this.apiService.getUsersByRole(patientRole).subscribe(
      (data) => {
        this.patients = data;
      },
      (error) => {
        console.error('Error fetching patients:', error);
      }
    );

    this.healthRecordForm = this.fb.group({
      prescriptions: this.fb.array([]) // FormArray for prescriptions
    });
    this.dateForm = this.fb.group({
      selectedMonth1: ['', Validators.required],  // Add form control for the month selection
      selectedDay1: ['', Validators.required],
      selectedYear1: ['', Validators.required],
    });

    this.patientNameForm = this.fb.group({
      patientData : ['', Validators.required],
    })
  }
  // Getter for easier access to prescriptions FormArray
  get prescriptions(): FormArray {

    return this.healthRecordForm.get('prescriptions') as FormArray;
  }

  // Method to add a new prescription input
  addPrescription() {
    this.prescriptions.push(this.fb.control(''));
  }

  // Method to remove a prescription input
  removePrescription(index: number) {
    this.prescriptions.removeAt(index);
  }

  // Method to submit the form
  submitForm() {
    console.log(this.healthRecordForm.value);
  }
  onPatientSelect(patientId: string): void {
    this.selectedPatient = patientId;


    // Reset BMI and any other health metrics if needed
    this.bmi = null;
    this.bloodPressure = null;  
    this.heartRate = null;
    this.cholestrol = null;
    this.glucoseLevel = null;

    this.apiService.getUserById(Number(patientId)).subscribe(
      (data) => {
        console.log(data.firstName);
        this.patientData = data;
      },
      (error) => {
        console.error('Error fetching patient data:', error);
      }
    )   

  }
  onSubmit(): void {
    // Logic to handle form submission goes here
  }
}
