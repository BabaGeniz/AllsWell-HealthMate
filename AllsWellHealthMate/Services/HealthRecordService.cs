using AllsWellHealthMate.Models;
using AllsWellHealthMate.Data;
using AllsWellHealthMate.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllsWellHealthMate.Repositories;
using Microsoft.Extensions.Diagnostics.HealthChecks;


namespace AllsWellHealthMate.Services
{
	public class HealthRecordService : IHealthRecordService
	{
		private readonly IHealthRecordRepository _healthRecordRepository;
		private readonly IAllergyRepository _allergyRepository;
		private readonly IPrescriptionRepository _prescriptionRepository;

		public ICollection<Allergy> allergies = new List<Allergy>();
		public ICollection<Prescription> prescriptions = new List<Prescription>();
		public HealthRecordService(IHealthRecordRepository healthRecordRepository, IAllergyRepository allergyRepository, IPrescriptionRepository prescriptionRepository)
		{
			_healthRecordRepository = healthRecordRepository;
			_allergyRepository = allergyRepository;
			_prescriptionRepository = prescriptionRepository;
		}

		// Get all health records
		public IEnumerable<HealthRecord> GetAllHealthRecords()
		{
			return _healthRecordRepository.GetAllHealthRecords();
		}

		// Get a specific health record by ID
		public HealthRecord GetHealthRecordById(int id)
		{
			return _healthRecordRepository.GetHealthRecordById(id);
		}

		// Get a health record by user ID (typically associated with a patient)
		public HealthRecord GetHealthRecordByUserId(int userId)
		{
			return _healthRecordRepository.GetHealthRecordByUserId(userId);
		}

        // Create a new health record using a DTO
        public HealthRecord CreateHealthRecord(HealthRecordDTO healthRecordDTO)
		{
			
			// Map the DTO to the HealthRecord model
			var healthRecord = new HealthRecord
			{
				UserId = healthRecordDTO.UserId,
				DateOfRecord = healthRecordDTO.DateOfRecord,
				MedicalHistory = healthRecordDTO.MedicalHistory,
				HeartRate = healthRecordDTO.HeartRate,
				BloodPressure = healthRecordDTO.BloodPressure,
				GlucoseLevel = healthRecordDTO.GlucoseLevel,
				Cholestrol = healthRecordDTO.Cholestrol,
				BMI = healthRecordDTO.BMI,
				Diagnosis = healthRecordDTO.Diagnosis, // Reserved for future version
				TreatmentPlan = healthRecordDTO.TreatmentPlan, // Reserved for future version
				ScheduledAppointments = healthRecordDTO.ScheduledAppointments
			};
			
			_healthRecordRepository.AddHealthRecordAsync(healthRecord);

			AddAllergies(healthRecord.Id, healthRecordDTO);
			AddPrescriptions(healthRecord.Id, healthRecordDTO);		


			//healthRecord.Allergies = allergies;
			//healthRecord.Prescriptions = prescriptions;

			//_healthRecordRepository.UpdateHealthRecord(healthRecord);
			return healthRecord;
		}

		// Helper Functions
		public void AddAllergies(int healthRecordId, HealthRecordDTO healthRecordDTO)
		{
			foreach (var allergy in healthRecordDTO.Allergies)
            {
				var allergyDTO = new Allergy
				{
					HealthRecordId = healthRecordId,
					AllergyName = allergy.AllergyName,
					DateIdentified = allergy.DateIdentified
				};
                _allergyRepository.AddAllergyAsync(allergyDTO);             
            }
			
		}
		private void AddPrescriptions(int healthRecordId, HealthRecordDTO healthRecordDTO)
		{
			foreach (var prescription in healthRecordDTO.Prescriptions)
			{
				var prescriptionDTO = new Prescription
				{
					HealthRecordId = healthRecordId,
					DrugName = prescription.DrugName,
					Dosage = prescription.Dosage,
					DatePrescribed = DateTime.Now,
					ProviderId = prescription.ProviderId
					//PrescribingDoctor = prescription.PrescribingDoctor,

				};
				_prescriptionRepository.AddPrescriptionAsync(prescriptionDTO);
			}
		}

		private void UpdateAllergies(List<int> allergyIds, HealthRecordDTO healthRecordDTO)
		{
			if (healthRecordDTO.Allergies != null)
			{
				int idIndex = 0;
				foreach (var allergy in healthRecordDTO.Allergies)
				{
					var existingAllergy = _allergyRepository.GetAllergyById(allergyIds[idIndex]);
					existingAllergy.AllergyName = allergy.AllergyName;
					existingAllergy.DateIdentified = allergy.DateIdentified;
					idIndex++;
					_allergyRepository.UpdateAllergy(existingAllergy);
				}
			}
		}
		private void UpdatePrescriptions(List<int> prescriptionIds, HealthRecordDTO healthRecordDTO)
		{
			if (healthRecordDTO.Prescriptions != null)
			{
				int idIndex = 0;
				foreach (var prescription in healthRecordDTO.Prescriptions)
				{
					var existingPrescription = _prescriptionRepository.GetPrescriptionById(prescriptionIds[idIndex]);
					existingPrescription.DatePrescribed = prescription.DatePrescribed;
					existingPrescription.Dosage = prescription.Dosage;
					existingPrescription.DrugName = prescription.DrugName;
					existingPrescription.PrescribingDoctor = prescription.PrescribingDoctor;
					idIndex++;
					_prescriptionRepository.UpdatePrescription(existingPrescription);
				}
			}
		}

		// Update an existing health record
		public HealthRecord UpdateHealthRecord(HealthRecordDTO healthRecordDTO)
		{
			var existingHealthRecord = _healthRecordRepository.GetHealthRecordByUserId(healthRecordDTO.UserId);
		    var allergyIds = existingHealthRecord.Allergies.Select(u => u.Id).ToList();
			var prescriptionIds = existingHealthRecord.Prescriptions.Select(u=>u.Id).ToList();

			if (existingHealthRecord != null)
			{
				existingHealthRecord.DateOfRecord = healthRecordDTO.DateOfRecord;
				existingHealthRecord.MedicalHistory = healthRecordDTO.MedicalHistory;
				existingHealthRecord.HeartRate = healthRecordDTO.HeartRate;
				existingHealthRecord.BloodPressure = healthRecordDTO.BloodPressure;
				existingHealthRecord.GlucoseLevel = healthRecordDTO.GlucoseLevel;
				existingHealthRecord.Cholestrol = healthRecordDTO.Cholestrol;
				existingHealthRecord.BMI = healthRecordDTO.BMI;
				existingHealthRecord.Diagnosis = healthRecordDTO.Diagnosis; // Reserved for future version
				existingHealthRecord.TreatmentPlan = healthRecordDTO.TreatmentPlan; // Reserved for future version
				existingHealthRecord.ScheduledAppointments = healthRecordDTO.ScheduledAppointments;

				_healthRecordRepository.UpdateHealthRecord(existingHealthRecord);
			}

			UpdateAllergies(allergyIds, healthRecordDTO);
			UpdatePrescriptions(prescriptionIds, healthRecordDTO);

			return existingHealthRecord;

		}

		// Delete a health record by ID
		public void DeleteHealthRecord(int id)
		{
			_healthRecordRepository.DeleteHealthRecord(id);
		}
	}
}
