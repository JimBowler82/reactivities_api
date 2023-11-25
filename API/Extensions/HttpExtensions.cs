using System.Text.Json;

namespace API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            // Create a new instance of PaginationHeader
            var paginationHeader = new { currentPage, itemsPerPage, totalItems, totalPages };

            // Create a new instance of JsonSerializerOptions
            var options = new JsonSerializerOptions
            {
                // Set the property name case to camelCase
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            // Serialize the paginationHeader object to a JSON string
            // and store it in the paginationHeaderJson variable
            var paginationHeaderJson = JsonSerializer.Serialize(paginationHeader, options);

            // Add the paginationHeaderJson string to the response header
            response.Headers.Add("Pagination", paginationHeaderJson);

            // Add the Access-Control-Expose-Headers header to the response
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
