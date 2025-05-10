using LegalCaseManagementSystem_BackEnd.DTOs.CaseTasks;
using LegalCaseManagementSystem_BackEnd.DTOs.Clients;
using LegalCaseManagementSystem_BackEnd.DTOs.Documents;
using LegalCaseManagementSystem_BackEnd.DTOs.Hearings;
using LegalCaseManagementSystem_BackEnd.DTOs.Invoices;
using LegalCaseManagementSystem_BackEnd.DTOs.Lawyers;

namespace LegalCaseManagementSystem_BackEnd.DTOs.Cases
{
    public class CaseDetailsDTO : CaseDTO
    {
        public ClientDTO Client { get; set; } = null!;
        public LawyerDTO Lawyer { get; set; } = null!;
        public ICollection<CaseTaskDTO> CaseTasks { get; set; } = [];
        public ICollection<DocumentDTO> Documents { get; set; } = [];
        public ICollection<HearingDTO> Hearings { get; set; } = [];
        public ICollection<InvoiceDTO> Invoices { get; set; } = [];
    }
}
