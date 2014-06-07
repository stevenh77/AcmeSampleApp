namespace Acme.API.Repositories
{
    public class AcmeDatabase
    {
        public const string StoredProc_CustomerDelete = "dbo.usp_CustomerDelete";
        public const string StoredProc_CustomerInsert = "dbo.usp_CustomerInsert";
        public const string StoredProc_CustomerSearch = "dbo.usp_CustomerSearch";
        public const string StoredProc_CustomerSelect = "dbo.usp_CustomerSelect";
        public const string StoredProc_CustomerSelectAll = "dbo.usp_CustomerSelectAll";
        public const string StoredProc_CustomerUpdate = "dbo.usp_CustomerUpdate";

        public const string StoredProc_CustomersByCategoryAndLocation = "dbo.usp_CustomersByCategoryAndLocation";

        public const string StoredProc_CustomerSelectAll_Audit = "audit.usp_CustomerSelectAll";
    }
}