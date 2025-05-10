namespace LegalCaseManagementSystem_BackEnd.DTOs.Documents
{
    public class DocumentDTO
    {
        public int DocumentId { get; set; }
        public int CaseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }
    }
}
