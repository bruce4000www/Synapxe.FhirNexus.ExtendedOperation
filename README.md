
## Step 1: Add nexus repository to global nuget.config and install FhirNexus template to visual studio
```
dotnet nuget add source https://nexus.ihis-hip.sg/repository/ihis-nuget/ -n nexus -u YOUR_USER_NAME -p YOUR_PASSWORD

dotnet new --install Ihis.FhirEngine.WebApiTemplate.CSharp::3.0.1
```
## Step 2: Create a new project from FHIRNexus template
![image](https://github.com/bruce4000www/Synapxe.FhirNexus.ExtendedOperation/assets/141336095/574859fb-3e8c-47a7-b30c-8115542ea0f3)

## Step 3: Set project parameters as below
![image](https://github.com/bruce4000www/Synapxe.FhirNexus.ExtendedOperation/assets/141336095/bdf9ce41-de8f-4ea0-8a0f-b87dd6a5c2d2)

## Step 4: Create a OperationDefinition file to define the input and output resources of extended operation $get-patient-by-nric
Refer to Synapxe.FhirNexus.ExtendedOperation/Conformance/Appointment-get-next-appointment.OperationDefinition.json

## Step 5: Create a StructureDefinition file to define the validation rules of extended operation $get-patient-by-nric
Refer to Synapxe.FhirNexus.ExtendedOperation/Conformance/Appointment-get-next-appointment.StructureDefinition.json

## Step 6: Register extended operation $get-patient-by-nric in capability statement
```
{
  "resourceType": "CapabilityStatement",
  "rest": [
    {
      "resource": [
        {
          "type": "Appointment",
          "operation": [
            {
              "name": "get-patient-by-nric",
              "definition": "UPDATE_URL_TO_YOUR_DEFINITION"
            }
          ]
        }
      ]
    }
  ]
}
```
## Step 7: Create a FhirHandler source code file
Refer to Synapxe.FhirNexus.ExtendedOperation/Handlers/GetNextAppointmentFhirHandler.cs

## Step 8: Register FhirHandler file in appsettings
```
{
  "FhirEngine": {
    "Handlers": {
      "FromClass": {
        "YOUR_FHIRHANDLER_CLASS_NAME": true
      }
    }
  }
}
```
