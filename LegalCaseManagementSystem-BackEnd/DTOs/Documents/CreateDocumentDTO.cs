namespace LegalCaseManagementSystem_BackEnd.DTOs.Documents
{
    public class CreateDocumentDTO
    {
        public string Title { get; set; } = string.Empty;
        public IFormFile File { get; set; } = null!;
    }
}
