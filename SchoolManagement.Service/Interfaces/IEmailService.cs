﻿namespace SchoolManagement.Service.Interfaces
{
    public interface IEmailService
    {
        public Task<string> SendEmailAsync(string email, string subject, string message);
    }
}
