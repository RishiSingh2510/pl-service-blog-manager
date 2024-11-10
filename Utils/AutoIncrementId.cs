namespace blog_management_service.Utils
{
    /// <summary>
    /// Utility class for generating auto-incrementing IDs.
    /// </summary>
    public static class AutoIncrementId
    {
        private static int Id = 0;

        /// <summary>
        /// Gets the next auto-incrementing ID.
        /// </summary>
        /// <returns>The next auto-incrementing ID.</returns>
        public static int GetNextId()
        {
            return ++Id;
        }
    }
}
