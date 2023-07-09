namespace UserRolesNew.Helpers
{
    public class StatusHelper
    {
        public static string GetStatusColor(string status)
        {
            switch (status.ToLower())
            {
                case "approved":
                    return "#4caf50"; // Green color for "Approved"
                case "under review":
                    return "#03a9f4"; // Light Blue color for "Under Review"
                case "rejected":
                    return "#f44336"; // Red color for "Rejected"
                default:
                    return string.Empty; // Empty string for other statuses or no color specified
            }
        }
    }
}
