﻿namespace Report.Models
{
    public class RecognizedUser
    {
        public Guid UserId { get; set; }
        public string Salt { get; set; }
        public string PasswordHash { get; set; }
    }
}
