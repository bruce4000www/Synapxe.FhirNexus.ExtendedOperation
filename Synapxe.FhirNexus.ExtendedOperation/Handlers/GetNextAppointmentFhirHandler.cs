// -------------------------------------------------------------------------------------------------
// Copyright (c) Integrated Health Information Systems Pte Ltd. All rights reserved.
// -------------------------------------------------------------------------------------------------

using Hl7.Fhir.Model;
using Ihis.FhirEngine.Core;
using Ihis.FhirEngine.Core.Exceptions;
using Ihis.FhirEngine.Core.Search;

namespace Synapxe.FhirNexus.ExtendedOperation.Handlers
{
    [FhirHandlerClass(AcceptedType = nameof(Appointment))]
    public class GetNextAppointmentFhirHandler
    {
        private readonly ISearchService searchService;

        public GetNextAppointmentFhirHandler(ISearchService<Appointment> searchService)
        {
            this.searchService = searchService;
        }

        [FhirHandler(HandlerCategory.CRUD, FhirInteractionType.OperationType, CustomOperation = "get-next-appointment")]
        public async Task<Appointment> GetNextAppointmentAsync(IFhirContext context, CancellationToken cancellationToken = default)
        {
            if (context.Request.Resource is not Parameters parameters)
                throw new RequestNotValidException("Parameters not found.");

            parameters.TryGetValue("patient-identifier", out string patientIdentifier);

            var searchParams = new List<(string, string)>
            {
                ("patient", patientIdentifier),
                ("date",$"gt{System.DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")}"),
                ("_sort", "date"),
                ("_count", "1"),
            };

            var searchResult = await searchService.SearchAsync(nameof(Appointment), searchParams.ToArray(), false, cancellationToken);

            if (searchResult.Results.Any())
            {
                var appointment = searchResult.Results.FirstOrDefault().Resource.ToResource() as Appointment;
                return appointment;
            }

            throw new ResourceNotFoundException($"No appointment found for patient {patientIdentifier}", System.Net.HttpStatusCode.NotFound);
        }
    }
}
