﻿namespace Bgg.Net.Common.Infrastructure.Validation
{
    public class ValidationResult
    {
        /// <summary>
        /// True if validation was successful.
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Contains messages for any validation errors that occurred.
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();
    }
}
