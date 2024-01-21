## 1. Create Appointment-get-next-appointment.OperationDefinition.json
This step defines the api shape for extended operation, including input resource and output resource.

## 2. Create Appointment-get-next-appointment.StructureDefinition.json
This step defines the validation rules for input resource.

## 3. Update capability-statement.json
This step includes the extended operation in the capability statement so that system can auto generate the new api in swagger document.

## 4. Create GetNextAppointmentFhirHandler.cs
This file implements the business logic of the extended operation api.

## 5. Update appsettings.json
This step to instruct system load the new FhirHandler GetNextAppointmentAsync from class GetNextAppointmentFhirHandler